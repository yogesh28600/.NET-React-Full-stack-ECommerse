using Cart.Context;
using Cart.Models;
using Microsoft.EntityFrameworkCore;

namespace Cart.Repositories;

public class CartRepo : ICartRepo
{
    private readonly CartContext _context;
    public CartRepo(CartContext context) => _context = context;

    public async Task<ShoppingCart> AddItemToCart(Guid cartId, CartItem item)
    {
        try
        {
            var cart = await _context.Carts.FindAsync(cartId);
            if (cart == null) return null;
            var cartItem = cart.items.First(x => x.itemId == item.itemId);
            if (cartItem != null)
            {
                cartItem.quantity += item.quantity;
                cart.total = cart.items.Sum(i => i.itemPrice * i.quantity);
                await _context.SaveChangesAsync();
                return cart;
            }
            cart.items.Add(item);
            cart.total = cart.items.Sum(i => i.itemPrice * i.quantity);
            await _context.SaveChangesAsync();
            return cart;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception in CartRepo/AddItemToCart: {ex.Message}");
            return null;
        }
    }

    public async Task<ShoppingCart> ClearCart(Guid cartId)
    {
        try
        {
            var cart = await _context.Carts.FindAsync(cartId);
            if (cart == null) return null;
            cart.items.Clear();
            cart.total = cart.items.Sum(i => i.itemPrice);
            await _context.SaveChangesAsync();
            return cart;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception in CartRepo/ClearCart: {ex.Message}");
            return null;
        }
    }

    public async Task<ShoppingCart> CreateCart(ShoppingCart shoppingCart)
    {
        try
        {
            var cart = await _context.Carts.AddAsync(shoppingCart);
            await _context.SaveChangesAsync();
            return cart.Entity;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception in CartRepo/CreateCart: {ex.Message}");
            return null;
        }
    }

    public async Task<ShoppingCart> DeleteCart(Guid cartId)
    {
        try
        {
            var cart = await GetCart(cartId);
            if (cart == null) return null;
            _context.Carts.Remove(cart);
            await _context.SaveChangesAsync();
            return cart;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception in CartRepo/DeleteCart: {ex.Message}");
            return null;
        }
    }

    public async Task<ShoppingCart> GetCart(Guid id)
    {
        try
        {
            return await _context.Carts.FindAsync(id);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception in CartRepo/GetCart: {ex.Message}");
            return null;
        }
    }

    public async Task<ShoppingCart> GetCartByUser(Guid userId)
    {
        try
        {
            return await _context.Carts.FirstAsync(x => x.userId == userId);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception in CartRepo/GetCartByUser: {ex.Message}");
            return null;
        }
    }

    public async Task<ShoppingCart> RemoveItemFromCart(Guid cartId, Guid itemId)
    {
        try
        {
            var cart = await GetCart(cartId);
            if (cart == null) return null;
            var item = cart.items.FirstOrDefault(x => x.itemId == itemId);
            if (item == null) return null;
            cart.items.Remove(item);
            cart.total = cart.items.Sum(x => x.itemPrice * x.quantity);
            await _context.SaveChangesAsync();
            return cart;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception in CartRepo/RemoveItemFromCart: {ex.Message}");
            return null;
        }
    }

    public async Task<ShoppingCart> UpdateQuantity(Guid cartId, Guid itemId, int quantity)
    {
        try
        {
            var cart = await GetCart(cartId);
            if (cart == null) return null;
            var item = cart.items.FirstOrDefault(x => x.itemId == itemId);
            if (item == null) return null;
            item.quantity = quantity;
            cart.total = cart.items.Sum(x => x.itemPrice * x.quantity);
            await _context.SaveChangesAsync();
            return cart;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception in CartRepo/UpdateQuantity: {ex.Message}");
            return null;
        }
    }
}