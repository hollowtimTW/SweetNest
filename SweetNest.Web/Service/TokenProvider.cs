using Newtonsoft.Json.Linq;
using SweetNest.Web.Service.IService;
using SweetNest.Web.Utility;

namespace SweetNest.Web.Service
{
    public class TokenProvider : ITokenProvider
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public TokenProvider(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
        public void ClearToken()
        {
            _contextAccessor.HttpContext?.Response.Cookies.Delete(SD.TokenCookie);
        }

        public string? GetToken()
        {
            if (_contextAccessor.HttpContext?.Request.Cookies.TryGetValue(SD.TokenCookie, out var token) == true)
            {
                return token;
            }
            return null;
        }


        public void SetToken(string token)
        {
            _contextAccessor.HttpContext?.Response.Cookies.Append(SD.TokenCookie, token);
        }
    }
}
