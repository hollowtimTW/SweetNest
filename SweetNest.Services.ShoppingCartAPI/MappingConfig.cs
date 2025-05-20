using AutoMapper;
using SweetNest.Services.ShoppingCartAPI.Models;
using SweetNest.Services.ShoppingCartAPI.Models.Dto;

namespace SweetNest.Services.ShoppingCartAPI
{
    public class MappingConfig : Profile
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {

                config.CreateMap<CartDetails, CartDetailsDto>().ReverseMap();
                config.CreateMap<CartHeader, CartHeaderDto>().ReverseMap();

            });
            return mappingConfig;
        }
    }
}
