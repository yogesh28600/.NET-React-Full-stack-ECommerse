using Microsoft.EntityFrameworkCore;
using ProductsCatalog.Models;

namespace ProductsCatalog.Context;

public class ProductDbContext : DbContext
{
    public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
    {

    }
    public DbSet<Product> Products { get; set; }
}