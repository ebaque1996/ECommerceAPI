using PruebaECommerce.DTOs.Cart;

namespace PruebaECommerce.Services.Cart
{
    public interface ICartService
    {
        Task<CartResponseDto> GetCartAsync(int userId);        
    }
}
