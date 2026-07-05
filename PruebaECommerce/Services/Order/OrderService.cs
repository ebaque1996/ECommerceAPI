using Microsoft.EntityFrameworkCore;
using PruebaECommerce.Common.Results;
using PruebaECommerce.DTOs.Cart;
using PruebaECommerce.DTOs.Order;
using PruebaECommerce.DTOs.Product;
using PruebaECommerce.Models;
using PruebaECommerce.Repositories.Data;
using PruebaECommerce.Services.Cart;

namespace PruebaECommerce.Services.Order
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _context;
        public OrderService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Result<List<OrderResponseDto>>> GetOrdersByUserIdAsync(int userId)
        {
            var orders = await _context.Orders
                .Where(o => o.UserId == userId)
                .Select(o => new OrderResponseDto
                {
                    Id = o.Id,
                    UserId = o.UserId,
                    UserEmail = o.User.Email,
                    OrderDate = o.OrderDate,
                    Subtotal = o.Subtotal,
                    Discount = o.Discount,
                    Total = o.Total
                })
            .ToListAsync();

            //Si no se encuentran órdenes para el usuario, devolvemos un error 404
            if (orders == null || orders.Count == 0)
                return new Result<List<OrderResponseDto>> { Success = false, Message = "Orders not found.", StatusCode = 404 };

            return new Result<List<OrderResponseDto>> { Success = true, StatusCode = 200, Data = orders };
        }

        public async Task<Result<List<OrderDetailResponseDto>>> GetOrderDetailByIdAsync(int orderId)
        {
            var orderDetails = await _context.OrderDetails
                .Where(od => od.OrderId == orderId)
                .Select(od => new OrderDetailResponseDto
                {
                    Id = od.Id,
                    OrderId = od.OrderId,
                    ProductId = od.ProductId,
                    ProductName = od.Product.Name,
                    Quantity = od.Quantity,
                    UnitPrice = od.UnitPrice,
                    Subtotal = od.Subtotal,
                })
            .ToListAsync();

            //Si no se encuentran detalles de la orden, devolvemos un error 404
            if (orderDetails == null || orderDetails.Count == 0)
                return new Result<List<OrderDetailResponseDto>> { Success = false, Message = "Order details not found.", StatusCode = 404 };
            
            return new Result<List<OrderDetailResponseDto>> { Success = true, StatusCode = 200, Data = orderDetails };
        }
    }
}
