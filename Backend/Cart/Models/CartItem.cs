namespace Cart.Models;
public class CartItem
{
    public Guid itemId { get; set; }
    public int quantity { get; set; }
    public float itemPrice { get; set; }
}