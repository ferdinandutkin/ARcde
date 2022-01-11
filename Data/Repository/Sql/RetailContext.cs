using Auto.Product;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository.Sql;

public class DBContext :  DbContext
{
    public DbSet<CarProduct> Audi { get; set; }
    
    public DbSet<CarProduct> BMW { get; set; }
}