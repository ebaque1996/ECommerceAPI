namespace PruebaECommerce.Models
{
    public class CartItemDbModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }


        public UserDbModel User { get; set; } = null!;
        public ProductDbModel Product { get; set; } = null!;
    }
}
