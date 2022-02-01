using Microsoft.Extensions.Configuration;


namespace Shared;

public static class IConfigurationExtensions
{

    public static IEnumerable<StorageConfiguration> GetStorageConfigurations(this IConfiguration configuration)
        => configuration.GetSection("Storage").Get<StorageConfiguration[]>();

}
