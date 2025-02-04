using Microsoft.EntityFrameworkCore;
using ProductCatalogService.Models;

namespace ProductCatalogService.Data
{
    public class ProductCatalogDbContext : DbContext
    {
        public ProductCatalogDbContext(DbContextOptions<ProductCatalogDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Laptop Dell Xp", Price = 99000, Description= "Prvi opis", Stock= 2 },
                new Product { Id = 2, Name = "Laptop Asus nitro 5x", Price = 72000 , Description = "Drugi opis", Stock = 0 }
            );
        }
    }
}
