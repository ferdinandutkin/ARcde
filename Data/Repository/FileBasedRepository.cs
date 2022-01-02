using Auto.Interfaces;

namespace Data.Repository;

public abstract class FileBasedRepository<T> : IRepository<T>
   where T : class
{
    private HashSet<T> _cache;

 
    protected virtual string BasePath { get; set; }
    protected virtual string TableName { get; set; }

    protected virtual string DataFile => Path.Combine(BasePath, $"{TableName}.{Extension}");

    protected abstract string Extension { get; }

    public FileBasedRepository(string basePath, string tableName)
    {
        BasePath = basePath;
        TableName = tableName;
    }


    public FileBasedRepository(string tableName) : this(Directory.GetCurrentDirectory(), tableName)
    {

    }


    protected HashSet<T> Cache
    {
        get
        {
            if (_cache is null)
            {
                _cache = new HashSet<T>();
                if (File.Exists(DataFile))
                    LoadDataFromFile(_cache);
            }
            return _cache;
        }
        set => _cache = value;
    }

    protected abstract void LoadDataFromFile(HashSet<T> container);

    public virtual IEnumerable<T> All() => Cache;


    public virtual T? Add(T t)
    {
        if (Cache.Contains(t))
            return null;

        if (Cache.Add(t))
        {
            SaveChanges();
            return t;      
        }

        return null;
    }

    public virtual void Delete(T t)
    {
        if (Cache.Contains(t))
        {
            Cache.Remove(t);
            SaveChanges();
        }
    }


    public virtual T Update(T t)
    {
        Cache.Remove(t);
        Cache.Add(t);
        SaveChanges();
        return t;
    }


    public abstract void SaveChanges();


}
