using BlogRazorPage.Infrastructure.RazorUtils;
using BlogRazorPage.Models.Post;
using BlogRazorPage.Models.User;
using BlogRazorPage.Services.Post;
using BlogRazorPage.Services.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlogRazorPage.Pages.Admin.User
{
    public class IndexModel : BaseRazorFilter<UserFilterParams>
    {
      
        public UserFilterResult FilterResult { get; set; }

        private readonly IUserService _service;

        public IndexModel(IUserService service)
        {
            _service = service;
        }

        public async Task OnGet(int pageId = 1, int take = 8, string q="")
        {

            FilterResult = await _service.GetUsersByFilter(new UserFilterParams()
            {
                Name = q,
                Family = q,
                UserName = q,
                PhoneNumber = q,
                PageId = pageId,
                Take = take
            });
        }

        public async Task<IActionResult> OnPostDeleteUser(long id)
        {
            
            return await AjaxTryCatch(() => { return _service.Delete(id); });
      
        }
    }
}
