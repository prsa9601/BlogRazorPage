using BlogRazorPage.Infrastructure.RazorUtils;
using BlogRazorPage.Services.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlogRazorPage.Pages.Admin.User
{
    public class DeleteModel : BaseRazorPage
    {
        private readonly IUserService _service;

        public DeleteModel(IUserService service)
        {
            _service = service;
        }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostDeleteUser(long id)
        {

            var result = await _service.Delete(id);
            return RedirectAndShowAlert(result, RedirectToPage("Index"));
        }
    }
}
