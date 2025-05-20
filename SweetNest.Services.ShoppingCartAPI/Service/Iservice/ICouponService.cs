using SweetNest.Services.ShoppingCartAPI.Models.Dto;

namespace SweetNest.Services.ShoppingCartAPI.Service.Iservice
{
    public interface ICouponService
    {
        Task<CouponDto> GetCoupon(string couponCode);
    }
}
