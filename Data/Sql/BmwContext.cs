using Microsoft.EntityFrameworkCore;

namespace Data.Sql;

public class BmwContext :  DbContext
{
    public DbSet<CarProductDataStorage> Products { get; set; }

    public DbSet<CarProductDataStorage.CarDataStorage> Cars { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            $@"Server=localhost;Initial Catalog=bmw;Integrated Security=true;");


    }
}