using Microsoft.AspNetCore.Mvc;

namespace BlogRazorPage.Areas.Admin1.Controllers
{
        [Area("Admin")]
    public class ckeditorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
