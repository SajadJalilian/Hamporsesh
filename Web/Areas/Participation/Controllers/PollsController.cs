using Hamporsesh.Application.Answers;
using Hamporsesh.Application.Choices;
using Hamporsesh.Application.Core.ViewModels.Polls;
using Hamporsesh.Application.Core.ViewModels.Questions;
using Hamporsesh.Application.Polls;
using Hamporsesh.Application.Questions;
using Hamporsesh.Application.Visitors;
using Hamporsesh.Infrastructure.Data.Context;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Web.Extensions;

namespace Web.Areas.Participation.Controllers
{
    [Area("Participation")]
    public class PollsController : Controller
    {
        private readonly IPollService _pollService;
        private readonly IQuestionService _questionService;
        private readonly IAnswerService _answerService;
        private readonly IChoiceService _choiceService;
        private readonly IVisitorService _visitorService;
        private readonly IUnitOfWork _uow;

        public PollsController(
            IPollService pollService,
            IQuestionService questionService,
            IAnswerService answerService,
            IChoiceService choiceService,
            IVisitorService visitorService,
            IUnitOfWork uow
        )
        {
            _pollService = pollService;
            _questionService = questionService;
            _answerService = answerService;
            _choiceService = choiceService;
            _visitorService = visitorService;
            _uow = uow;
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

            var poll = _pollService.GetById(id);
            var questions = _questionService.GetListByPollId(id);

            var model = new PollDetailsDto()
            {
                Poll = poll,
                Questions = questions.Select(question => new QuestionDetailDto
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
        public IActionResult Participate(PollParticipateDto input)
        {
            if (!ModelState.IsValid)
                return Json(new { result = false, message = Utilities.GetModelStateErrors(ModelState) });

            HashSet<long> questionIds = new();
            foreach (var item in input.AnsweresId)
            {
                var itemArr = item.Split("-");
                questionIds.Add(long.Parse(itemArr[0]));
            }

            try
            {
                if (questionIds.Count < input.QuestionCount)
                {
                    ModelState.AddModelError("", "You must fill all questions");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "You must fill all questions");
            }

            _choiceService.Create(_pollService.GetParticipate(input, Request.Host.ToString()));
            _uow.SaveChanges();

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
} // name space