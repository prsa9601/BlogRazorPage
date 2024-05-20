using BlogRazorPage.Infrastructure;
using BlogRazorPage.Infrastructure.RazorUtils;
using BlogRazorPage.Models;
using BlogRazorPage.Models.User;
using BlogRazorPage.Services.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace BlogRazorPage.Pages.Admin.User
{
    public class EditModel : BaseRazorPage
    {
        private readonly IUserService _service;

        public EditModel(IUserService service)
        {
            _service = service;
        }

        [Display(Name = "نام کاربری")]
        [BindProperty(SupportsGet = true)]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string UserNamep { get; set; }

        [BindProperty]
        public IFormFile Avatar { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [BindProperty(SupportsGet = true)]
        public string namep { get; set; }

        [BindProperty(SupportsGet = true)]
        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string familyp { get; set; }

        [Display(Name = "شماره تلفن")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [BindProperty(SupportsGet = true)]
        public string PhoneNumberp { get; set; }

        [BindProperty(SupportsGet = true)]
        public long Id { get; set; }

        public async Task OnGet(long Id)
        {
           var user = await _service.GetById(Id);
            Id = user.Id;
            namep = user.Name;
            familyp = user.Family;
            PhoneNumberp = user.PhoneNumber;
           // AvatarName = user.AvatarName;
            UserNamep = user.UserName;
        }
        public async Task<IActionResult> OnPost()
        {
            var result = await _service.Edit(new EditUserCommand(
                Id, Avatar, namep, familyp, PhoneNumberp,
                UserNamep));
           
            if (result.IsSuccess == false)
            {
                ErrorAlert(result.MetaData.Message);
                return Page();
               

            }
            //SuccessAlert("نظر شما ثبت شد ، بعد از تایید در سایت نمایش داده می شود");
            return RedirectAndShowAlert(result, Redirect("Index"));
            // return RedirectToPage("detail", new { id = PostId });
        }
        //public async Task<IActionResult> OnPostSavePic()
        //{
        //    var user = await _service.GetCurrentUser();
        //    var result = await _service.EditUserCurrent(new EditUserCommand(
        //        User.GetUserId(), Avatar, user.Name, user.Family, user.PhoneNumber,
        //        user.UserName));

        //    return RedirectAndShowAlert(result, Redirect("../../profile"));
        //}
    }
}
