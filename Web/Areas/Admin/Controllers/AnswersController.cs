using Hamporsesh.Application.Answers;
using Hamporsesh.Application.Core.ViewModels.Answers;
using Hamporsesh.Application.Questions;
using Hamporsesh.Infrastructure.Data.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Extensions;

namespace Web.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class AnswersController : Controller
    {
        private readonly IQuestionService _questionService;
        private readonly IAnswerService _answerService;
        private readonly IUnitOfWork _uow;

        public AnswersController(
            IQuestionService questionService,
            IAnswerService answerService,
            IUnitOfWork uow
        )
        {
            _questionService = questionService;
            _answerService = answerService;
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
        public IActionResult Create(long questionId)
        {
            var model = new AnswerInputDto
            {
                QuestionId = questionId
            };
            return View(model);
        }


        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        public IActionResult Create(AnswerInputDto input)
        {
            if (!ModelState.IsValid)
                return Json(new { result = false, message = Utilities.GetModelStateErrors(ModelState) });

            _answerService.Create(input);
            _uow.SaveChanges();

            return RedirectToAction("Details", "Questions", new { id = input.QuestionId });
        }


        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public IActionResult Details(long id)
        {
            var answer = _answerService.GetById(id);
            return View(answer);
        }


        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public IActionResult Update(long id)
        {
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
        public IActionResult Update(AnswerInputDto input)
        {
            if (!ModelState.IsValid)
                return Json(new { result = false, message = Utilities.GetModelStateErrors(ModelState) });

            var answer = _answerService.GetToUpdate(input.Id);
            var question = _questionService.GetbyId(answer.QuestionId);

            _answerService.Update(input);
            _uow.SaveChanges();

            return RedirectToAction("Details", "Questions", new { id = question.Id });
        }


        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public IActionResult Delete(long id)
        {
            var ans = _answerService.GetById(id);
            var question = _questionService.GetbyId(ans.QuestionId);

            _answerService.Delete(id);
            _uow.SaveChanges();
            return RedirectToAction("Details", "Questions", new { id = question.Id });
        }
    }
}