using Auto.Interfaces;
using Auto.Product;
using AutoMapper;
using Data.Repository.Builder;
using Data.Serialization.Json;
using Data.Serialization.Xml;
using Shared;

namespace Data.Repository;

public class RepositoryFactory : IFactory<string, IRepository<CarProduct>>
{
    private readonly StorageConfiguration[] _configurations;

    private static readonly MapperConfiguration _config = new(cfg =>
    {
        cfg.CreateMap<CarProductDataStorage.CarDataStorage, Car>().ConstructUsing(xmlCar => new Car(xmlCar.Mark, xmlCar.Model));
        cfg.CreateMap<Car, CarProductDataStorage.CarDataStorage>();
        cfg.CreateMap<CarProductDataStorage, CarProduct>().ConstructUsing((xmlCarProduct, res) => new CarProduct(res.Mapper.Map<Car>(xmlCarProduct.Subject), xmlCarProduct.Price, xmlCarProduct.Count));
        cfg.CreateMap<CarProduct, CarProductDataStorage>();
    });

    private static readonly IMapper _mapper = _config.CreateMapper();
    public RepositoryFactory(IEnumerable<StorageConfiguration> configurations) => _configurations = configurations.ToArray();

    private static IRepository<CarProduct> CreateXml(string officeName)
    {
        return new RepositoryBuilder<CarProductDataStorage>()
             .FileBased()
             .WithName(officeName)
             .WithExtension("xml")
             .WithSerializer<XmlSerializer<CarProductDataStorage[]>>()
             .WithMapper<CarProductDataStorage, CarProduct>(_mapper)
             .Build();
    }


    private static IRepository<CarProduct> CreateJson(string officeName)
    {
        return new RepositoryBuilder<CarProductDataStorage>()
            .FileBased()
            .WithName(officeName)
            .WithExtension("json")
            .WithSerializer<JsonSerializer<CarProductDataStorage[]>>()
            .WithMapper<CarProductDataStorage, CarProduct>(_mapper)
            .Build();
    }

    private static IRepository<CarProduct> CreateSql(string officeName)
    {
        return new RepositoryBuilder<CarProductDataStorage>()
            .Sql()
            .WithName(officeName)
            .WithMapper<CarProductDataStorage, CarProduct>(_mapper)
            .Build();

    }


    public IRepository<CarProduct>? CreateInstance(string userRequest)
    {
        var config = _configurations.First(configuration => configuration.Office == userRequest);
        return config.Type switch
        {
            StorageType.Json => CreateJson(userRequest),
            StorageType.Xml => CreateXml(userRequest),
            StorageType.Sql => CreateSql(userRequest),
            _ => throw new ArgumentOutOfRangeException()
        };

    }
}