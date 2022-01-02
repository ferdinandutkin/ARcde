using Data.Serialization;

namespace Data.Repository.Builder;

public class FileBasedRepositoryBuilder<T> where T : class
{
    private string? _basePath;
    private string? _name;
    private string? _extension;
    private ISerializer<T[]> _serializer;

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
        => new FileBasedSerializationRepository<T>(_basePath ?? Directory.GetCurrentDirectory(), _name ?? "data",
            _extension ?? "txt", _serializer);

}