using System.ComponentModel.DataAnnotations;

namespace EvoChat.Services.Coupons.Models
{
    public class Coupon
    {
        [Key]
        public Guid CouponId { get; set; }
        public string CouponCode { get; set; }
        public double DiscountAmount { get; set; }
    }
}
