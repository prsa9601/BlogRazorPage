using Microsoft.AspNetCore.Mvc;

namespace BlogRazorPage.Areas.Admin1.Controllers
{
    [Area("Admin1")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
