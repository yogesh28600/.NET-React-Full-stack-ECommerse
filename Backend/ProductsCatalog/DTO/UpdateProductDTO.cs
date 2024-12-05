using System.ComponentModel.DataAnnotations;
using ProductsCatalog.Models;

namespace ProductsCatalog.DTO;
public class UpdateProductDTO
{
    [Required]
    public Guid id { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public float price { get; set; }
    public string category { get; set; }
    public string brand { get; set; }
    public List<Image> images { get; set; } = new List<Image>();
}