using ProductCatalogService.DTOs;
using ProductCatalogService.Models;

namespace ProductCatalogService.Services
{
    public interface IProductCatalogService
    {
        public Task<Product> AddProduct(Product product);
        public Task<Product> GetProductById(int productId);
        public Task<List<Product>> GetAllProducts();
        public Task<Product> UpdateProduct(int productId, ProductDTO productDTO);
        public Task DeleteProduct(int productId);
    }
}
