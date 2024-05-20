using BlogRazorPage.Infrastructure;
using BlogRazorPage.Infrastructure.RazorUtils;
using BlogRazorPage.Models.User;
using BlogRazorPage.Services.Auth;
using BlogRazorPage.Services.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BlogRazorPage.Pages.Profile
{   
    [Authorize]
   // [AutoValidateAntiforgeryToken]
    public class IndexModel : BaseRazorPage
    {
        private readonly IUserService _service;
        private readonly IAuthService _authService;
        public IndexModel(IUserService service, IAuthService authService)
        {
            _service = service;
            _authService = authService;
        }
        //[BindProperty(SupportsGet = true)]
        //public UserDto user { get; set; }

        [Display(Name = "نام کاربری")]
        [BindProperty]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string UserNamep { get; set; }
       
        [BindProperty]
        public IFormFile Avatar { get; set; }
        
        [Display(Name = "نام")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [BindProperty]
        public string namep { get; set; }
        
        [BindProperty]
        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string familyp { get; set; }

        [Display(Name = "شماره تلفن")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [BindProperty]
        public string PhoneNumberp { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [BindProperty]
        public string Email { get; set; }


        public async Task<IActionResult> OnGet()
        {
            if (!User.Identity.IsAuthenticated)
                return Redirect("/auth/login");
           // user = await _service.GetCurrentUser();
            return Page();
        }

        //public async Task<IActionResult> OnPost()
        //{
        //    return await AjaxTryCatch(() => { return _service.EditUserCurrent(new EditUserCommand(
        //        User.GetUserId(), Avatar, Name, Family, PhoneNumber,
        //        userName));
        //    });
        //}
        public async Task<IActionResult> OnPost()
        {
            var result = await _service.EditUserCurrent(new EditUserCommand(
                User.GetUserId(), Avatar, namep, familyp, PhoneNumberp,
                UserNamep));
            if (result.IsSuccess == false)
            {
                ErrorAlert(result.MetaData.Message);
                return Page();
            }
            //SuccessAlert("نظر شما ثبت شد ، بعد از تایید در سایت نمایش داده می شود");
            return Page();
            // return RedirectToPage("detail", new { id = PostId });
        }
        public async Task<IActionResult> OnPostLogOut()
        {
            var result = await _authService.Logout();

            if (result.IsSuccess)
            {
                HttpContext.Response.Cookies.Delete("token");
                HttpContext.Response.Cookies.Delete("refresh-token");
            }
            return RedirectAndShowAlert(result, Redirect("../../Front/blog/Index"));
        }
        public async Task<IActionResult> OnPostSavePic()
        {
            var user = await _service.GetCurrentUser();
            var result = await _service.EditUserCurrent(new EditUserCommand(
                User.GetUserId(), Avatar, user.Name, user.Family, user.PhoneNumber,
                user.UserName));
          
            
            return RedirectAndShowAlert(result, Redirect("../../profile"));
        }
    }
}
