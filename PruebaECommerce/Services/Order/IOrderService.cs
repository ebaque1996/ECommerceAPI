using PruebaECommerce.Common.Results;
using PruebaECommerce.DTOs.Order;

namespace PruebaECommerce.Services.Order
{
    public interface IOrderService
    {
        Task<Result<List<OrderResponseDto>>> GetOrdersByUserIdAsync(int userId);
    }
}
