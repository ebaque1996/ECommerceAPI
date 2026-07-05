using Microsoft.EntityFrameworkCore;
using PruebaECommerce.Common.Results;
using PruebaECommerce.DTOs.Cart;
using PruebaECommerce.Models;
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

        public async Task<Result> AddItemToCartAsync(int userId, AddToCartDto addToCartDto)
        {
            var product = await _context.Products.FindAsync(addToCartDto.ProductId);

            //Si el producto no existe, devolvemos un error 404
            if (product == null)
                return new Result { Success = false, ErrorMessage = "Product not found.", StatusCode = 404 };

            //Si la cantidad solicitada es mayor que el stock disponible, devolvemos un error 409
            if (product.Stock < addToCartDto.Quantity)
                return new Result { Success = false, ErrorMessage = "Not enough stock available.", StatusCode = 409 };

            var cartItem = new CartItem
            {
                UserId = userId,
                ProductId = addToCartDto.ProductId,
                Quantity = addToCartDto.Quantity
            };

            //Agregamos el producto a la tabla CartItems
            await _context.CartItems.AddAsync(cartItem);
            await _context.SaveChangesAsync();

            //Devolvemos un resultado exitoso con código de estado 201
            return new Result { Success = true, StatusCode = 201 };
        }
    }
}
