using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Tools.Typescript.Generator;

namespace GenerateTypeScriptClasses
{
    public class Program
    {
        static void Main(string[] args)
        {
            var assemblies =
                Assembly.GetCallingAssembly().GetReferencedAssemblies().Select(Assembly.Load).ToList();
            
            new TypeScriptGenerator().GenerateTypeScriptModels(assemblies);
        }
    }
}