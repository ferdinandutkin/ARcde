using Auto.Interfaces;
using Data.Serialization;

namespace Data.Repository;

public class FileBasedSerializationRepository<T> : FileBasedRepository<T> where T : class, IEntity
{
    private readonly ISerializer<T[]> _serializer;

    public FileBasedSerializationRepository(string basePath, string tableName, string extension,
        ISerializer<T[]> serializer) : base(basePath, tableName)
    {
        
        Extension = extension;
        _serializer = serializer;
    }

    public FileBasedSerializationRepository(string tableName, string extension,
        ISerializer<T[]> serializer) : base(tableName)
    {

        Extension = extension;
        _serializer = serializer;
    }

    protected override string Extension
    {
        get;
    }
    
    protected override void LoadDataFromFile(HashSet<T> container) => Cache = new(_serializer.Deserialize(File.ReadAllText(DataFile)));

    public override void SaveChanges() => File.WriteAllText(DataFile, _serializer.Serialize(Cache.ToArray()));
}