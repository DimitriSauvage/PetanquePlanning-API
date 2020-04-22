using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Tools.Application.Abstractions;
using Tools.Application.DTOs;
using Tools.Helpers;
using Tools.Typescript.Generator;

namespace PetanquePlanningApi
{
    public static class TypescriptGenerator
    {
        /// <summary>
        /// Generate typescript files
        /// </summary>
        public static void GenerateTypescript()
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