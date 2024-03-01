using System.ComponentModel.DataAnnotations.Schema;

namespace EvoChat.Services.ShoppingCart.Models
{
    public class CartDetails
    {
        public Guid CartDetailsId { get; set; }
        public Guid CartMasterId { get; set; }
        [ForeignKey("CartMasterId")]
        public virtual CartMaster CartMaster { get; set; }
        public Guid ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        public int Count { get; set; }
    }
}
