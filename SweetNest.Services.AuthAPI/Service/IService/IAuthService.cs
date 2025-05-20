using SweetNest.Services.AuthAPI.Models.Dto;

namespace SweetNest.Services.AuthAPI.Service.IService
{
    public interface IAuthService
    {
        Task<string> Register(RegisterationRequestDto registerationRequestDto);
        Task<LoginResponseDto> Login(LoginRequestDto loginResponseDto);
        Task<bool> AssignRole(string email, string roleNmae);
    }
}
