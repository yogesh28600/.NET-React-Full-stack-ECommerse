using Microsoft.EntityFrameworkCore;
using Wishlist.Models;

namespace Wishlist.Context;
public class WishlistContext : DbContext
{
    public WishlistContext(DbContextOptions<WishlistContext> options) : base(options)
    {

    }
    public DbSet<ShoppingWishlist> shoppingWishlists { get; set; }
}