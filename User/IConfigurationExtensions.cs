using Microsoft.Extensions.Configuration;
using Shared.Logging;

namespace User;

public static class IConfigurationExtensions
{

    public static IEnumerable<LoggerConfiguration> GetLoggerConfigurations(this IConfiguration configuration)
        => configuration.GetSection("Loggers").Get<LoggerConfiguration[]>();

}
