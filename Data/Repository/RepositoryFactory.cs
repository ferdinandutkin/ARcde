using Auto.Interfaces;
using Auto.Product;
using Data.Repository.Builder;
using Data.Serialization.Json;
using Data.Serialization.Xml;
using Shared;
using User;

namespace Data.Repository;

public class RepositoryFactory : IFactory<string, IRepository<CarProduct>>
{
    private readonly StorageConfiguration[] _configurations;

    public RepositoryFactory(IEnumerable<StorageConfiguration> configurations) => _configurations = configurations.ToArray();

    private static IRepository<CarProduct> CreateXml(string officeName)
    {
        return new RepositoryBuilder<CarProduct>()
            .FileBased()
            .WithName(officeName)
            .WithExtension("xml")
            .WithSerializer<CarProductXmlSerializer>()
            .Build();
    }


    private static IRepository<CarProduct> CreateJson(string officeName)
    {
        return new RepositoryBuilder<CarProduct>()
            .FileBased()
            .WithName(officeName)
            .WithExtension("json")
            .WithSerializer<CarProductJsonSerializer>()
            .Build();
    }
    
    
    public IRepository<CarProduct>? CreateInstance(string officeName)
    {
        var config = _configurations.First(configuration => configuration.Office == officeName);
        return config.Type switch
        {
            StorageType.Json => CreateJson(officeName),
            StorageType.Xml => CreateXml(officeName),
            StorageType.Sql => CreateJson(officeName),
            _ => throw new ArgumentOutOfRangeException()
        };

    }
}