using BlogRazorPage.Infrastructure.RazorUtils;
using BlogRazorPage.Models.User;
using BlogRazorPage.Services.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace BlogRazorPage.Pages.Admin.User
{
    public class DetailModel : BaseRazorPage
    {
        private readonly IUserService _userService;

        public DetailModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty(SupportsGet = true)]
        public UserDto user { get; set; }
        public async Task OnGet(long Id)
        {
            user = await _userService.GetById(Id);
        }
    }
}
