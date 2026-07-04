namespace PruebaECommerce.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        
        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
        public ICollection<Order> OrderItems { get; set; } = new List<Order>();
        
        
    }
}
