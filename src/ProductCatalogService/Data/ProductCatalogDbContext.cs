using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using ProductCatalogService.Models;

namespace ProductCatalogService.Data
{
    public class ProductCatalogDbContext : DbContext
    {
        public ProductCatalogDbContext(DbContextOptions<ProductCatalogDbContext> options) : base(options) 
        {

        }

        public DbSet<Product> Products { get; set; }



    }
}
