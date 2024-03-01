namespace EvoChat.Services.ShoppingCart.Models
{
    public class Cart
    {
        public CartMaster CartMaster { get; set; }
        public IEnumerable<CartDetails> CartDetails { get; set; }
    }
}
