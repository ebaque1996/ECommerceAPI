namespace PruebaECommerce.DTOs.Cart
{
    public class CartResponseDto
    {
        public List<CartItemResponseDto> Items { get; set; } = new List<CartItemResponseDto>();
        public decimal SubTotal { get; set; }
        public decimal Discount { get; set; }
        public decimal Total => SubTotal - Discount;
    }
}
