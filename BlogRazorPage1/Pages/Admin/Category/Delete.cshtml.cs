using BlogRazorPage.Infrastructure.RazorUtils;
using BlogRazorPage.Services.Category;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlogRazorPage.Pages.Admin.Category
{
    public class DeleteModel : BaseRazorPage
    {
        private readonly ICategoryService _service;

        public DeleteModel(ICategoryService service)
        {
            _service = service;
        }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostDeleteCategory(long categoryId)
        {
            return await AjaxTryCatch(() => { return _service.Delete(categoryId); });
            //var result =  _service.DeleteProduct(productId);
            //return RedirectToPage("Products");
            //return RedirectToAction("OnGet","Products");
        }
    }
}
