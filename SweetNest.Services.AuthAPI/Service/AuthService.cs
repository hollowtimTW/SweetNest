 using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SweetNest.Services.AuthAPI.Data;
using SweetNest.Services.AuthAPI.Models;
using SweetNest.Services.AuthAPI.Models.Dto;
using SweetNest.Services.AuthAPI.Service.IService;

namespace SweetNest.Services.AuthAPI.Service
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        public AuthService(AppDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IJwtTokenGenerator jwtTokenGenerator)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<bool> AssignRole(string email, string roleName)
        {
            var user = await _db.ApplicationUsers.FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());
            if (user != null)
            {
                if (!await _roleManager.RoleExistsAsync(roleName))
                {
                    await _roleManager.CreateAsync(new IdentityRole(roleName));
                }
                await _userManager.AddToRoleAsync(user, roleName);
                return true;
            }
            return false;
        }

        public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {

            var user = await _db.ApplicationUsers.FirstOrDefaultAsync(u=>u.UserName.ToLower() == loginRequestDto.UserName.ToLower());
           
            bool isValid = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);

            if(user==null || !isValid)
            {
                return new LoginResponseDto() { User = null, Token = string.Empty };
            }

            // jwt token
            var roles = await _userManager.GetRolesAsync(user);
            var token = _jwtTokenGenerator.GenerateToken(user, roles);

            UserDto userDto = new()
            {
                Email = user.Email,
                ID = user.Id,
                Name = user.Name,
                PhoneNumber = user.PhoneNumber
            };

            LoginResponseDto loginResponseDto = new LoginResponseDto()
            {
                User = userDto,
                Token = token
            };
            return loginResponseDto;
        }

        public async Task<string> Register(RegisterationRequestDto registerationRequestDto)
        {
            ApplicationUser user = new() 
            { 
                UserName = registerationRequestDto.Email,
                Email = registerationRequestDto.Email,
                NormalizedEmail = registerationRequestDto.Email.ToUpper(),
                Name = registerationRequestDto.Name,
                PhoneNumber = registerationRequestDto.PhoneNumber,
            };

            try
            {
                var result = _userManager.CreateAsync(user, registerationRequestDto.Password).GetAwaiter().GetResult();
                if (result.Succeeded)
                {
                    var userToReturn = _db.ApplicationUsers.First(u=>u.UserName == registerationRequestDto.Email);

                    UserDto userDto = new()
                    {
                        Email = userToReturn.Email,
                        ID = userToReturn.Id,
                        Name = userToReturn.Name,
                        PhoneNumber = userToReturn.PhoneNumber
                    };

                    return "";
                }else
                {
                    return result.Errors.FirstOrDefault().Description;
                }
            
            }
            catch(Exception ex)
            {

            }
            return "Error Encountered";
        }
    }
}
