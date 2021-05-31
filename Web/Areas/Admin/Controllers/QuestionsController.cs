using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Hamporsesh.Application.Core.ViewModels.Questions;
using Web.Extensions;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class QuestionsController : BaseController
    {
        private readonly UserService _userService;
        private readonly PollService _pollService;
        private readonly QuestionService _questionService;
        private readonly AnswerService _answerService;

        public QuestionsController(AnswerService answerService = null)
        {
            _userService = new UserService();
            _pollService = new PollService();
            _questionService = new QuestionService();
            _answerService = new AnswerService();
        }


        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public IActionResult Index(long pollId)
        {
            if (!ModelState.IsValid)
            {
                var errors = Utilities.GetModelStateErrors(ModelState);
                return Json(new {result = false, message = errors});
            }


            return View();
        }


        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public IActionResult Create(long pollId)
        {
            if (!ModelState.IsValid)
            {
                var errors = Utilities.GetModelStateErrors(ModelState);
                return Json(new {result = false, message = errors});
            }

            var model = new QuestionInputViewModel
            {
                PollId = pollId,
            };
            return View(model);
        }


        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        public IActionResult Create(QuestionInputViewModel input)
        {
            if (!ModelState.IsValid)
            {
                var errors = Utilities.GetModelStateErrors(ModelState);
                return Json(new {result = false, message = errors});
            }

            _questionService.Create(input);

            return RedirectToAction(actionName: nameof(PollsController.Details), controllerName: "polls",
                routeValues: new {id = input.PollId});
        }


        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public IActionResult Details(long id)
        {
            if (!ModelState.IsValid)
            {
                var errors = Utilities.GetModelStateErrors(ModelState);
                return Json(new {result = false, message = errors});
            }

            var model = new QuestionDetailViewModel
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
            if (!ModelState.IsValid)
            {
                var errors = Utilities.GetModelStateErrors(ModelState);
                return Json(new {result = false, message = errors});
            }

            ViewBag.QuestrionTypes = new List<string>() {"0", "1"};
            var question = _questionService.GetToUpdate(id);
            return View(question);
        }


        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        public IActionResult Update(QuestionInputViewModel input)
        {
            if (!ModelState.IsValid)
            {
                var errors = Utilities.GetModelStateErrors(ModelState);
                return Json(new {result = false, message = errors});
            }

            var poll = _pollService.GetById(input.PollId);
            var user = _userService.GetById(poll.UserId);
            var currentUserId = GetCurrentUserId();
            if (user.Id == currentUserId)
            {
                _questionService.Update(input);
            }

            return RedirectToAction("Details", new {id = input.Id});
        }


        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public IActionResult Delete(long id)
        {
            if (!ModelState.IsValid)
            {
                var errors = Utilities.GetModelStateErrors(ModelState);
                return Json(new {result = false, message = errors});
            }

            var question = _questionService.GetbyId(id);
            _questionService.Delete(id);

            return RedirectToAction("Details", "Polls", new {id = question.Id, area = "Admin"});
        }
    }
}