using PruebaECommerce.Common.Results;
using PruebaECommerce.DTOs.Cart;

namespace PruebaECommerce.Services.Cart
{
    public interface ICartService
    {
        Task<CartResponseDto> GetCartAsync(int userId);
        Task<Result> AddItemToCartAsync(int userId, AddToCartDto addToCartDto);
    }
}
