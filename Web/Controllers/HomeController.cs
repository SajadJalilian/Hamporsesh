using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly PollService _pollService;
        private readonly QuestionService _questionService;

        public HomeController()
        {
            _pollService = new PollService();
            _questionService = new QuestionService();
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
