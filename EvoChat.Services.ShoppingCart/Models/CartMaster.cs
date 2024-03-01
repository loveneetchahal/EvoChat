using System.ComponentModel.DataAnnotations;

namespace EvoChat.Services.ShoppingCart.Models
{
    public class CartMaster
    {
        [Key]
        public Guid CartMasterId { get; set; }
        public string UserId { get; set; }
        public string CouponCode { get; set; }
    }
}
