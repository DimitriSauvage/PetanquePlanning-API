using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace PetanquePlanningApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                    webBuilder
                        .UseStartup<Startup>()
                        .ConfigureAppConfiguration(SetupConfiguration)
                );

        /// <summary>
        /// Set the configuration of the application
        /// </summary>
        /// <param name="context">App context</param>
        /// <param name="configBuilder">Config builder</param>
        private static void SetupConfiguration(WebHostBuilderContext context, IConfigurationBuilder configBuilder)
        {
            var env = context.HostingEnvironment;

            configBuilder.SetBasePath(env.ContentRootPath)
                .AddEnvironmentVariables()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile("appsettings.connectionstrings.json", optional: false, reloadOnChange: true);
            configBuilder.Build();
        }
    }
}