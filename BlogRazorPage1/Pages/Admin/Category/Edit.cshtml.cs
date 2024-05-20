using BlogRazorPage.Infrastructure.RazorUtils;
using BlogRazorPage.Models.Category;
using BlogRazorPage.Services.Category;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BlogRazorPage.Pages.Admin.Category
{
    [BindProperties]
    public class EditModel : BaseRazorPage
    {
        private readonly ICategoryService _service;

        public EditModel(ICategoryService service)
        {
            _service = service;
        }
        [Display(Name = "عنوان دسته بندی")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Title { get; set; }
        [Display(Name = "MetaTag(با-از هم جدا کنید)")]
        public string MetaTag { get; set; }
        [Display(Name = "MetaDescription")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string MetaDescription { get; set; }
        [Display(Name = "slug")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Slug { get; set; }
        public long Id { get; set; }
        [BindProperty(SupportsGet = true)]
        public CategoryDto categoryDto { get; set; }
        public async Task OnGet(long id)
        {
            categoryDto = await _service.GetById(id);
        }
        public async Task<IActionResult> OnPost()
        {
            var result = await _service.Edit(new EditCategoryCommand()
            {
                Id = categoryDto.Id,
                Title = Title,
                MetaTag = MetaTag,
                MetaDescription = MetaDescription,
                Slug = Slug
            });
            return RedirectAndShowAlert(result, RedirectToPage("Index"));
        }
    }
}
