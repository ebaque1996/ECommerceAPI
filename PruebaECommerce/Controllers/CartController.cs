using Microsoft.AspNetCore.Mvc;
using PruebaECommerce.DTOs.Cart;
using PruebaECommerce.Services.Cart;

namespace PruebaECommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetCart(int userId)
        {
            var result = await _cartService.GetCartAsync(userId);
            return StatusCode(result.StatusCode, new { message = result.Message, data = result.Data });
        }

        [HttpPost("items")]
        public async Task<IActionResult> AddItemToCart(int userId, AddToCartDto addToCartDto)
        {
            var result = await _cartService.AddItemToCartAsync(userId, addToCartDto);
            return StatusCode(result.StatusCode, new { message = result.Message });
        }

        [HttpPut("items/{productId}")]
        public async Task<IActionResult> UpdateCartItemQuantity(int userId, int productId, UpdateCartItemDto updateCartItemDto)
        {
            var result = await _cartService.UpdateCartItemQuantityAsync(userId, productId, updateCartItemDto);
            return StatusCode(result.StatusCode, new { message = result.Message });
        }

        [HttpDelete("items/{productId}")]
        public async Task<IActionResult> DeleteCartItem(int userId, int productId)
        {
            var result = await _cartService.DeleteCartItemAsync(userId, productId);
            return StatusCode(result.StatusCode, new { message = result.Message });
        }

        [HttpDelete("")]
        public async Task<IActionResult> ClearCart(int userId)
        {
            var result = await _cartService.ClearCartAsync(userId);
            return StatusCode(result.StatusCode, new { message = result.Message });
        }
    }
}
