using Auto.Product;
using Auto.Serialization.Json;
using Auto.Serialization.Xml;
using Data;
using Data.Repository;
using Data.Repository.Builder;

namespace Auto.Repository;

internal static class BranchOfficeRepository
{
    private static IRepository<CarProduct> CreateXML(string officeName)
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
    public static IRepository<CarProduct> CreateInstance(string officeName)
        => CreateJson(officeName);

}
