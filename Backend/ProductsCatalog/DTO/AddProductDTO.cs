using System.ComponentModel.DataAnnotations;
using ProductsCatalog.Models;

namespace ProductsCatalog.DTO;
public class AddProductDTO
{
    [Required]
    public string title { get; set; }
    [Required]
    public string description { get; set; }
    [Required]
    public float price { get; set; }
    [Required]
    public string category { get; set; }
    public string brand { get; set; }
    public List<Image> images { get; set; } = new List<Image>();
}