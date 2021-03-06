using System;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DimitriSauvageTools.Infrastructure.Settings;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using PetanquePlanning.Business.Core.Application.Services;
using PetanquePlanning.Business.Core.Infrastructure.Abstractions.Abstractions;
using PetanquePlanning.Business.Core.Infrastructure.EntityFramework.Repositories;
using PetanquePlanning.Business.Identity.Application.Services;
using PetanquePlanning.Business.Identity.Domain.Entities;
using PetanquePlanning.Business.Identity.Infrastructure.Abstractions.Abstractions;
using PetanquePlanning.Business.Identity.Infrastructure.EntityFramework.Repositories;
using PetanquePlanning.Business.Location.Application.Services;
using PetanquePlanning.Business.Location.Infrastructure.Abstractions.Abstractions;
using PetanquePlanning.Business.Location.Infrastructure.EntityFramework.Repositories;

namespace PetanquePlanningApi
{
    public class Startup
    {
        #region Fields

        /// <summary>
        /// App conf
        /// </summary>
        private IConfiguration Configuration { get; }

        #endregion

        #region Constructors

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        #endregion

        #region Public methods

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Global config
            services.AddControllers();
            services.AddDistributedMemoryCache();

            //Database config
            this.ConfigureDatabase(services);

            //Auth config
            this.ConfigureAuthentication(services);

            //Add the AutoMapper
            services.AddAutoMapper(typeof(Startup));

            //Session config
            services.AddSession(options =>
            {
                options.Cookie.Expiration = TimeSpan.FromDays(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.Name = ".PetanquePlanning.Session";
                options.IdleTimeout = TimeSpan.FromHours(2);
            });

            
            //Add repo and services to the DI
            AddBusinessRepositories(services);
            AddBusinessServices(services);

            //Identity config
            AddIdentity(services);

            services.Configure<IISServerOptions>(options => { options.AutomaticAuthentication = false; });
            services.Configure<IISOptions>(options => { options.ForwardClientCertificate = false; });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            // Permet l'utilisation d'Apache ou de nginx comme serveur de reverse proxy
            app.UseForwardedHeaders(new ForwardedHeadersOptions()
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor |
                                   ForwardedHeaders.XForwardedProto
            });

            #region Chargement des fichiers statiques

            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = (context) =>
                {
                    var headers = context.Context.Response.GetTypedHeaders();
                    headers.CacheControl = new CacheControlHeaderValue
                    {
                        NoCache = env.IsDevelopment(),
                        NoStore = env.IsDevelopment(),
                        Public = env.IsDevelopment(),
                        MaxAge = TimeSpan.FromDays(env.IsDevelopment() ? -1 : 60)
                    };
                }
            });

            #endregion

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Configure the application database
        /// </summary>
        /// <param name="services">Service collection</param>
        private void ConfigureDatabase(IServiceCollection services)
        {
            services.AddScoped<DbContext, PetanquePlanningDbContext>();

            var appSettingsSection = this.Configuration.GetSection("DatabaseSettings");
            services.Configure<DatabaseSettings>(appSettingsSection);
            // Allow update the appsettings file
            services.ConfigureWritable<DatabaseSettings>(appSettingsSection);

            var appSettings = appSettingsSection.Get<DatabaseSettings>();
            services.AddDbContext<PetanquePlanningDbContext>(
                options => options.UseSqlServer(
                    appSettings.ConnectionStrings.First(cs => cs.Name == appSettings.UsedConnectionString)
                        .ConnectionString,
                    x => x.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name)));
        }

        /// <summary>
        /// Configure the authentication in the app
        /// </summary>
        /// <param name="services">Service collection</param>
        private void ConfigureAuthentication(IServiceCollection services)
        {
            const string authUrl = "/api/accounts/login";
            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ClockSkew = TimeSpan.Zero,
                        ValidateLifetime = true,
                        ValidateIssuer = true,
                        ValidIssuer = this.Configuration["Security:Token:Issuer"],
                        ValidateAudience = true,
                        ValidAudience = this.Configuration["Security:Token:Audience"],
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey =
                            new SymmetricSecurityKey(
                                Encoding.UTF8.GetBytes(this.Configuration["Security:Token:SecretKey"]))
                    };
                });
        }

        /// <summary>
        /// Add identity to the application
        /// </summary>
        /// <param name="services">Service collection</param>
        private static void AddIdentity(IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
                {
                    //Password rules
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 0;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequiredUniqueChars = 0;
                })
                .AddEntityFrameworkStores<PetanquePlanningDbContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromDays(1);

                options.LoginPath = "/api/accounts/login";
                options.AccessDeniedPath = options.LoginPath;
                options.SlidingExpiration = true;
                options.Events.OnRedirectToLogin = context =>
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    return Task.CompletedTask;
                };
            });
        }

        /// <summary>
        /// Add the repositoties to the DI
        /// </summary>
        /// <param name="services"></param>
        private static void AddBusinessRepositories(IServiceCollection services)
        {
            #region Location

            services.AddScoped<IRegionRepository, RegionRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();

            #endregion

            #region Identity

            services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
            services.AddScoped<IApplicationRoleRepository, ApplicationRoleRepository>();

            #endregion

            #region Core

            services.AddScoped<ICompetitionRepository, CompetitionRepository>();
            services.AddScoped<IClubRepository, ClubRepository>();

            #endregion
        }

        /// <summary>
        /// Add the services to the DI
        /// </summary>
        /// <param name="services"></param>
        private static void AddBusinessServices(IServiceCollection services)
        {
            #region Location

            services.AddScoped<RegionService>();
            services.AddScoped<DepartmentService>();

            #endregion

            #region Identity

            services.AddScoped<AccountService>();
            services.AddScoped<ApplicationUserService>();
            services.AddScoped<ApplicationRoleService>();

            #endregion

            #region Core

            services.AddScoped<CompetitionService>();
            services.AddScoped<ClubService>();

            #endregion

            //Add all services
            // services.AddAllServices(
            //     assemblies: Assembly.GetExecutingAssembly().GetReferencedAssemblies().Select(Assembly.Load).ToList(),
            //     baseServiceTypes: new List<Type>() {typeof(BaseService), typeof(BaseService<,>)});
        }

        #endregion
    }
}