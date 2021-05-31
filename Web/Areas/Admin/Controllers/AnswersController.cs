using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Hamporsesh.Application.Core.ViewModels.Answers;
using Web.Extensions;

namespace Web.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class AnswersController : Controller
    {
        private readonly AnswerService _answerService;
        private readonly UserService _userService;
        private readonly QuestionService _questionService;

        public AnswersController()
        {
            _answerService = new AnswerService();
            _userService = new UserService();
            _questionService = new QuestionService();
        }


        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public IActionResult Index(long questionId)
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
        public IActionResult Create(long questionId)
        {
            if (!ModelState.IsValid)
            {
                var errors = Utilities.GetModelStateErrors(ModelState);
                return Json(new {result = false, message = errors});
            }

            var model = new AnswerInputViewModel
            {
                QuestionId = questionId
            };
            return View(model);
        }


        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        [Authorize]
        public IActionResult Create(AnswerInputViewModel input)
        {
            if (!ModelState.IsValid)
            {
                var errors = Utilities.GetModelStateErrors(ModelState);
                return Json(new {result = false, message = errors});
            }

            _answerService.Create(input);

            return RedirectToAction("Details","Questions", new {id = input.QuestionId});
        }


        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        [Authorize]
        public IActionResult Details(long id)
        {
            if (!ModelState.IsValid)
            {
                var errors = Utilities.GetModelStateErrors(ModelState);
                return Json(new {result = false, message = errors});
            }

            var answer = _answerService.GetById(id);
            return View(answer);
        }


        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        [Authorize]
        public IActionResult Update(long id)
        {
            if (!ModelState.IsValid)
            {
                var errors = Utilities.GetModelStateErrors(ModelState);
                return Json(new {result = false, message = errors});
            }

            var answer = _answerService.GetById(id);
            var question = _questionService.GetbyId(answer.QuestionId);
            ViewData["PollId"] = question.PollId;

            var ans = _answerService.GetToUpdate(id);
            return View(ans);
        }


        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        [Authorize]
        public IActionResult Update(AnswerInputViewModel input)
        {
            if (!ModelState.IsValid)
            {
                var errors = Utilities.GetModelStateErrors(ModelState);
                return Json(new {result = false, message = errors});
            }

            var answer = _answerService.GetToUpdate(input.Id);
            var question = _questionService.GetbyId(answer.QuestionId);

            _answerService.Update(input);

            return RedirectToAction("Details", "Questions", new {id = question.Id });
        }


        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        [Authorize]
        public IActionResult Delete(long id)
        {
            if (!ModelState.IsValid)
                if (!ModelState.IsValid)
                {
                    var errors = Utilities.GetModelStateErrors(ModelState);
                    return Json(new {result = false, message = errors});
                }

            var ans = _answerService.GetById(id);
            var question = _questionService.GetbyId(ans.QuestionId);

            _answerService.Delete(id);
            return RedirectToAction("Details", "Questions", new {id = question.Id });

        }
    }
}