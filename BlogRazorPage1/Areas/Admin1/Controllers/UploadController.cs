﻿using BlogRazorPage.Infrastructure;
using BlogRazorPage.Infrastructure.FileUtil.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlogRazorPage.Areas.Admin1.Controllers
{
        [Area("Admin")]
    public class UploadController : Controller
    {
        private readonly IFileService _fileManager;

        public UploadController(IFileService fileManager)
        {
            _fileManager = fileManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("/Upload/Article")]
        public async Task<IActionResult> Image(IFormFile upload)
        {
            if (upload == null)
                BadRequest();

            //var name = Guid.NewGuid() + Path.GetExtension(upload.FileName).ToLower();
            //var path = Path.Combine(Directories.ArticleImages, name);

            //using (var stream = new FileStream(path, FileMode.Create))
            //{
            //    upload.CopyTo(stream);
            //}

            //var url = $"{"/ArticlesImages"}{name}";

            //return new JsonResult(new { uploaded = true, url = url });
            var fileName = await _fileManager.SaveFileAndGenerateName(upload, Directories.ArticleImages);
            return new JsonResult(new { uploaded = true, url = Directories.GetArticleImages(fileName) });

        }
    }
}
