using EvoChat.Services.ShoppingCart.Dto;
using EvoChat.Services.ShoppingCart.Repository;
using EvoChat.Shared;
using EvoChat.Shared.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EvoChat.Services.ShoppingCart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _cartRepository;
        private readonly ICouponRepository _couponRepository;
        private readonly IRabbitMQCartMessageSender _rabbitMQCartMessageSender;
        public CartController(ICartRepository cartRepository,
           ICouponRepository couponRepository, IRabbitMQCartMessageSender rabbitMQCartMessageSender)
        {
            _cartRepository = cartRepository;
            _couponRepository = couponRepository;
            _rabbitMQCartMessageSender = rabbitMQCartMessageSender;
        }

        [HttpGet("GetCart/{userId}")]
        public async Task<object> GetCart(string userId)
        {
            try
            {
                CartDto cartDto = await _cartRepository.GetCartByUserId(userId); 
                return Ok(new ResponseDto { status = true, StatusCode = StatusCodes.Status200OK, data = cartDto, Message = ResponseMessages.msgGotSuccess });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseDto { status = false, StatusCode = StatusCodes.Status500InternalServerError, data = null, Message = ex.Message });
            } 
        }

        [HttpPost("AddCart")]
        public async Task<object> AddCart(CartDto cartDto)
        {
            try
            {
                CartDto cartDt = await _cartRepository.CreateUpdateCart(cartDto);
                return Ok(new ResponseDto { status = true, StatusCode = StatusCodes.Status200OK, data = cartDt, Message = "Cart"+ ResponseMessages.msgAdditionSuccess });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseDto { status = false, StatusCode = StatusCodes.Status500InternalServerError, data = null, Message = ex.Message });
            } 
        }

        [HttpPost("UpdateCart")]
        public async Task<object> UpdateCart(CartDto cartDto)
        {
            try
            {
                CartDto cartDt = await _cartRepository.CreateUpdateCart(cartDto);
                return Ok(new ResponseDto { status = true, StatusCode = StatusCodes.Status200OK, data = cartDt, Message = "Cart" + ResponseMessages.msgUpdationSuccess });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseDto { status = false, StatusCode = StatusCodes.Status500InternalServerError, data = null, Message = ex.Message });
            } 
        }

        [HttpPost("RemoveCart")]
        public async Task<object> RemoveCart([FromBody] Guid cartId)
        {
            try
            {
                bool isSuccess = await _cartRepository.RemoveFromCart(cartId);
                return Ok(new ResponseDto { status = true, StatusCode = StatusCodes.Status200OK, data = isSuccess, Message = "Cart" + ResponseMessages.msgRemovedSuccess });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseDto { status = false, StatusCode = StatusCodes.Status500InternalServerError, data = null, Message = ex.Message });
            } 
        }

        [HttpPost("ApplyCoupon")]
        public async Task<object> ApplyCoupon([FromBody] CartDto cartDto)
        {
            try
            {
                bool isSuccess = await _cartRepository.ApplyCoupon(cartDto.CartMaster.UserId,
                    cartDto.CartMaster.CouponCode);
                return Ok(new ResponseDto { status = true, StatusCode = StatusCodes.Status200OK, data = isSuccess, Message = "Coupon" + ResponseMessages.msgAppliedSuccess });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseDto { status = false, StatusCode = StatusCodes.Status500InternalServerError, data = null, Message = ex.Message });
            } 
        }

        [HttpPost("RemoveCoupon")]
        public async Task<object> RemoveCoupon([FromBody] string userId)
        {
            try
            {
                bool isSuccess = await _cartRepository.RemoveCoupon(userId);
                return Ok(new ResponseDto { status = true, StatusCode = StatusCodes.Status200OK, data = isSuccess, Message = "Coupon" + ResponseMessages.msgRemovedSuccess });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseDto { status = false, StatusCode = StatusCodes.Status500InternalServerError, data = null, Message = ex.Message });
            } 
        }

        [HttpPost("CheckOut")]
        public async Task<object> CheckOut(CheckoutHeaderDto checkoutHeader)
        {
            try
            {
                CartDto cartDto = await _cartRepository.GetCartByUserId(checkoutHeader.UserId);
                if (cartDto == null)
                {
                    return Ok(new ResponseDto { status = false, StatusCode = StatusCodes.Status400BadRequest, data = null, Message = ResponseMessages.msgParametersNotCorrect });
                }

                if (!string.IsNullOrEmpty(checkoutHeader.CouponCode))
                {
                    // get from coupon from http client
                    CouponDto coupon = await _couponRepository.GetCoupon(checkoutHeader.CouponCode);
                    if (checkoutHeader.DiscountTotal != coupon.DiscountAmount)
                    {
                        return Ok(new ResponseDto { status = false, StatusCode = StatusCodes.Status200OK, data = null, Message = "Coupon Price has changed" });
                    }
                } 
                checkoutHeader.CartDetails = cartDto.CartDetails;
                //logic to add message to process order.
                //rabbitMQ
                //_rabbitMQCartMessageSender.SendMessage(checkoutHeader, "checkoutqueue");
                await _cartRepository.ClearCart(checkoutHeader.UserId);
                return Ok(new ResponseDto { status = true, StatusCode = StatusCodes.Status200OK, data = null, Message = "Checkout successfully" });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseDto { status = false, StatusCode = StatusCodes.Status500InternalServerError, data = null, Message = ex.Message });
            }
        }
    }
}
