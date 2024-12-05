namespace ProductsCatalog.Models;

public class Image
{
    public Guid id { get; set; }
    public string imageURL { get; set; }
    public bool isThumbnail { get; set; } = false;
}