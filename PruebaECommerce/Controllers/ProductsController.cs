using Microsoft.AspNetCore.Mvc;
using PruebaECommerce.DTOs.Product;
using PruebaECommerce.Services.Product;

namespace PruebaECommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var result = await _productService.GetProductByIdAsync(id);
            return StatusCode(result.StatusCode, new { message = result.Message, data = result.Data });
        }

        [HttpGet("")]
        public async Task<IActionResult> GetProducts([FromQuery] ProductFilterDto productFilterDto)
        {
            var result = await _productService.GetProductsAsync(productFilterDto);
            return StatusCode(result.StatusCode, new { message = result.Message, data = result.Data });
        }
    }
}
