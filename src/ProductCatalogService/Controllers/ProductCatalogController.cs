using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductCatalogService.Data;
using ProductCatalogService.Models;
using ProductCatalogService.Services;

namespace ProductCatalogService.Controllers
{
    [Route("api/products")]
    [ApiController]

    public class ProductCatalogController : ControllerBase
    {
        private IProductCatalogService productCatalogService;

        public ProductCatalogController(ProductCatalogDbContext context)
        {
            this.productCatalogService = new ProductCatalogService.Services.ProductCatalogService(context);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            return new JsonResult(await this.productCatalogService.AddProduct(product));
        }

        [HttpGet]
        public string Get()
        {
            return "Hello";
        }

    }
}
