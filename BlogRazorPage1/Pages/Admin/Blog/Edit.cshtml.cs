using System.ComponentModel.DataAnnotations;
using BlogRazorPage.Infrastructure.RazorUtils;
using BlogRazorPage.Models.Category;
using BlogRazorPage.Models.Post;
using BlogRazorPage.Services.Category;
using BlogRazorPage.Services.Post;
using Microsoft.AspNetCore.Mvc;

namespace BlogRazorPage.Pages.Admin.Blog
{
    [BindProperties(SupportsGet = true)]
    public class EditModel : BaseRazorPage
    {
        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [UIHint("Ckeditor4")]
        public string Description { get; set; }
        [Display(Name = "وبلاگ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Title { get; set; }
        [Display(Name = "دسته بندی")]
        [Required(ErrorMessage = "لطفا {0} را انتخاب کنید")]
        public long CategoryId { get; set; }
        //public string MetaTag { get; set; }
        //[Display(Name = "MetaDescription")]
        [Display(Name = "توضیحات ")]
        [Required(ErrorMessage = " {0} را وارد کنید")]
        public string MetaDescription { get; set; }
        [Display(Name = "slug")]
        [Required(ErrorMessage = " {0} را وارد کنید")]
        public string Slug { get; set; }
        [Display(Name = "تصویر شاخص")]
        [Required(ErrorMessage = " {0} را وارد کنید")]
        public IFormFile Image { get; set; }
        public long Id { get; set; }
    
        private readonly IPostService _service;
        
        private readonly ICategoryService _categoryService;

        public EditModel(IPostService service, ICategoryService categoryService)
        {
            _service = service;
            _categoryService = categoryService;
        }
        //[BindProperty(SupportsGet = true)]
        //public PostDto post { get; set; }


        [BindProperty(SupportsGet = true)]
        public List<CategoryDto> CategoryDtos { get; set; }
        public async Task<IActionResult> OnGet(long id)
        {
            CategoryDtos = await _categoryService.GetCategories();
            var post = await _service.GetPostByIdInBack(id);
            Slug = post.Slug;
            Title = post.Title;
            Description = post.Description;
            CategoryId = post.CategoryId;
            Id = post.Id;
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            //if (!User.Identity.IsAuthenticated)
            //{
            //    return RedirectAndShowAlert(ApiResult.Error("شما برای انجام این عملیات باید لاگین کنید."), RedirectToPage("Index"));

            //}
            // var image = _fileManager.SaveFileAndGenerateName(Image, Directories.ProductImages);
            var result = await _service.EditPost(new EditPostCommand()
            {
                CategoryId = CategoryId,
                ImageFile = Image,
                Title = Title,
                Description = Description,
                Slug = Slug,
                Id = Id,
                MetaDescription = MetaDescription
                //UserId = User.GetUserId()

            });
            return RedirectAndShowAlert(result, RedirectToPage("Index"));
        }

    }
}
