using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.Participation.Controllers
{
    [Area("Participation")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
