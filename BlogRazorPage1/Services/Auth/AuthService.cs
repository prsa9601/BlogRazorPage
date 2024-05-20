using BlogRazorPage.Models.Auth;
using BlogRazorPage.Models;

namespace BlogRazorPage.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _client;
        private readonly IHttpContextAccessor _accessor;
        public AuthService(HttpClient client, IHttpContextAccessor accessor)
        {
            //HttpClientHandler clientHandler = new HttpClientHandler();
            //clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            //_client = new HttpClient(clientHandler);
            _client = client;
            _accessor = accessor;
        }

        public async Task<ApiResult<LoginResponse>?> Login(LoginCommand command)
        {
            var result = await _client.PostAsJsonAsync("Auth/login", command);
            return await result.Content.ReadFromJsonAsync<ApiResult<LoginResponse>>();
        }

        public async Task<ApiResult?> Register(RegisterCommand command)
        {
             var result = await _client.PostAsJsonAsync($"auth/register", command);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult<LoginResponse>?> RefreshToken()
        {
            var refreshToken = _accessor.HttpContext.Request.Cookies["refreshToken"];
            var result = await _client.PostAsync($"auth/refreshToken?refreshToken={refreshToken}", null);
            return await result.Content.ReadFromJsonAsync<ApiResult<LoginResponse>>();
        }

        public async Task<ApiResult?> Logout()
        {
            try
            {
                var result = await _client.DeleteAsync("auth/logout");
                return await result.Content.ReadFromJsonAsync<ApiResult>();
            }
            catch (Exception e)
            {
                return ApiResult.Error();
            }
        }
    }
}
