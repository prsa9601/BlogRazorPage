using BlogRazorPage.Infrastructure;
using BlogRazorPage.Infrastructure.FileUtil.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlogRazorPage.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IFileService _fileManager;

        public IndexModel(ILogger<IndexModel> logger, IFileService fileManager)
        {
            _logger = logger;
            _fileManager = fileManager;
        }

        public void OnGet()
        {

        }
        
       // [Route("/Index/Upload")]
        public async Task<IActionResult> OnPostUpload([FromForm]IFormFile upload)
        {
            if (upload == null)
                BadRequest();

            //var name = Guid.NewGuid() + Path.GetExtension(upload.FileName).ToLower();
            //var path = Path.Combine(Directories.ArticleImages, name);

            //using (var stream = new FileStream(path,FileMode.Create))
            //{
            //    upload.CopyTo(stream);   
            //}

            //var url = $"{"/ArticlesImages"}{name}";

            //return new JsonResult(new { uploaded = true,url= url });
            var fileName = await _fileManager.SaveFileAndGenerateName(upload, Directories.ArticleImages);
            return new JsonResult(new { uploaded = true, url = Directories.GetArticleImages(fileName) });
        }

    }
}