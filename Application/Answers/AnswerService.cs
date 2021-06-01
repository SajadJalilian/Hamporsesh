using System.Collections.Generic;
using System.Linq;
using Hamporsesh.Application.Core.ViewModels.Answers;
using Hamporsesh.Application.Core.ViewModels.Questions;
using Hamporsesh.Application.Polls;
using Hamporsesh.Application.Questions;
using Hamporsesh.Domain.Entities;
using Hamporsesh.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Hamporsesh.Application.Answers
{
    public class AnswerService : IAnswerService
    {
        private readonly DbSet<Answer> _answers;
        private readonly IPollService _pollService;
        private readonly IQuestionService _questionService;
        private readonly IUnitOfWork _uow;


        public AnswerService(
            IPollService pollService,
            IQuestionService questionService,
            IUnitOfWork uow
        )
        {
            _pollService = pollService;
            _questionService = questionService;
            _uow = uow;
            _answers = uow.Set<Answer>();
        }


        /// <summary>
        /// </summary>
        public void Create(AnswerInputViewModel input)
        {
            var answer = new Answer
            {
                Title = input.Title,
                QuestionId = input.QuestionId
            };
            _answers.Add(answer);
        }


        /// <summary>
        /// </summary>
        public void Update(AnswerInputViewModel input)
        {
            var answer = _answers.FirstOrDefault(
                a => a.Id == input.Id);


            answer.Title = input.Title;

            _uow.MarkAsModified(answer);
        }


        /// <summary>
        /// </summary>
        public AnswerOutputViewModel GetById(long id)
        {
            var answer = _answers.FirstOrDefault(a => a.Id == id);

            return new AnswerOutputViewModel
            {
                Id = answer.Id,
                Title = answer.Title,
                QuestionId = answer.QuestionId
            };
        }


        /// <summary>
        /// </summary>
        public IEnumerable<AnswerOutputViewModel> GetListByQuestionId(long QuestionId)
        {
            return _answers.Where(a => a.QuestionId == QuestionId)
                .Select(answer => new AnswerOutputViewModel
                {
                    Id = answer.Id,
                    Title = answer.Title,
                    QuestionId = answer.QuestionId
                }).ToList();
        }


        /// <summary>
        /// </summary>
        public AnswerInputViewModel GetToUpdate(long id)
        {
            var answer = _answers.FirstOrDefault(a => a.Id == id);

            return new AnswerInputViewModel
            {
                Id = answer.Id,
                QuestionId = answer.QuestionId,
                Title = answer.Title
            };
        }


        /// <summary>
        /// </summary>
        public IEnumerable<AnswerOutputViewModel> GetAll()
        {
            return _answers.OrderByDescending(u => u.Id)
                .Select(answer => new AnswerOutputViewModel
                {
                    Id = answer.Id,
                    Title = answer.Title,
                    QuestionId = answer.QuestionId
                }).ToList();
        }


        /// <summary>
        /// </summary>
        public void Delete(long id)
        {
            var answer = _answers.FirstOrDefault(a => a.Id == id);
            _uow.MarkAsDeleted(answer);
        }


        /// <summary>
        /// </summary>
        public IEnumerable<AnswerOutputViewModel> GetAllPollAnswers(long pollId)
        {
            var pollQuestions = _questionService.GetListByPollId(pollId);
            List<AnswerOutputViewModel> pollAnswers = new();
            foreach (var question in pollQuestions)
                pollAnswers.Add((AnswerOutputViewModel) _answers.Where(a => a.QuestionId == question.Id)
                    .Select(answer => new AnswerOutputViewModel
                    {
                        Id = answer.Id,
                        QuestionId = answer.QuestionId,
                        Title = answer.Title
                    }));

            return pollAnswers;
        }


        /// <summary>
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public long GetUserTotalAnswers(long userId)
        {
            var userPolls = _pollService.GetListByUserId(userId);
            var userQuestions = new List<QuestionOutputViewModel>();
            var totalCount = 0;

            foreach (var poll in userPolls)
                userQuestions.AddRange(
                    _questionService.GetListByPollId(poll.Id)
                );

            foreach (var question in userQuestions) totalCount += _answers.Count(a => a.QuestionId == question.Id);

            return totalCount;
        }
    }
}