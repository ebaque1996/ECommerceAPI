using PruebaECommerce.Common.Results;
using PruebaECommerce.DTOs.Cart;
using PruebaECommerce.Services.Product;

namespace PruebaECommerce.Services.Cart
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;
        public CartService(ICartRepository cartRepository, IProductRepository productRepository)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
        }

        public async Task<Result<CartResponseDto>> GetCartAsync(int userId)
        {
            var cartItems = await _cartRepository.GetCartItemsByUserIdAsync(userId);

            if (cartItems == null || cartItems.Count == 0)
                return new Result<CartResponseDto> { Success = false, Message = "Items not found.", StatusCode = 404 };

            var subTotal = cartItems.Sum(ci => ci.UnitPrice);
            var discount = 0m; // TODO: Implement discount calculation logic here

            return new Result<CartResponseDto> { 
                Success = true, 
                StatusCode = 200, 
                Data = new CartResponseDto { 
                    Items = cartItems, 
                    SubTotal = subTotal ?? 0, 
                    Discount = discount 
                } 
            };
        }

        public async Task<Result> AddItemToCartAsync(int userId, AddToCartDto addToCartDto)
        {
            //var product = await _context.Products.FindAsync(addToCartDto.ProductId);
            var product = await _productRepository.GetProductByIdAsync(addToCartDto.ProductId);

            //Si el producto no existe, devolvemos un error 404
            if (product == null)
                return new Result { Success = false, Message = "Product not found.", StatusCode = 404 };

            //Si la cantidad solicitada es mayor que el stock disponible, devolvemos un error 409
            if (product.Stock < addToCartDto.Quantity)
                return new Result { Success = false, Message = "Not enough stock available.", StatusCode = 409 };

            await _cartRepository.AddItemToCartAsync(userId, addToCartDto.ProductId, addToCartDto.Quantity);

            //Devolvemos un resultado exitoso con código de estado 201
            return new Result { Success = true, StatusCode = 201, Message = "Product created successfully" };
        }

        public async Task<Result> UpdateCartItemQuantityAsync(int userId, int productId, UpdateCartItemDto updateCartItemDto)
        {
            var cartItem = await _cartRepository.GetCartItemByUserAndProductAsync(userId, productId);

            //Si el registro del carrito no existe, devolvemos un error 404
            if (cartItem == null)
                return new Result { Success = false, Message = "Cart item not found.", StatusCode = 404 };

            var product = await _productRepository.GetProductByIdAsync(productId);

            //Si el producto no existe, devolvemos un error 404
            if (product == null)
                return new Result { Success = false, Message = "Product not found.", StatusCode = 404 };

            //Si la cantidad solicitada es mayor que el stock disponible, devolvemos un error 409
            if (product.Stock < updateCartItemDto.Quantity)
                return new Result { Success = false, Message = "Not enough stock available.", StatusCode = 409 };

            //Actualizamos la cantidad del producto en la tabla CartItems
            cartItem.Quantity = updateCartItemDto.Quantity;
            await _cartRepository.UpdateCartItemQuantityAsync(cartItem);

            //Devolvemos un resultado exitoso con código de estado 200
            return new Result { Success = true, StatusCode = 200, Message = "Product updated successfully" };
        }

        public async Task<Result> DeleteCartItemAsync(int userId, int productId)
        {
            //var cartItem = await _context.CartItems.FirstOrDefaultAsync(c => c.ProductId == productId && c.UserId == userId);
            var cartItem = await _cartRepository.GetCartItemByUserAndProductAsync(userId, productId);

            //Si el registro del carrito no existe, devolvemos un error 404
            if (cartItem == null)
                return new Result { Success = false, Message = "Cart item not found.", StatusCode = 404 };

            //Removemos el registro de la tabla CartItems
            await _cartRepository.RemoveCartItemAsync(cartItem.Id);

            //Devolvemos un resultado exitoso con código de estado 200
            return new Result { Success = true, StatusCode = 200, Message = "Product removed successfully" };
        }

        public async Task<Result> ClearCartAsync(int userId)
        {
            //var cartItems = await _context.CartItems.Where(c => c.UserId == userId).ToListAsync();
            var cartItems = await _cartRepository.GetCartItemsByUserIdAsync(userId);

            //Si no existen registros en el carrito, devolvemos un error 404
            if (cartItems == null || cartItems.Count == 0)
                return new Result { Success = false, Message = "Cart items not found.", StatusCode = 404 };

            //Removemos los registros del usuario de la tabla CartItems
            await _cartRepository.ClearCartAsync(userId);

            //Devolvemos un resultado exitoso con código de estado 200
            return new Result { Success = true, StatusCode = 200, Message = "Products removed successfully" };
        }
    }
}
