using ProductCatalogService.DTOs;
using ProductCatalogService.Models;

namespace ProductCatalogService.Services
{
    public interface IProductCatalogService
    {
        public Task<Product> AddProduct(Product product);

        public Task<List<Product>> GetAllProducts();

        public Task<Product> GetProductById(int productId);
        public Task<Product> UpdateProduct(ProductDTO product);

        public Task DeleteProduct(ProductDTO product);
    }
}
