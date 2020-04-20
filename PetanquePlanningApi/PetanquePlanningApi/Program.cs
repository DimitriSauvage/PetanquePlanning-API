using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Tools.Application.Abstractions;
using Tools.Application.DTOs;
using Tools.Helpers;
using Tools.Typescript.Generator;

namespace PetanquePlanningApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
#if DEBUG
            GenerateTypescript();
#endif
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

        /// <summary>
        /// Generate typescript files
        /// </summary>
        private static void GenerateTypescript()
        {
            var assemblies =
                Assembly
                    .GetExecutingAssembly()
                    .GetReferencedAssemblies()
                    .Where(x => x.FullName.Contains(nameof(PetanquePlanning)) || x.FullName.Contains(nameof(Tools)))
                    .Select(Assembly.Load)
                    .ToList();
            
            //Types to get
            IEnumerable<Type> searchedTypes = new List<Type>()
            {
                typeof(BaseDTO),
                typeof(EnumDTO<>),
                typeof(Enum),
            };

            var types = TypeHelper.GetImplementations(searchedTypes, assemblies);
            new TypeScriptGenerator().GenerateTypeScriptModels(types,
                @"C:\Users\dimit\Downloads\generated.ts");
        }
    }
}