using AutoMapper;
using SweetNest.Services.ProductAPI.Models;
using SweetNest.Services.ProductAPI.Models.Dto;

namespace SweetNest.Services.ProductAPI
{
    public class MappingConfig : Profile
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Product, ProductDto>().ReverseMap();

            });
            return mappingConfig;
        }
    }
}
