using AutoMapper;
using EvoChat.Services.Coupons.Dto;
using EvoChat.Services.Coupons.Models;

namespace EvoChat.Services.Coupons
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponDto, Coupon>().ReverseMap(); 
            });

            return mappingConfig;
        }
    }
}
