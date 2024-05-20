using BlogRazorPage.Infrastructure.RazorUtils;
using BlogRazorPage.Models.User;
using BlogRazorPage.Services.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace BlogRazorPage.Pages.Admin.User
{
    public class AddModel : BaseRazorPage
    {
        private readonly IUserService _service;

        public AddModel(IUserService service)
        {
            _service = service;
        }

      

        [Display(Name = "???")]
        [Required(ErrorMessage = "{0} ?? ???? ????")]
        [BindProperty(SupportsGet = true)]
        public string name { get; set; }

        [BindProperty(SupportsGet = true)]
        [Display(Name = "??? ????????")]
        [Required(ErrorMessage = "{0} ?? ???? ????")]
        public string family { get; set; }

        [Display(Name = "????? ????")]
        [Required(ErrorMessage = "{0} ?? ???? ????")]
        [BindProperty(SupportsGet = true)]
        public string PhoneNumber { get; set; }

        [Display(Name = "???? ????")]
        [Required(ErrorMessage = "{0} ?? ???? ????")]
        [MinLength(5, ErrorMessage = "???? ???? ???? ?????? ?? 5 ??????? ????")]
        [DataType(DataType.Password)]
        [BindProperty(SupportsGet = true)]
        public string Password { get; set; }

        [Display(Name = "????? ???? ????")]
        [Required(ErrorMessage = "{0} ?? ???? ????")]
        [Compare("Password", ErrorMessage = "???? ??? ????? ????? ??????")]
        [DataType(DataType.Password)]
        [BindProperty(SupportsGet = true)]
        public string ConfirmPassword { get; set; }

        [Display(Name = " نام کاربری")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [BindProperty]
        public string UserName { get; set; }

        //[BindProperty(SupportsGet = true)]
        //public long Id { get; set; }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            var result = await _service.Create(new CreateUserCommand(name,family,PhoneNumber,Password, UserName));
            return RedirectAndShowAlert(result, RedirectToPage("Index"));
        }
    }
}
