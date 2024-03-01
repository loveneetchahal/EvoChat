using EvoChat.Services.ShoppingCart.Dto;
using EvoChat.Shared;
using Newtonsoft.Json;

namespace EvoChat.Services.ShoppingCart.Repository
{
    public interface ICouponRepository
    {
        Task<CouponDto> GetCoupon(string couponName);
    }
    public class CouponRepository : ICouponRepository
    {
        private readonly HttpClient client; 
        public CouponRepository(HttpClient client)
        {
            this.client = client;
        }

        public async Task<CouponDto> GetCoupon(string couponName)
        {
            var response = await client.GetAsync($"/api/coupon/{couponName}");
            var apiContent = await response.Content.ReadAsStringAsync();
            var resp = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
            if (resp.status)
            {
                return JsonConvert.DeserializeObject<CouponDto>(Convert.ToString(resp.data));
            }
            return new CouponDto();
        }
    }
}
