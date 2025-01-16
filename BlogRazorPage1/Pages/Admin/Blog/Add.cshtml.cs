using System.ComponentModel.DataAnnotations;
using System.Net;
using BlogRazorPage.Infrastructure;
using BlogRazorPage.Infrastructure.FileUtil.Interfaces;
using BlogRazorPage.Infrastructure.RazorUtils;
using BlogRazorPage.Models;
using BlogRazorPage.Models.Category;
using BlogRazorPage.Models.Post;
using BlogRazorPage.Services.Category;
using BlogRazorPage.Services.Post;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogRazorPage.Pages.Admin.Blog
{
    [BindProperties]
    public class AddModel : BaseRazorPage
    {
        private readonly IFileService _fileManager;
        private readonly IHostEnvironment _environment;
        private readonly IPostService _service;
        private readonly ICategoryService _categoryService;
        public AddModel(IFileService filemanager, IHostEnvironment environment, IPostService service, ICategoryService categoryService)
        {
            _fileManager = filemanager;
            _environment = environment;
            _service = service;
            _categoryService = categoryService;
        }
        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        [UIHint("Ckeditor4")]
        public string Description { get; set; }

        [Display(Name = " توضیحات")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        public string MetaDescription { get; set; }
        [Display(Name = "وبلاگ")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")] 
        public string Title { get; set; }
        [Display(Name = "دسته بندی")]
        //[Required(ErrorMessage = "لطفا{0} را انتخاب کنید")] 
        public long CategoryId { get; set; }
        //public string MetaTag { get; set; }
        //[Display(Name = "MetaDescription")]
        //[Required(ErrorMessage = "{0} را وارد کنید")]
        //public string MetaDescription { get; set; }
        [Display(Name = "slug")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Slug { get; set; }
        [Display(Name = "تصویر شاخص")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public IFormFile Image { get; set; }

       // [BindProperty(SupportsGet = true)]
       // public List<CategoryDto> CategoryDtos { get; set; }
        public async Task OnGet()
        {
            //CategoryDtos = await _categoryService.GetCategories();
        }
        
        public async Task<IActionResult> OnPost()
        {
            //if (!User.Identity.IsAuthenticated)
            //{
            //    return RedirectAndShowAlert(ApiResult.Error("شما برای انجام این عملیات باید لاگین کنید."), RedirectToPage("Index"));

            //}

            // var image = _fileManager.SaveFileAndGenerateName(Image, Directories.ProductImages);
            var result = await _service.CreatePost(new CreatePostCommand()
            {
                CategoryId = CategoryId,
                ImageFile = Image,
                Title = Title,
                Description = Description,
                Slug = Slug,
                MetaDescription = MetaDescription,
                UserId = User.GetUserId()

            });
            
            return RedirectAndShowAlert(result, RedirectToPage("Index"));
        }
     
      




        ////[Route("/Upload/Article")]
        //public async Task<IActionResult> OnPostUpload(FormFile upload)
        //{
        //    if (upload == null)
        //        BadRequest();

        //    //var name = Guid.NewGuid() + Path.GetExtension(upload.FileName).ToLower();
        //    //var path = Path.Combine(Directories.ArticleImages, name);

        //    //using (var stream = new FileStream(path,FileMode.Create))
        //    //{
        //    //    upload.CopyTo(stream);   
        //    //}

        //    //var url = $"{"/ArticlesImages"}{name}";

        //    //return new JsonResult(new { uploaded = true,url= url });
        //    var fileName = await _fileManager.SaveFileAndGenerateName(upload, Directories.ArticleImages);
        //    return new JsonResult(new { uploaded = true, url = Directories.GetArticleImages(fileName) });
        //}
    }
}
