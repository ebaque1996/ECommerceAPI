using PruebaECommerce.Common.Results;
using PruebaECommerce.DTOs.Cart;

namespace PruebaECommerce.Services.Cart
{
    public interface ICartService
    {
        Task<Result<CartResponseDto>> GetCartAsync(int userId);
        Task<Result> AddItemToCartAsync(int userId, AddToCartDto addToCartDto);
        Task<Result> UpdateCartItemQuantityAsync(int userId, int productId, UpdateCartItemDto updateCartItemDto);
        Task<Result> DeleteCartItemAsync(int userId, int productId);
        Task<Result> ClearCartAsync(int userId);
    }
}
