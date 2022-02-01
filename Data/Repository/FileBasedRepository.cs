using Auto.Interfaces;

namespace Data.Repository;

public abstract class FileBasedRepository<T> : IRepository<T>
   where T : class, IEntity
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


    public virtual T? Add(T value)
    {
        if (value.Id == 0)
        {
            if (Cache.All(el => el.Id != 0))
            {
                Cache.Add(value);
                SaveChanges();
                return value;
            }
         
        }
        

        if (value.Id != 0 && Cache.Any(el => el.Id == value.Id))
        {
            return null;
        }

        var newId = Cache.Max(el => el.Id) + 1;
        value.Id = newId;
        Cache.Add(value);
        SaveChanges();
        return value;

    }

    public virtual void Remove(T value)
    {
        var found = Cache.FirstOrDefault(el => el.Id == value.Id);
        if (found is not null)
        {
            Cache.Remove(found);
            SaveChanges();
        }
    }


    public virtual T Update(T value)
    {
        var found = Cache.FirstOrDefault(el => el.Id == value.Id);
        if (found is not null)
        {
            Cache.Remove(found);
            Cache.Add(value);
            SaveChanges();
            return value;
        }
        return null;
      
    }


    public abstract void SaveChanges();


}
