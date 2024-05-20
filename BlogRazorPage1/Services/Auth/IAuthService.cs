using BlogRazorPage.Models.Auth;
using BlogRazorPage.Models;

namespace BlogRazorPage.Services.Auth
{
    public interface IAuthService
    {
        Task<ApiResult<LoginResponse>?> Login(LoginCommand command);
        Task<ApiResult?> Register(RegisterCommand command);
        Task<ApiResult<LoginResponse>?> RefreshToken();
        Task<ApiResult?> Logout();
    }
}
