namespace Cart.DTO;
public class AddItemToCartDTO
{
    public Guid itemId { get; set; }
    public int quantity { get; set; }
    public float itemPrice { get; set; }
}