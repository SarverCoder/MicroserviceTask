using Microsoft.EntityFrameworkCore;
using ProductService.DataAccess.Entities;

namespace ProductService.DataAccess;

public class ProductDbContext : DbContext
{

    public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }


    

}
