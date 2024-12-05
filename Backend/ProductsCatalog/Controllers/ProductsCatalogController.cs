using Microsoft.AspNetCore.Mvc;
using ProductsCatalog.DTO;
using ProductsCatalog.Models;
using ProductsCatalog.Repositories.ProductRepository;

namespace ProductsCatalog.Controllers;

[ApiController]
[Route("yk-techtown/api")]
public class ProductsCatalogController : ControllerBase
{
    private readonly IProductRepo _productRepo;
    public ProductsCatalogController(IProductRepo productRepo)
    {
        _productRepo = productRepo;
    }
    [HttpGet("products")]
    public async Task<IActionResult> GetProducts()
    {
        try
        {
            var products = await _productRepo.GetProducts();
            if (products == null) return BadRequest(new { error = "Something went wrong while fetching products..." });
            return Ok(products);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception in ProductCatalogController/GetProducts: {ex.Message}");
            return BadRequest(new { error = "Something went wrong while fetching products..." });
        }
    }
    [HttpGet("products/{id}")]
    public async Task<IActionResult> GetProduct(Guid id)
    {
        try
        {
            var product = await _productRepo.GetProduct(id);
            if (product == null) return BadRequest(new { error = "Something went wrong while fetching product..." });
            return Ok(product);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception in ProductCatalogController/GetProduct: {ex.Message}");
            return BadRequest(new { error = "Something went wrong while fetching product..." });
        }
    }
    [HttpPost("products")]
    public async Task<IActionResult> AddProduct(AddProductDTO productDTO)
    {
        try
        {
            productDTO.images.ForEach(x => x.id = Guid.NewGuid());
            var product = new Product()
            {
                title = productDTO.title,
                description = productDTO.description,
                price = productDTO.price,
                category = productDTO.category,
                images = productDTO.images,
                createdAt = DateTime.UtcNow
            };
            var added_product = await _productRepo.AddProduct(product);
            if (product == null) return BadRequest(new { error = "Something went wrong while fetching product..." });
            return Ok(product);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception in ProductCatalogController/GetProduct: {ex.Message}");
            return BadRequest(new { error = "Something went wrong while fetching product..." });
        }
    }
    [HttpPatch("products/{id}")]
    public async Task<IActionResult> UpdateProduct(UpdateProductDTO productDTO)
    {
        try
        {
            var product = await _productRepo.GetProduct(productDTO.id);
            if (product == null) return NotFound(new { error = "Product not found" });
            product.title = productDTO.title != null ? productDTO.title : product.title;
            product.description = productDTO.description != null ? productDTO.description : product.description;
            product.price = productDTO.price > 0 ? productDTO.price : product.price;
            product.category = productDTO.category != null ? productDTO.category : product.category;
            var updated_product = await _productRepo.UpdateProduct(product);
            if (updated_product == null) return BadRequest(new { error = "Something went wrong while updating product..." });
            return Ok(updated_product);
        }
        catch (Exception ex)
        {

            Console.WriteLine($"Exception in ProductsCatalogController/UpdateProduct: {ex.Message}");
            return BadRequest(new { error = "Something went wrong while updating product..." });
        }
    }
    [HttpDelete("products/{id}")]
    public async Task<IActionResult> DeleteProduct(Guid id)
    {
        try
        {
            var deleted_product = await _productRepo.DeleteProduct(id);
            if (deleted_product == null) return NotFound(new { error = "Product not found" });
            return Ok(deleted_product);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception in ProductsCatalogController/DeleteProduct: {ex.Message}");
            return BadRequest(new { error = "Something went wrong while deleting product..." });
        }
    }
}
