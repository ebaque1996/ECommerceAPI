namespace PruebaECommerce.DTOs.Cart
{
    public class UpdateCartItemDto
    {
        public int CartItemId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
