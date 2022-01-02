using System.Reflection;

namespace Shared.Reflection;

public class ImplementationLoader<T>
{
    public IEnumerable<Type> LoadImplementations(IEnumerable<string> assemblyPathsToScan)
        => assemblyPathsToScan.SelectMany(LoadImplementations);

    public IEnumerable<Type> LoadImplementations(string assemblyPathToScan)
        => LoadImplementations(Assembly.LoadFrom(assemblyPathToScan));

    public IEnumerable<Type> LoadImplementations(IEnumerable<Assembly> assembliesToScan) 
        => assembliesToScan.SelectMany(LoadImplementations);

    public IEnumerable<Type> LoadImplementations(Assembly assemblyToScan)
    {
        var interfaceType = typeof(T);

        if (!interfaceType.IsInterface)
        {
            throw new InvalidOperationException($"provided type must be an interface; {interfaceType.Name} is not an interface");
        }

        var implementations = assemblyToScan.ExportedTypes
            .Where(type => interfaceType.IsAssignableFrom(type) && !type.IsInterface);

        var defaultConstructableImpementations = implementations
            .Where(ReflectionExtensions.HasParameterlessConstructor);

        return defaultConstructableImpementations;
    }


}
