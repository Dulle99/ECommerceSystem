using Microsoft.EntityFrameworkCore;
using ProductCatalogService.Data;
using ProductCatalogService.DTOs;
using ProductCatalogService.Models;
using System.Runtime.CompilerServices;

namespace ProductCatalogService.Services
{
    public class ProductCatalogService : IProductCatalogService
    {
       private readonly ProductCatalogDbContext _dbContext; 
       public ProductCatalogService(ProductCatalogDbContext context) 
        {
            this._dbContext = context;
        }

        public async Task<Product> AddProduct(Product product)
        {
            await this._dbContext.AddAsync(product);
            await this._dbContext.SaveChangesAsync();
            return await this._dbContext.Products.FindAsync(product.Id);
        }

        public async Task<Product?> GetProductById(int productId)
        {
            return await this._dbContext.Products.FindAsync(productId);
        }

        public async Task<List<Product?>> GetAllProducts()
        {
            return await this._dbContext.Products.ToListAsync();
        }

        public async Task<Product?> UpdateProduct(int productId, ProductDTO productDTO)
        {
            var product = await this.GetProductById(productId);
            if (product == null)
            {
                return new Product();
            }

            //updating 
            this._dbContext.Entry<Product>(product).CurrentValues.SetValues(productDTO);

            /*
             * other way of updating
             * 
            product.Description = productDTO.Description; 
            product.Name = productDTO.Name;    
            product.Price = productDTO.Price;
            product.Stock = productDTO.Stock;*/

            await _dbContext.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            var product = await this._dbContext.Products.FindAsync(productId);
            if (product is null)
                return false;
            
            this._dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
