using System.Reflection;

namespace System.Reflection.Extensions;

public static class AssemblyExtensions
{
    /// <summary>
    /// Method creates an object for a given type's name in an given assembly
    /// </summary>
    /// <param name="assembly">An assembly to look for a type defined by <paramref name="typeName"/></param>
    /// <param name="typeName">Name of type to be created object</param>
    /// <param name="isIncludeRef">Indication whether the creation will go into reference assemblies</param>
    /// <returns>Created object</returns>
    public static object? CreateObject(this Assembly assembly, string typeName, bool isIncludeRef = false)
    {
        var type = assembly.GetTypes().FirstOrDefault(e => e.Name == typeName);
        object? instance = null;

        //Creating an object of non-abstract type
        if (type != null && !type.IsAbstract)
        {
            instance = Activator.CreateInstance(type);
        }

        //Trying to create an object in any of reference assemblies of given assembly
        if (instance == null && isIncludeRef)
        {
            foreach (var assName in assembly.GetReferencedAssemblies())
            {
                var ass = Assembly.Load(assName);
                if (ass == null) continue;
                instance = CreateObject(ass, typeName, false);  //recursion
                if (instance != null && instance.GetType().IsClass) break;
            }
        }

        return instance;
    }
}
