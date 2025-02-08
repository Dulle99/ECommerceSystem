using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductCatalogService.Data;
using ProductCatalogService.DTOs;
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
        [Route("GetProduct/{productId}")]
        public async Task<IActionResult> GetProductById(int productId)
        {
            return new JsonResult(await this.productCatalogService.GetProductById(productId));
        }

        [HttpGet]
        [Route("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            return new JsonResult(await productCatalogService.GetAllProducts());
        }

        [HttpPut]
        [Route("UpdateProduct/{productId}")]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductDTO productDTO, int productId)
        {
            return new JsonResult(await this.productCatalogService.UpdateProduct(productId, productDTO));
        }

        [HttpDelete]
        [Route("RemoveProduct/{productId}")]
        public async Task<IActionResult> RemoveProduct(int productId)
        {
            if (await this.productCatalogService.DeleteProduct(productId))
                return Ok();

            return BadRequest();
        }
    }
}
