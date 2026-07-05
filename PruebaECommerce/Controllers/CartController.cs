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
            var cart = await _cartService.GetCartAsync(userId);
            return Ok(cart);
        }

        [HttpPost("{items}")]
        public async Task<IActionResult> AddItemToCart(int userId, AddToCartDto addToCartDto)
        {
            var result = await _cartService.AddItemToCartAsync(userId, addToCartDto);
            return StatusCode(result.StatusCode, new { message = result.Message });
        }

        [HttpPut("{items}/productId")]
        public async Task<IActionResult> UpdateCartItemQuantity(int userId, UpdateCartItemDto updateCartItemDto)
        {
            var result = await _cartService.UpdateCartItemQuantityAsync(userId, updateCartItemDto);
            return StatusCode(result.StatusCode, new { message = result.Message });
        }
    }
}
