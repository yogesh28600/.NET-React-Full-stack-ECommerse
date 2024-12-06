using Cart.DTO;
using Cart.Models;
using Cart.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Cart.Controllers;

[ApiController]
[Route("yk-techtown/api")]
public class CartController : ControllerBase
{
    private readonly ICartRepo _cartRepo;
    public CartController(ICartRepo cartRepo) => _cartRepo = cartRepo;
    [HttpPost("carts{id}")]
    public async Task<IActionResult> CreateCart([FromRoute] Guid id)
    {
        try
        {
            var shoppingCart = new ShoppingCart()
            {
                userId = id
            };
            var cart = await _cartRepo.CreateCart(shoppingCart);
            if (cart == null) return BadRequest(new { error = "something went wrong while creating cart..." });
            return Ok(cart);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception in CartController/CreateCart: {ex.Message}");
            return BadRequest(new { error = "something went wrong while creating cart..." });
        }
    }
    [HttpPost("carts/add-item/{id}")]
    public async Task<IActionResult> AddItemToCart([FromRoute] Guid id, [FromBody] AddItemToCartDTO cartItemDTO)
    {
        try
        {
            var cartItem = new CartItem()
            {
                itemId = cartItemDTO.itemId,
                quantity = cartItemDTO.quantity,
                itemPrice = cartItemDTO.itemPrice
            };
            var cart = await _cartRepo.AddItemToCart(id, cartItem);
            if (cart == null) return BadRequest(new { error = "something went wrong while adding item to cart..." });
            return Ok(cart);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception in CartController/AddItemToCart: {ex.Message}");
            return BadRequest(new { error = "something went wrong while adding item to cart..." });
        }
    }
    [HttpPost("carts/clear-cart/{id}")]
    public async Task<IActionResult> ClearCart([FromRoute] Guid id)
    {
        try
        {
            var cart = await _cartRepo.ClearCart(id);
            if (cart == null) return BadRequest(new { error = "something went wrong while deleting items from cart..." });
            return Ok(cart);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception in CartController/ClearCart: {ex.Message}");
            return BadRequest(new { error = "something went wrong while deleting items from cart..." });
        }
    }
    [HttpGet("carts/{id}")]
    public async Task<IActionResult> GetCart([FromRoute] Guid id)
    {
        try
        {
            var cart = await _cartRepo.GetCart(id);
            if (cart == null) return BadRequest(new { error = "something went wrong while fetching cart..." });
            return Ok(cart);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception in CartController/GetCart: {ex.Message}");
            return BadRequest(new { error = "something went wrong while fetching cart..." });
        }
    }
    [HttpGet("carts/user/{userid}")]
    public async Task<IActionResult> GetCartByUser([FromRoute] Guid userId)
    {
        try
        {
            var cart = await _cartRepo.GetCartByUser(userId);
            if (cart == null) return BadRequest(new { error = "something went wrong while fetching cart..." });
            return Ok(cart);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception in CartController/GetCartByUser: {ex.Message}");
            return BadRequest(new { error = "something went wrong while fetching cart..." });
        }
    }
    [HttpPost("carts/remove-item/{cartId}/{itemId}")]
    public async Task<IActionResult> RemoveCartItem([FromRoute] Guid itemId, [FromRoute] Guid cartId)
    {
        try
        {
            var cart = await _cartRepo.RemoveItemFromCart(cartId, itemId);
            if (cart == null) return BadRequest(new { error = "something went wrong while deleting item from cart..." });
            return Ok(cart);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception in CartController/RemoveItemFromCart: {ex.Message}");
            return BadRequest(new { error = "something went wrong while deleting item from cart..." });
        }
    }
    [HttpPost("carts/update-item-quantity/{cartId}/{itemId}/{qty}")]
    public async Task<IActionResult> UpdateCartItemQty([FromRoute] Guid itemId, [FromRoute] Guid cartId, int qty)
    {
        try
        {
            var cart = await _cartRepo.UpdateQuantity(cartId, itemId, qty);
            if (cart == null) return BadRequest(new { error = "something went wrong while updating item quantity..." });
            return Ok(cart);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception in CartController/UpdateQuantity: {ex.Message}");
            return BadRequest(new { error = "something went wrong while updating item quantity..." });
        }
    }
    [HttpDelete("carts/{cartId}")]
    public async Task<IActionResult> DeleteCart([FromRoute] Guid cartId)
    {
        try
        {
            var cart = await _cartRepo.DeleteCart(cartId);
            if (cart == null) return BadRequest(new { error = "something went wrong while deleting cart..." });
            return Ok(cart);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception in CartController/DeleteCart: {ex.Message}");
            return BadRequest(new { error = "something went wrong while deleting cart..." });
        }
    }

}
