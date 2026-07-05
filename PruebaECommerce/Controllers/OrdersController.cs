using Microsoft.AspNetCore.Mvc;
using PruebaECommerce.Services.Order;

namespace PruebaECommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetOrdersByUserId(int userId)
        {
            var result = await _orderService.GetOrdersByUserIdAsync(userId);
            return StatusCode(result.StatusCode, new { message = result.Message, data = result.Data });
        }
    }
}
