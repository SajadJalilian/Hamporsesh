using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class HomeController : BaseController
    {

        public HomeController()
        {

        }


        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// 
        /// </summary>
        [HttpGet("/about")]
        public IActionResult About()
        {
            return View();
        }



        /// <summary>
        /// 
        /// </summary>
        [HttpGet("/contact")]
        public IActionResult Contact()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpGet("/service")]
        public IActionResult Service()
        {
            return View();
        }

    }
}
