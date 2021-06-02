using Hamporsesh.Application.Polls;
using Hamporsesh.Application.Questions;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPollService _pollService;
        private readonly IQuestionService _questionService;

        public HomeController(
            IPollService pollService,
            IQuestionService questionService
            )
        {
            _pollService = pollService;
            _questionService = questionService;
        }



        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public IActionResult Index()
        {
            var polls = _pollService.GetAll();

            return View(polls);
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
