using ProductsCatalog.Models;

namespace ProductsCatalog.Repositories.ProductRepository;
public interface IProductRepo
{
    public Task<Product> GetProduct(Guid id);
    public Task<List<Product>> GetProducts();
    public Task<Product> AddProduct(Product product);
    public Task<Product> UpdateProduct(Product product);
    public Task<Product> DeleteProduct(Guid id);
}