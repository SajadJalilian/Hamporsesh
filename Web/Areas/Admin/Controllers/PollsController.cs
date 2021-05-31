using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Hamporsesh.Application.Core.ViewModels.Answers;
using Hamporsesh.Application.Core.ViewModels.Polls;
using Hamporsesh.Application.Core.ViewModels.Questions;
using Web.Extensions;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class PollsController : BaseController
    {
        private readonly PollService _pollService;
        private readonly QuestionService _questionService;
        private readonly AnswerService _answerService;
        private readonly UserService _userService;
        private readonly ChoiceService _choiceService;
        private readonly VisitorService _visitorService;

        public PollsController()
        {
            _pollService = new PollService();
            _questionService = new QuestionService();
            _answerService = new AnswerService();
            _userService = new UserService();
            _choiceService = new ChoiceService();
            _visitorService = new VisitorService();
        }


        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public IActionResult Index()
        {
            if (!ModelState.IsValid)
            {
                var errors = Utilities.GetModelStateErrors(ModelState);
                return Json(new {result = false, message = errors});
            }

            var polls = _pollService.GetAllAdmin();
            var userId = GetCurrentUserId();
            var user = _userService.GetById(userId);


            //TODO refactor foreach to this Collection.All(c => { c.needsChange = value; return true; });

            foreach (var p in polls)
            {
                p.TotalResponses = _choiceService.GetPollTotalResponses(p.Id);
            }

            var model = new PollIndexViewModelAdmin
            {
                Polls = polls,
                User = user
            };

            return View(model);
        }


        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        [Authorize]
        public IActionResult Create(long userId)
        {
            if (!ModelState.IsValid)
            {
                var errors = Utilities.GetModelStateErrors(ModelState);
                return Json(new {result = false, message = errors});
            }

            var model = new PollInputViewModelAdmin
            {
                UserId = userId,
            };

            return View(model);
        }


        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        [Authorize]
        public IActionResult Create(PollInputViewModelAdmin input)
        {
            if (!ModelState.IsValid)
            {
                var errors = Utilities.GetModelStateErrors(ModelState);
                return Json(new {result = false, message = errors});
            }

            _pollService.Create(input);

            return RedirectToAction("Index");
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

            var poll = _pollService.GetToUpdate(id);
            return View(poll);
        }


        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        [Authorize]
        public IActionResult Update(PollInputViewModelAdmin input)
        {
            if (!ModelState.IsValid)
            {
                var errors = Utilities.GetModelStateErrors(ModelState);
                return Json(new {result = false, message = errors});
            }

            _pollService.Update(input);


            return RedirectToAction("Details", new {id = input.Id});
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

            var questions = _questionService.GetListByPollId(id);
            var poll = _pollService.GetByIdAdmin(id);
            poll.TotalResponses = _choiceService.GetPollTotalResponses(poll.Id);
            var model = new PollDetailsViewModelAdmin
            {
                Poll = poll,
                Questions = questions.Select(question => new QuestionDetailViewModel
                {
                    Question = question,
                    Answers = _answerService.GetListByQuestionId(question.Id)
                }),
                User = _userService.GetById(poll.UserId)
            };

            return View(model);
        }


        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        [Authorize]
        public IActionResult Delete(long id, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                var errors = Utilities.GetModelStateErrors(ModelState);
                return Json(new {result = false, message = errors});
            }

            var poll = _pollService.GetById(id);
            var userId = GetCurrentUserId();
            if (poll.UserId == userId)
            {
                _pollService.Delete(id);
            }

            if (returnUrl is not null)
            {
                return LocalRedirect(returnUrl);
            }

            return RedirectToAction("Index");
        }


        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        [Authorize]
        public IActionResult Results(long id)
        {
            var poll = _pollService.GetById(id);
            var pollQuestions = _questionService.GetListByPollId(id);
            var questions = new List<QuestionResultOutput>();

            foreach (var question in pollQuestions)
            {
                var questionAnswers = _answerService.GetListByQuestionId(question.Id);
                var answerResults = new List<AnswerResultsViewModel>();
                foreach (var ansResult in questionAnswers)
                {
                    answerResults.Add(
                        new AnswerResultsViewModel()
                        {
                            AnswerName = ansResult.Title,
                            TotalResponses = _choiceService.GetAnswerTotalResponses(ansResult.Id)
                        }
                    );
                }

                questions.Add(new QuestionResultOutput()
                {
                    QuestionName = question.Title,
                    AnswersResults = answerResults
                });
            }


            var model = new PollResultsViewModel
            {
                PollTitle = poll.Title,
                TotalResponses = _choiceService.GetPollTotalResponses(id),
                Questions = questions
            };
            return View(model);
        }
    }
}