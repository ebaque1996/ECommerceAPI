using PruebaECommerce.Domain;

namespace PruebaECommerce.DTOs.Cart
{
    public class CartResponseDto
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();
        public decimal SubTotal { get; set; }
        public decimal Discount { get; set; }
        public decimal Total => SubTotal - Discount;
    }
}
