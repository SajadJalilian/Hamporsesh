using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Hamporsesh.Application.Core.ViewModels.Dashboard;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class DashboardController : BaseController
    {
        private readonly PollService _pollService;
        private readonly ChoiceService _choiceService;
        private readonly UserService _userService;
        private readonly QuestionService _questionService;
        private readonly AnswerService _answerService;

        public DashboardController()
        {
            _pollService = new PollService();
            _choiceService = new ChoiceService();
            _userService = new UserService();
            _questionService = new QuestionService();
            _answerService = new AnswerService();
        }


        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public IActionResult Index()
        {
            var user = _userService.GetById(GetCurrentUserId());
            var polls = _pollService.GetAllAdmin();
            var chart = _choiceService.GetLast30DaysResponses();
            var days = chart.Days.Select(d => d.ToPersianDateTimeString());
            var responses = chart.ResponseCounts.Select(r => long.Parse(r.ToString()));


            var model = new DashboardViewModel
            {
                Polls = polls,
                Days = days,
                Responses = responses,
                TotalPolls = _pollService.GetUserPollCount(user.Id),
                TotalResponses = _choiceService.GetAllPollsTotalResponses(user.Id),
                TotalQuestions = _questionService.GetUserTotalQuestions(user.Id),
                TotalAnswers = _answerService.GetUserTotalAnswers(user.Id)
            };


            return View(model);
        }
    }
}