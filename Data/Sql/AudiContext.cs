using Microsoft.EntityFrameworkCore;

namespace Data.Sql;

public class AudiContext :  DbContext
{
    public DbSet<CarProductDataStorage> Products { get; set; }

    public DbSet<CarProductDataStorage.CarDataStorage> Cars { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            @"Server=localhost;Initial Catalog=audi;Integrated Security=true;");

    }
}