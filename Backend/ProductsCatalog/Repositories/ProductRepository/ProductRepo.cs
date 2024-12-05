using Microsoft.EntityFrameworkCore;
using ProductsCatalog.Context;
using ProductsCatalog.Models;

namespace ProductsCatalog.Repositories.ProductRepository;

public class ProductRepo : IProductRepo
{
    private readonly ProductDbContext _context;
    public ProductRepo(ProductDbContext context)
    {
        _context = context;
    }
    public async Task<Product> GetProduct(Guid id)
    {
        try
        {
            return await _context.Products.FindAsync(id);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception in ProductRepo/GetProduct: {ex.Message}");
            return null;
        }
    }
    public async Task<List<Product>> GetProducts()
    {
        try
        {
            return await _context.Products.ToListAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception in ProductRepo/GetProducts: {ex.Message}");
            return null;
        }
    }
    public async Task<Product> AddProduct(Product product)
    {
        try
        {
            var added_product = await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return added_product.Entity;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception in ProductRepo/AddProduct: {ex.Message}");
            return null;
        }
    }
    public async Task<Product> UpdateProduct(Product product)
    {
        try
        {
            var updated_product = _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return updated_product.Entity;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception in ProductRepo/UpdateProduct: {ex.Message}");
            return null;
        }
    }
    public async Task<Product> DeleteProduct(Guid id)
    {
        try
        {
            var product = await GetProduct(id);
            if (product == null) return null;
            var deleted_product = _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return deleted_product.Entity;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception in ProductRepo/DeleteProduct: {ex.Message}");
            return null;
        }
    }

}