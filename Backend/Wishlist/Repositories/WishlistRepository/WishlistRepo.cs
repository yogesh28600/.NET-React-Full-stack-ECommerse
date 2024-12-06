using Wishlist.Context;
using Wishlist.Models;

namespace Wishlist.Repositories;
public class WishlistRepo : IWishlistRepo
{
    private readonly WishlistContext _context;
    public WishlistRepo(WishlistContext context) => _context = context;
    public async Task<ShoppingWishlist> AddItemToWishlist(Guid wishlistId, WishlistItem item)
    {
        try
        {
            var wishlist = await GetWishlist(wishlistId);
            if (wishlist == null) return null;
            wishlist.items.Add(item);
            await _context.SaveChangesAsync();
            return wishlist;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception in WishlistRepo/AddItemToWishlist: {ex.Message}");
            return null;
        }
    }
    public async Task<ShoppingWishlist> CreateWishlist(Guid userId)
    {
        try
        {
            var wishlist = new ShoppingWishlist()
            {
                userId = userId
            };
            var created_wishlist = await _context.shoppingWishlists.AddAsync(wishlist);
            await _context.SaveChangesAsync();
            return created_wishlist.Entity;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception in WishlistRepo/CreateWishlist: {ex.Message}");
            return null;
        }
    }
    public async Task<ShoppingWishlist> GetWishlist(Guid id)
    {
        try
        {
            return await _context.shoppingWishlists.FindAsync(id);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception in WishlistRepo/GetWishlist: {ex.Message}");
            return null;
        }
    }
    public async Task<ShoppingWishlist> DeleteWishlist(Guid wishlistId)
    {
        try
        {
            var wishlist = await GetWishlist(wishlistId);
            if (wishlist == null) return null;
            var deleted_wishlist = _context.shoppingWishlists.Remove(wishlist);
            await _context.SaveChangesAsync();
            return deleted_wishlist.Entity;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception in WishlistRepo/DeleteWishlist: {ex.Message}");
            return null;
        }
    }
    public async Task<ShoppingWishlist> RemoveItemFromWishlist(Guid wishlistId, Guid itemId)
    {
        try
        {
            var wishlist = await GetWishlist(wishlistId);
            if (wishlist == null) return null;
            var item = wishlist.items.First(x => x.itemId == itemId);
            if (item == null) return null;
            wishlist.items.Remove(item);
            await _context.SaveChangesAsync();
            return wishlist;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception in WishlistRepo/RemoveItemFromWishlist: {ex.Message}");
            return null;
        }
    }
}