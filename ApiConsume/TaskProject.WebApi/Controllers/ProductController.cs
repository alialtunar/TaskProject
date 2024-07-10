using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskProject.BussinesLayer.Abstract;
using TaskProject.DtoLayer.Dtos;

namespace TaskProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        // POST controller method that we use to filter and list products
        [HttpPost("query")]
        public IActionResult GetProducts([FromBody] ProductQuery query)
        {
           
            var products = _productService.GetProducts(query);
            return Ok(products);
        }
    }

}
