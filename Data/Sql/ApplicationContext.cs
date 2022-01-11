using Microsoft.EntityFrameworkCore;

namespace Data.Sql;

public class ApplicationContext : DbContext
{
    private readonly string _databaseName;

    public ApplicationContext(string databaseName)
    {
        _databaseName = databaseName;
    }
    public DbSet<CarProductDataStorage> Products { get; set; }

    public DbSet<CarProductDataStorage.CarDataStorage> Cars { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            $@"Server=localhost;Initial Catalog={_databaseName.ToLower()};Integrated Security=true;");

    }
}