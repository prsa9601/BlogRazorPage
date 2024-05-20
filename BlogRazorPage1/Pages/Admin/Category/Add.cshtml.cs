using BlogRazorPage.Infrastructure.RazorUtils;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using BlogRazorPage.Models.Category;
using BlogRazorPage.Services.Category;

namespace BlogRazorPage.Pages.Admin.Category
{
    [BindProperties]
    public class AddModel : BaseRazorPage
    {
        private readonly ICategoryService _service;

        public AddModel(ICategoryService service)
        {
            _service = service;
        }

        [Display(Name = "عنوان دسته بندی")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Title { get; set; }
        [Display(Name ="MetaTag(با-از هم جدا کنید)")]
        public string MetaTag { get; set; }
        [Display(Name = "MetaDescription")]
        [Required(ErrorMessage = "{0} را وارد کنید")] 
        public string MetaDescription { get; set; }
        [Display(Name = "slug")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Slug { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            var result = await _service.Create(new CreateCategoryCommand()
            {
                Title = Title,
                MetaTag = MetaTag,
                MetaDescription = MetaDescription,
                Slug = Slug
            });
            return RedirectAndShowAlert(result, RedirectToPage("Index"));
        }
    }
}
