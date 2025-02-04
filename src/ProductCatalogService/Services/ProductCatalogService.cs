using Microsoft.EntityFrameworkCore;
using ProductCatalogService.Data;
using ProductCatalogService.DTOs;
using ProductCatalogService.Models;
using System.Runtime.CompilerServices;

namespace ProductCatalogService.Services
{
    public class ProductCatalogService : IProductCatalogService
    {
       private ProductCatalogDbContext _dbContext; 
       public ProductCatalogService(ProductCatalogDbContext context) 
        {
            this._dbContext = context;
        }
        public async Task<Product> AddProduct(Product product)
        {
            await this._dbContext.AddAsync(new Product { 
                Description = product.Description,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock});

            await this._dbContext.SaveChangesAsync();

            return await this._dbContext.Products.FindAsync(product.Id);
        }

        public Task DeleteProduct(ProductDTO product)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetAllProducts()
        {
            return this._dbContext.Products.ToListAsync();
        }

        public Task<Product> GetProductById(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<Product> UpdateProduct(ProductDTO product)
        {
            throw new NotImplementedException();
        }
    }
}
