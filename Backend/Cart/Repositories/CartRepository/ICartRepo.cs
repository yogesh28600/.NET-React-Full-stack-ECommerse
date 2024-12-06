using Cart.Models;

namespace Cart.Repositories;
public interface ICartRepo
{
    public Task<ShoppingCart> CreateCart(ShoppingCart userId);
    public Task<ShoppingCart> GetCart(Guid id);
    public Task<ShoppingCart> GetCartByUser(Guid userId);
    public Task<ShoppingCart> AddItemToCart(Guid cartId, CartItem item);
    public Task<ShoppingCart> RemoveItemFromCart(Guid cartId, Guid itemId);
    public Task<ShoppingCart> UpdateQuantity(Guid cartId, Guid itemId, int quantity);
    public Task<ShoppingCart> ClearCart(Guid cartId);
    public Task<ShoppingCart> DeleteCart(Guid cartId);
}