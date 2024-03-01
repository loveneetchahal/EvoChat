namespace EvoChat.Services.ShoppingCart.Dto
{
    public class CartDto
    {
        public CartMasterDto CartMaster { get; set; }
        public IEnumerable<CartDetailsDto> CartDetails { get; set; }
    }
}
