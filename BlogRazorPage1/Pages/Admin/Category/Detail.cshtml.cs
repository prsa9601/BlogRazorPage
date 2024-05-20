using BlogRazorPage.Models.Category;
using BlogRazorPage.Services.Category;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlogRazorPage.Pages.Admin.Category
{
    public class DetailModel : PageModel
    {
        private readonly ICategoryService _categoryService;

        public DetailModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [BindProperty(SupportsGet = true)]
        public CategoryDto category{ get; set; }
        public async Task OnGet(long id)
        {
            category = await _categoryService.GetById(id);
        }
    }
}
