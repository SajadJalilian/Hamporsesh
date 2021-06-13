using Hamporsesh.Application.Answers;
using Hamporsesh.Application.Core.ViewModels.Questions;
using Hamporsesh.Application.Polls;
using Hamporsesh.Application.Questions;
using Hamporsesh.Application.Users;
using Hamporsesh.Infrastructure.Data.Context;
using Hamporsesh.Web.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Hamporsesh.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class QuestionsController : BaseController
    {

        private readonly IPollService _pollService;
        private readonly IQuestionService _questionService;
        private readonly IAnswerService _answerService;
        private readonly IUserService _userService;
        private readonly IUnitOfWork _uow;

        public QuestionsController(
            IPollService pollService,
            IQuestionService questionService,
            IAnswerService answerService,
            IUserService userService,
            IUnitOfWork uow
        )
        {
            _pollService = pollService;
            _questionService = questionService;
            _answerService = answerService;
            _userService = userService;
            _uow = uow;
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
        [HttpGet]
        public IActionResult Create(long pollId)
        {
            var model = new QuestionInputDto
            {
                PollId = pollId,
            };
            return View(model);
        }


        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        public IActionResult Create(QuestionInputDto input)
        {
            if (!ModelState.IsValid)
                if (!ModelState.IsValid)
                    return Json(new { result = false, message = Utilities.GetModelStateErrors(ModelState) });

            _questionService.Create(input);
            _uow.SaveChanges();

            return RedirectToAction(actionName: nameof(PollsController.Details), controllerName: "polls",
                routeValues: new { id = input.PollId });
        }


        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public IActionResult Details(long id)
        {
            var model = new QuestionDetailDto
            {
                Question = _questionService.GetbyId(id),
                Answers = _answerService.GetListByQuestionId(id)
            };
            return View(model);
        }


        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public IActionResult Update(long id)
        {
            ViewBag.QuestrionTypes = new List<string>() { "0", "1" };
            var question = _questionService.GetToUpdate(id);
            return View(question);
        }


        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        public IActionResult Update(QuestionInputDto input)
        {
            if (!ModelState.IsValid)
                return Json(new { result = false, message = Utilities.GetModelStateErrors(ModelState) });

            var poll = _pollService.GetById(input.PollId);
            var user = _userService.GetById(poll.UserId);
            var currentUserId = GetCurrentUserId();
            if (user.Id == currentUserId)
            {
                _questionService.Update(input);
            }

            return RedirectToAction("Details", new { id = input.Id });
        }


        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public IActionResult Delete(long id)
        {
            var question = _questionService.GetbyId(id);
            var pollId = question.PollId;
            _questionService.Delete(id);
            _uow.SaveChanges();

            return RedirectToAction("Details", "Polls", new { id = pollId, area = "Admin" });
        }
    }
}