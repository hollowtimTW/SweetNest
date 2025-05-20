using SweetNest.Web.Models;

namespace SweetNest.Web.Service.IService
{
    public interface IBaseService
    {
       Task<ResponseDto>? SendAsync(RequestDto responseDto,bool withBearer = true);
    }
}
