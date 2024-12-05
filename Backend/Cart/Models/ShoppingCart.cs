namespace Cart.Models;
public class ShoppingCart
{
    public Guid Id { get; set; }
    public Guid userId { get; set; }
    public List<CartItem> items { get; set; } = new List<CartItem>();
    public float total { get; set; }
}