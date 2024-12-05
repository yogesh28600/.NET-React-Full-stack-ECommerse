namespace ProductsCatalog.Models;
public class Product
{
    public Guid id { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public float price { get; set; }
    public string category { get; set; }
    public string brand { get; set; }
    public List<Image> images { get; set; } = new List<Image>();
    public DateTime createdAt { get; set; }
}