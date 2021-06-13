using Hamporsesh.Application.Answers;
using Hamporsesh.Application.Choices;
using Hamporsesh.Application.Core.ViewModels.Dashboard;
using Hamporsesh.Application.Polls;
using Hamporsesh.Application.Questions;
using Hamporsesh.Application.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Hamporsesh.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class DashboardController : BaseController
    {
        private readonly IPollService _pollService;
        private readonly IQuestionService _questionService;
        private readonly IUserService _userService;
        private readonly IChoiceService _choiceService;
        private readonly IAnswerService _answerService;


        public DashboardController(
            IPollService pollService,
            IQuestionService questionService,
            IUserService userService,
            IChoiceService choiceService,
            IAnswerService answerService)
        {
            _pollService = pollService;
            _questionService = questionService;
            _userService = userService;
            _choiceService = choiceService;
            _answerService = answerService;
        }


        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public IActionResult Index()
        {
            var user = _userService.GetById(GetCurrentUserId());
            var polls = _pollService.GetAll(GetCurrentUserId());
            var chart = _choiceService.GetLast30DaysResponses();
            var days = chart.Days.Select(d => d.ToPersianDateString());
            var responses = chart.ResponseCounts.Select(r => long.Parse(r.ToString()));


            var model = new DashboardDto
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