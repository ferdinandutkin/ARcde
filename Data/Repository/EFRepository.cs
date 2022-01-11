using Auto.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository;

public class EFRepository<T> : IRepository<T> where T : class
{
    protected DbSet<T> Entities => DbContext.Set<T>();
    protected DbContext DbContext { get; }
    
    public EFRepository(DbContext dbContext) => DbContext = dbContext;

    public virtual T Add(T value)
    {
        Entities.Add(value);
        DbContext.SaveChanges();
        return value;
    }

    public virtual IEnumerable<T> All() => Entities.AsNoTracking();
    
    
    public virtual T Update(T value)
    {
        Entities.Update(value);
        DbContext.SaveChanges();
        return value;
    }

    public void Delete(T value)
    {
        Entities.Remove(value);
        DbContext.SaveChanges();
    }
    
}