using Data.Serialization;
using Auto.Interfaces;

namespace Data.Repository.Builder;

public class FileBasedRepositoryBuilder<T> : IRepositoryBuilder<T> where T : class, IEntity
{
    private string? _basePath;
    private string? _name;
    private string? _extension;
    private ISerializer<T[]>? _serializer;

    public FileBasedRepositoryBuilder<T> WithExtension(string extension)
    {
        _extension = extension;
        return this;
    }

    public FileBasedRepositoryBuilder<T> WithSerializer(ISerializer<T[]> serializer)
    {
        _serializer = serializer;
        return this;
    }

    public FileBasedRepositoryBuilder<T> WithSerializer<TSerializer>() where TSerializer : ISerializer<T[]>, new()
    {
        _serializer = new TSerializer();
        return this;
    }


    public FileBasedRepositoryBuilder<T> WithName(string name)
    {
        _name = name;
        return this;
    }

    public FileBasedRepositoryBuilder<T> WithBasePath(string path)
    {
        _basePath = path;
        return this;
    }


    public IRepository<T> Build()
    {
        var basePath = _basePath ?? Directory.GetCurrentDirectory();
        var name = _name ?? "data";
        string extension = _extension ?? "txt";

        return new FileBasedSerializationRepository<T>(basePath, name,
           extension, _serializer);
    }
     

}