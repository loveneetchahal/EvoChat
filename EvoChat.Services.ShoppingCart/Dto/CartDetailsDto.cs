namespace EvoChat.Services.ShoppingCart.Dto
{
    public class CartDetailsDto
    {
        public Guid CartDetailsId { get; set; }
        public Guid CartHeaderId { get; set; }
        public virtual CartMasterDto CartMaster { get; set; }
        public Guid ProductId { get; set; }
        public virtual ProductDto Product { get; set; }
        public int Count { get; set; }
    }
}
