using SweetNest.Services.OrderAPI.Models.Dto;

namespace SweetNest.Services.OrderAPI.Service.IService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
    }
}
