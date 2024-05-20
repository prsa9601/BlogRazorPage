using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Xml.Linq;
using BlogRazorPage.Infrastructure.RazorUtils;
using BlogRazorPage.Models.Auth;
using BlogRazorPage.Services.Auth;
using BlogRazorPage.Infrastructure.CookieUtils;

namespace BlogRazorPage.Pages.Auth
{
    [BindProperties]
    [ValidateAntiForgeryToken]
    public class LoginModel : BaseRazorPage
    {
        private readonly IAuthService _authService;
       // private readonly ClaimsPrincipal User ;
        private readonly ShopCartCookieManager _shopCartCookieManager;
        public LoginModel(IAuthService authService, ShopCartCookieManager shopCartCookieManager)
        {
            _authService = authService;
            _shopCartCookieManager = shopCartCookieManager;
        }

        [Display(Name = "شماره تلفن")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string PhoneNumber { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [MinLength(5, ErrorMessage = "کلمه عبور باید بزرگتر ار 5 کاراکتر باشد")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string? RedirectTo { get; set; }
        public IActionResult OnGet(string redirectTo)
        {
            //if (User.Identity.IsAuthenticated)
            //    return Redirect("/");

            RedirectTo = redirectTo;
            return Page(); 
        }

        //public async Task<IActionResult> OnPost()
        //{
        //    var result = await _authService.Login(new LoginCommand()
        //    {
        //        Password = Password,
        //        PhoneNumber = PhoneNumber
        //    });
        //    if (result.IsSuccess == false)
        //    {
        //        ModelState.AddModelError(nameof(PhoneNumber), result.MetaData.Message);
        //        return Page();
        //    }
        //    return Page();
        //}

        public async Task<IActionResult> OnPost()
        {
            var result = await _authService.Login(new LoginCommand()
            {
                Password = Password,
                PhoneNumber = PhoneNumber
            });
            if (result.IsSuccess == false)
            {
                ModelState.AddModelError(nameof(PhoneNumber), result.MetaData.Message);
                return Page();
            }

            var token = result.Data.Token;
            var refreshToken = result.Data.RefreshToken;
            HttpContext.Response.Cookies.Append("token", token, new CookieOptions()
            {
                HttpOnly = true,
                Expires = DateTimeOffset.Now.AddDays(7)
            });
            HttpContext.Response.Cookies.Append("refresh-token", refreshToken, new CookieOptions()
            {
                HttpOnly = true,
                Expires = DateTimeOffset.Now.AddDays(10)
            });

            //await SyncShopCart(token);
            if (string.IsNullOrWhiteSpace(RedirectTo) == false)
            {
                return LocalRedirect(RedirectTo);
            }
            return Redirect("/front/blog");
        }

        //private async Task SyncShopCart(string token)
        //{
        //    var shopCart = _shopCartCookieManager.GetShopCart();
        //    if (shopCart == null || shopCart.Items.Any() == false)
        //        return;

        //    HttpContext.Request.Headers.Append("Authorization", $"Bearer {token}");
        //    var handler = new JwtSecurityTokenHandler();
        //    var jwtSecurityToken = handler.ReadJwtToken(token);

        //    var userId = Convert.ToInt64(jwtSecurityToken.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);
        //    foreach (var item in shopCart.Items)
        //    {
        //        await _orderService.AddOrderItem(new AddOrderItemCommand()
        //        {
        //            Count = item.Count,
        //            UserId = userId,
        //            InventoryId = item.InventoryId
        //        });
        //    }
        //    _shopCartCookieManager.DeleteShopCart();
        //}
    }
}
