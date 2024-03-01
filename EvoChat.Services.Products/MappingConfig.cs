using AutoMapper;
using EvoChat.Services.Products.Dto;
using EvoChat.Services.Products.Models;

namespace EvoChat.Services.Products
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDto, Product>();
                config.CreateMap<Product, ProductDto>();
            });

            return mappingConfig;
        }
    }
}
