namespace Wishlist.Models;
public class ShoppingWishlist
{
    public Guid id { get; set; }
    public Guid userId { get; set; }
    public List<WishlistItem> items { get; set; } = new List<WishlistItem>();
}