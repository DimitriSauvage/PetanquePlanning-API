using System;
using System.Linq;
using System.Reflection;
using System.Text;
using AutoMapper;
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
using Tools.Infrastructure.Settings;

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
            #region Database config

            this.ConfigureDatabase(services);

            #endregion

            #region Configure authentication

            this.ConfigureAuthentication(services);

            #endregion

            #region AutoMapper

            services.AddAutoMapper(typeof(Startup));

            #endregion

            #region Configure session

            services.AddSession(options =>
            {
                options.Cookie.Expiration = TimeSpan.FromDays(30);
                options.Cookie.Name = ".PetanquePlanning.Session";
                options.IdleTimeout = TimeSpan.FromHours(2);
            });

            #endregion

            #region Configure DI fot the business elements

            this.AddBusinessRepositories(services);
            this.AddBusinessServices(services);

            #endregion

            #region Identity

            this.AddIdentity(services);

            #endregion

            //services.AddControllers();
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

            //app.UseHttpsRedirection();
            app.UseAuthentication();

            //app.UseRouting();
            app.UseAuthorization();


            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
        }

        #endregion

        #region Private methods

        private void AddIdentity(IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 0;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequiredUniqueChars = 0;
                })
                .AddEntityFrameworkStores<PetanquePlanningDbContext>()
                .AddDefaultTokenProviders();
        }

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
            var authUrl = "/api/accounts/login";
            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                })
                .AddCookie(options => options.LoginPath = new PathString(authUrl))
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

            services.ConfigureApplicationCookie(options => options.LoginPath = new PathString(authUrl));
        }

        /// <summary>
        /// Add the repositoties to the DI
        /// </summary>
        /// <param name="services"></param>
        private void AddBusinessRepositories(IServiceCollection services)
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
        /// Add the repositoties to the DI
        /// </summary>
        /// <param name="services"></param>
        private void AddBusinessServices(IServiceCollection services)
        {
            #region Location

            services.AddScoped<RegionService, RegionService>();
            services.AddScoped<DepartmentService, DepartmentService>();

            #endregion

            #region Identity

            services.AddScoped<ApplicationUserService, ApplicationUserService>();
            services.AddScoped<ApplicationRoleService, ApplicationRoleService>();
            services.AddScoped<AccountService, AccountService>();

            #endregion

            #region Core

            //To enable DI
            services.AddScoped<CompetitionService, CompetitionService>();
            services.AddScoped<ClubService, ClubService>();

            #endregion
        }

        #endregion
    }
}