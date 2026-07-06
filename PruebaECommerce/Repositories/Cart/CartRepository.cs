using Microsoft.EntityFrameworkCore;
using PruebaECommerce.Domain;
using PruebaECommerce.Models;
using PruebaECommerce.Repositories.Data;
using PruebaECommerce.Services.Cart;

namespace PruebaECommerce.Repositories.Cart
{
    public class CartRepository : ICartRepository
    {
        private readonly AppDbContext _context;

        public CartRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<CartItem>> GetCartItemsByUserIdAsync(int userId)
        {
            return await _context.CartItems
                .Where(ci => ci.UserId == userId)
                .Select(ci => new CartItem(
                    ci.Id,
                    ci.UserId,
                    ci.ProductId,
                    ci.Product.Name,
                    ci.Product.Code,
                    ci.Product.Price,
                    ci.Quantity
                ))
                .ToListAsync();
        }

        public async Task<CartItem> GetCartItemByUserAndProductAsync(int userId, int productId)
        {
            var cartItemDb = await _context.CartItems
                .FirstOrDefaultAsync(ci => ci.UserId == userId && ci.ProductId == productId);

            if (cartItemDb == null)
                return null;

            return new CartItem(
                cartItemDb.Id,
                cartItemDb.UserId,
                cartItemDb.ProductId,
                null,
                null,
                null,
                cartItemDb.Quantity
            );
        }

        public async Task AddItemToCartAsync(int userId, int productId, int quantity)
        {
            var cartItemDb = new CartItemDbModel
            {
                UserId = userId,
                ProductId = productId,
                Quantity = quantity
            };
            await _context.CartItems.AddAsync(cartItemDb);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCartItemQuantityAsync(CartItem cartItem)
        {
            var cartItemDb = await _context.CartItems.FirstOrDefaultAsync(ci => ci.Id == cartItem.Id);
            if (cartItemDb != null)
            {
                cartItemDb.Quantity = cartItem.Quantity;
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveCartItemAsync(int cartItemId)
        {
            var cartItemDb = await _context.CartItems.FirstOrDefaultAsync(ci => ci.Id == cartItemId);
            if (cartItemDb != null)
            {
                _context.CartItems.Remove(cartItemDb);
                await _context.SaveChangesAsync();
            }
        }

        public async Task ClearCartAsync(int userId)
        {
            var cartItemsDb = await _context.CartItems.Where(ci => ci.UserId == userId).ToListAsync();
            if (cartItemsDb.Any())
            {
                _context.CartItems.RemoveRange(cartItemsDb);
                await _context.SaveChangesAsync();
            }
        }
    }
}
