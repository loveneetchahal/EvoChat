using EvoChat.Services.Coupons.Repository;
using EvoChat.Shared;
using EvoChat.Shared.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EvoChat.Services.Coupons.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly ICouponRepository _couponRepository;  
        public CouponController(ICouponRepository couponRepository)
        {
            _couponRepository = couponRepository; 
        }

        [HttpGet("{code}")]
        public async Task<object> GetDiscountForCode(string code)
        {
            try
            {
                var coupon = await _couponRepository.GetCouponByCode(code);
                return Ok(new ResponseDto { status = true, StatusCode = StatusCodes.Status200OK, data = coupon, Message = ResponseMessages.msgGotSuccess });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseDto { status = false, StatusCode = StatusCodes.Status500InternalServerError, data = null, Message = ex.Message });
            } 
        }
    }
}
