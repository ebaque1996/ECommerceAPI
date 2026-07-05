namespace PruebaECommerce.Models
{
    public class UserDbModel
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        
        public ICollection<CartItemDbModel> CartItems { get; set; } = new List<CartItemDbModel>();
        public ICollection<OrderDbModel> OrderItems { get; set; } = new List<OrderDbModel>();
        
        
    }
}
