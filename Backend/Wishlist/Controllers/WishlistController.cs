using Microsoft.AspNetCore.Mvc;
using Wishlist.Models;
using Wishlist.Repositories;

namespace Wishlist.Controllers;

[ApiController]
[Route("yk-techtown/api")]
public class WishlistController : ControllerBase
{
    private readonly IWishlistRepo _wishlistRepo;
    public WishlistController(IWishlistRepo wishlistRepo) => _wishlistRepo = wishlistRepo;
    [HttpGet("wishlists/{id}")]
    public async Task<IActionResult> GetWishlist(Guid id)
    {
        try
        {
            var wishlist = await _wishlistRepo.GetWishlist(id);
            return wishlist == null ? NotFound(new { error = "wishlist not found" }) : Ok(wishlist);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception in WishlistController/GetWishlist: {ex.Message}");
            return BadRequest(new { error = "Something went wrong while fetching wishlist..." });
        }
    }
    [HttpPost("whishlists/{userId}")]
    public async Task<IActionResult> CreateWishlist(Guid userId)
    {
        try
        {
            var wishlist = await _wishlistRepo.CreateWishlist(userId);
            return wishlist == null ? BadRequest(new { error = "Something went wrong while creating wishlist..." }) : Ok(wishlist);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception in WishlistController/CreateWishlist: {ex.Message}");
            return BadRequest(new { error = "Something went wrong while creating wishlist..." });
        }
    }
    [HttpDelete("wishlists/{wishlistId}")]
    public async Task<IActionResult> DeleteWishList(Guid wishlistId)
    {
        try
        {
            var deleted_wishlist = await _wishlistRepo.DeleteWishlist(wishlistId);
            return deleted_wishlist == null ? BadRequest(new { error = "something went wrong while deleting wishlist..." }) : Ok(deleted_wishlist);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception in WishlistController/DeleteWishlist: {ex.Message}");
            return BadRequest(new { error = "something went wrong while deleting wishlist..." });
            throw;
        }
    }
    [HttpPost("wishlists/add-item/{wishlistId}")]
    public async Task<IActionResult> AddItemToWishlist(Guid wishlistId, WishlistItem item)
    {
        try
        {
            var wishlist = await _wishlistRepo.AddItemToWishlist(wishlistId, item);
            return wishlist == null ? BadRequest(new { error = "Something went wrong while adding item to wishlist..." }) : Ok(wishlist);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception in WishlistController/AddItemToWishlist: {ex.Message}");
            return BadRequest(new { error = "Something went wrong while adding item to wishlist..." });
        }
    }
    [HttpPost("wishlists/remove-item/{wishlistId}/{itemId}")]
    public async Task<IActionResult> RemoveItemToWishlist(Guid wishlistId, Guid itemId)
    {
        try
        {
            var wishlist = await _wishlistRepo.RemoveItemFromWishlist(wishlistId, itemId);
            return wishlist == null ? BadRequest(new { error = "Something went wrong while removing item to wishlist..." }) : Ok(wishlist);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception in WishlistController/RemoveItemFromWishlist: {ex.Message}");
            return BadRequest(new { error = "Something went wrong while removing item to wishlist..." });
        }
    }
}
