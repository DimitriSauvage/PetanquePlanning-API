using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DimitriSauvageTools.Application.Abstractions;
using DimitriSauvageTools.Application.DTOs;
using DimitriSauvageTools.Helpers;
using DimitriSauvageTools.Typescript.Generator;

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
                    .Where(x => x.FullName.Contains(nameof(PetanquePlanning)) ||
                                x.FullName.Contains(nameof(DimitriSauvageTools)))
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
                @"C:\Users\dimit\Github\PetanquePlanning\Models\generated.ts");
        }
    }
}