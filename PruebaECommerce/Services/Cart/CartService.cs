using Microsoft.EntityFrameworkCore;
using PruebaECommerce.DTOs.Cart;
using PruebaECommerce.Repositories.Data;

namespace PruebaECommerce.Services.Cart
{
    public class CartService : ICartService
    {
        private readonly AppDbContext _context;
        public CartService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CartResponseDto> GetCartAsync(int userId)
        {
            var cartItems = await _context.CartItems
                .Where(ci => ci.UserId == userId)
                .Select(ci => new CartItemResponseDto
                {
                    Id = ci.Id,
                    ProductId = ci.ProductId,
                    ProductName = ci.Product.Name,
                    ProductCode = ci.Product.Code,
                    UnitPrice = ci.Product.Price,
                    Quantity = ci.Quantity
                })
                .ToListAsync();
            var subTotal = cartItems.Sum(ci => ci.TotalPrice);
            var discount = 0m; // TODO: Implement discount calculation logic here
            return new CartResponseDto
            {
                Items = cartItems,
                SubTotal = subTotal,
                Discount = discount
            };
        }
    }
}
