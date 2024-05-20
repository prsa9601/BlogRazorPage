using BlogRazorPage.Infrastructure.RazorUtils;
using BlogRazorPage.Models.Category;
using BlogRazorPage.Models.Post;
using BlogRazorPage.Services.Category;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlogRazorPage.Pages.Admin.Category
{
        [BindProperties(SupportsGet = true)]
    public class IndexModel : BaseRazorPage
    {
        private readonly ICategoryService _service;

        public IndexModel(ICategoryService service)
        {
            _service = service;
        }

        public List<CategoryDto> category { get; set; }
        public async Task OnGet()
        {
            category = await _service.GetCategories();
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
