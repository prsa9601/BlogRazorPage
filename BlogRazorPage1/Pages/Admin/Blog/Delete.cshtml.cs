
using BlogRazorPage.Infrastructure.RazorUtils;
using BlogRazorPage.Services.Post;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlogRazorPage.Pages.Admin.Blog
{
    public class DeleteModel : BaseRazorPage
    {
        private readonly IPostService _service;

        public DeleteModel(IPostService service)
        {
            _service = service;
        }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostDeleteBlog(long blogId)
        {
            return await AjaxTryCatch(() => { return _service.DeletePost(blogId); });
            //var result =  _service.DeleteProduct(productId);
            //return RedirectToPage("Products");
            //return RedirectToAction("OnGet","Products");
        }
    }
}
