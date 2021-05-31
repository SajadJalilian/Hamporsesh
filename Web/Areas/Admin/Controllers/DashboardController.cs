using System.Linq;
using Hamporsesh.Application.Answers;
using Hamporsesh.Application.Choices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Hamporsesh.Application.Core.ViewModels.Dashboard;
using Hamporsesh.Application.Polls;
using Hamporsesh.Application.Questions;
using Hamporsesh.Application.Users;
using Hamporsesh.Application.Visitors;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class DashboardController : BaseController
    {
        private readonly IPollService _pollService;
        private readonly IQuestionService _questionService;
        private readonly IAnswerService _answerService;
        private readonly IUserService _userService;
        private readonly IChoiceService _choiceService;


        public DashboardController(
            IPollService pollService,
            IQuestionService questionService,
            IAnswerService answerService,
            IUserService userService,
            IChoiceService choiceService
        )
        {
            _pollService = pollService;
            _questionService = questionService;
            _answerService = answerService;
            _userService = userService;
            _choiceService = choiceService;
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