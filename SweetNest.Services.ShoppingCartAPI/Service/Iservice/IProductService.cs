using SweetNest.Services.ShoppingCartAPI.Models.Dto;

namespace SweetNest.Services.ShoppingCartAPI.Service.Iservice
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
    }
}
