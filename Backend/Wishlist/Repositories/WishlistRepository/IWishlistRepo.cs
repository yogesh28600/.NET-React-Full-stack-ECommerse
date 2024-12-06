using Wishlist.Models;

namespace Wishlist.Repositories;
public interface IWishlistRepo
{
    public Task<ShoppingWishlist> CreateWishlist(Guid userId);
    public Task<ShoppingWishlist> DeleteWishlist(Guid wishlistId);
    public Task<ShoppingWishlist> GetWishlist(Guid id);
    public Task<ShoppingWishlist> AddItemToWishlist(Guid wishlistId, WishlistItem item);
    public Task<ShoppingWishlist> RemoveItemFromWishlist(Guid wishlistId, Guid itemId);
}