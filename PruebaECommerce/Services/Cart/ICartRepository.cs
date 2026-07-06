using PruebaECommerce.Domain;

namespace PruebaECommerce.Services.Cart
{
    public interface ICartRepository
    {
        Task<List<CartItem>> GetCartItemsByUserIdAsync(int userId);
        Task<CartItem> GetCartItemByUserAndProductAsync(int userId, int productId);
        Task AddItemToCartAsync(int userId, int productId, int quantity);
        Task UpdateCartItemQuantityAsync(CartItem cartItem);
        Task RemoveCartItemAsync(int cartItemId);
        Task ClearCartAsync(int userId);
    }
}
