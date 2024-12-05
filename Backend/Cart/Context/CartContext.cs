using Cart.Models;
using Microsoft.EntityFrameworkCore;

namespace Cart.Context;
public class CartContext : DbContext
{
    public CartContext(DbContextOptions<CartContext> options) : base(options)
    {
    }
    public DbSet<ShoppingCart> Carts { get; set; }
}