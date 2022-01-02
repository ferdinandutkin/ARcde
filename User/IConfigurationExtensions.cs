using Microsoft.Extensions.Configuration;
using Shared;
using Shared.Logging;

namespace User;

public static class IConfigurationExtensions
{

    public static IEnumerable<LoggerConfiguration> GetLoggerConfigurations(this IConfiguration configuration)
        => configuration.GetSection("Loggers").Get<LoggerConfiguration[]>();
    
    public static IEnumerable<StorageConfiguration> GetStorageConfigurations(this IConfiguration configuration)
        => configuration.GetSection("Storage").Get<StorageConfiguration[]>();
    
    

}
