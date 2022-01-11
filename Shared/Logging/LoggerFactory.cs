using System.Reflection;
using Microsoft.Extensions.Logging;
using Shared.Reflection;

namespace Shared.Logging;

public class LoggerFactory
{
    private readonly ImplementationLoader<ILogger> _implementationLoader = new();
    public ILogger FromAssembly(string path) => FromAssembly(Assembly.LoadFrom(path));

    public ILogger FromAssembly(Assembly assembly)
    {
        var implementations = _implementationLoader
            .LoadImplementations(assembly)
            .Select(implementation => Activator.CreateInstance(implementation, null))
            .Cast<ILogger>();

        return new CompositeLogger(implementations);
    }

    public ILogger FromConfigurations(IEnumerable<LoggerConfiguration> configurations) =>
        new CompositeLogger(configurations.Select(FromConfiguration));

    public ILogger FromConfiguration(LoggerConfiguration configuration)
    {
        var (assemblyPath, level) = configuration;
        var logger = FromAssembly(assemblyPath);
        var leveledLogger = new MinLogLevelDecorator(logger, level);
        return leveledLogger;
    }
    public ILogger FromAssemblies(IEnumerable<string> assemblyPathsToScan) => new CompositeLogger(assemblyPathsToScan.Select(FromAssembly));

    public ILogger FromAssemblies(IEnumerable<Assembly> assembliesToScan) => new CompositeLogger(assembliesToScan.Select(FromAssembly));
}
