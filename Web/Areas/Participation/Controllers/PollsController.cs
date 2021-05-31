using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Hamporsesh.Application.Core.ViewModels.Choices;
using Hamporsesh.Application.Core.ViewModels.Polls;
using Hamporsesh.Application.Core.ViewModels.Questions;
using Web.Extensions;

namespace Web.Areas.Participation.Controllers
{
    [Area("Participation")]
    public class PollsController : Controller
    {
        private readonly PollService _pollService;
        private readonly QuestionService _questionService;
        private readonly VisitorService _visitorService;
        private readonly AnswerService _answerService;
        private readonly ChoiceService _choiceService;

        public PollsController()
        {
            _pollService = new PollService();
            _questionService = new QuestionService();
            _visitorService = new VisitorService();
            _answerService = new AnswerService();
            _choiceService = new ChoiceService();
        }


        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public IActionResult Participate(long id)
        {
            // if (_visitorService.IsDonePollBefore(id, Request.Host.ToString()))
            // {
            //     TempData["message"] = "You Participated in this survey before";
            //     return RedirectToAction(actionName: "index", controllerName: "home");
            // }

            var poll = _pollService.GetByIdAdmin(id);
            var questions = _questionService.GetListByPollId(id);

            var model = new PollDetailsViewModelAdmin()
            {
                Poll = poll,
                Questions = questions.Select(question => new QuestionDetailViewModel
                {
                    Question = question,
                    Answers = _answerService.GetListByQuestionId(question.Id)
                }),
            };

            return View(model);
        }


        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        public IActionResult Participate(ChoiceInputTest input)
        {
            HashSet<long> questionIds = new HashSet<long>();
            foreach (var item in input.AnsweresId)
            {
                var itemArr = item.Split("-");
                questionIds.Add(long.Parse(itemArr[0]));
            }

            try
            {
                if (questionIds.Count() < input.QuestionCount)
                {
                    ModelState.AddModelError("", "You must fill all questions");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "You must fill all questions");
            }

            if (!ModelState.IsValid)
            {
                var errors = Utilities.GetModelStateErrors(ModelState);
                return Json(new {result = false, message = errors});
            }


            var qqq = new List<Question1>();
            foreach (var item in input.AnsweresId)
            {
                var itemArr = item.Split("-");
                qqq.Add(new Question1
                {
                    QuestionId = long.Parse(itemArr[0]),
                    AnsweresId = new long[] {long.Parse(itemArr[1])},
                });
            }


            var model = new ChoiceInputViewModel
            {
                PollId = input.PollId,
                VisitorId = _visitorService.GetOrSetIdByIp(Request.Host.ToString(), input.PollId),
                Questions = qqq,
            };


            _choiceService.Create(model);

            return RedirectToAction("Done");
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Done()
        {
            return View();
        }
    } // class
} // namespace