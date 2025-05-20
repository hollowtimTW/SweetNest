using AutoMapper;
using SweetNest.Services.CouponAPI.Models;
using SweetNest.Services.CouponAPI.Models.Dto;

namespace SweetNest.Services.CouponAPI
{
    public class MappingConfig : Profile
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Coupon, CouponDto>().ReverseMap();

            });
            return mappingConfig;
        }
    }
}
