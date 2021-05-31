using System.Collections.Generic;
using Hamporsesh.Application.Core.ViewModels.Questions;
using Hamporsesh.Application.Polls;
using Hamporsesh.Application.Users;
using Hamporsesh.Domain.Entities;
using Hamporsesh.Infrastructure.Data.Context;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Hamporsesh.Application.Questions
{
    public class QuestionService : IQuestionService
    {
        private readonly IUserService _userService;
        private readonly IUnitOfWork _uow;
        private readonly IPollService _pollService;
        private readonly DbSet<Question> _questions;

        public QuestionService(
            IUserService userService,
            IUnitOfWork uow,
            IPollService pollService
            )
        {
            _userService = userService;
            _uow = uow;
            _pollService = pollService;
            _questions = uow.Set<Question>();
        }


        /// <summary>
        /// 
        /// </summary>
        public void Create(QuestionInputViewModel input)
        {
            var questions = _uow.Set<Question>();
            var question = new Question
            {
                Title = input.Title,
                Type = input.Type,
                PollId = input.PollId
            };

            questions.Add(question);
            _uow.SaveChanges();
        }


        /// <summary>
        /// 
        /// </summary>
        public void Update(QuestionInputViewModel input)
        {
            var questions = _uow.Set<Question>();

            var question = questions.FirstOrDefault(u => u.Id == input.Id);

            question.Title = input.Title;
            question.Type = input.Type;

            questions.Update(question);
            _uow.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        public QuestionOutputViewModel GetbyId(long id)
        {
            var question = _questions.FirstOrDefault(u => u.Id == id);

            return new QuestionOutputViewModel
            {
                Id = question.Id,
                Title = question.Title,
                Type = question.Type,
                PollId = question.PollId
            };
        }


        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<QuestionOutputViewModel> GetListByPollId(long pollId)
        {
            var questions = _uow.Set<Question>();

            return questions.Where(q => q.PollId == pollId)
                .Select(question => new QuestionOutputViewModel
                {
                    Id = question.Id,
                    Title = question.Title,
                    Type = question.Type,
                    PollId = question.PollId,
                    CreateDateTime = question.CreateDateTime,
                }).ToList();
        }


        /// <summary>
        /// 
        /// </summary>
        public QuestionInputViewModel GetToUpdate(long id)
        {
            var questions = _uow.Set<Question>();
            var question = questions.FirstOrDefault(q => q.Id == id);

            return new QuestionInputViewModel
            {
                Id = question.Id,
                PollId = question.PollId,
                Title = question.Title,
                Type = question.Type
            };
        }


        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<QuestionOutputViewModel> GetAll()
        {
            var questions = _uow.Set<Question>();

            return questions.OrderByDescending(q => q.Id)
                .Select(question => new QuestionOutputViewModel
                {
                    Id = question.Id,
                    PollId = question.PollId,
                    Title = question.Title,
                    Type = question.Type
                }).ToList();
        }


        /// <summary>
        /// 
        /// </summary>
        public void Delete(long id)
        {
            var question = _questions.FirstOrDefault(q => q.Id == id);
            _uow.MarkAsDeleted(question);
            _uow.SaveChanges();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public long GetUserTotalQuestions(long userId)
        {
            var questions = _uow.Set<Question>();
            var user = _userService.GetById(userId);
            var userPolls = _pollService.GetListByUserId(userId);
            long totalCount = 0;

            foreach (var poll in userPolls)
            {
                totalCount += questions.Count(q => q.PollId == poll.Id);
            }

            return totalCount;
        }
    }
}