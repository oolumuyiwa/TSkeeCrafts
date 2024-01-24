using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TSkeeCrafts.WebSite.Models;
using TSkeeCrafts.WebSite.Services;

namespace TSkeeCrafts.WebSite.Controllers
{
    [Route("/products")]
    [ApiController]
    public class ProductsContrioller : ControllerBase
    {
        public ProductsContrioller(JsonFileProductService productService) 
        { 
            this.ProductService = productService;
        }

        public JsonFileProductService ProductService { get; }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return ProductService.GetProducts();
        }

        [Route("rate")]
        [HttpGet]
        public ActionResult Get(
            [FromQuery] string ProductId, 
            [FromQuery] int Rating)
        {
            ProductService.AddRating(ProductId, Rating);
            return Ok();
        }
    }
}
