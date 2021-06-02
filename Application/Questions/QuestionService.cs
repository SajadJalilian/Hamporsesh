using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Hamporsesh.Application.Core.ViewModels.Questions;
using Hamporsesh.Application.Polls;
using Hamporsesh.Application.Users;
using Hamporsesh.Domain.Entities;
using Hamporsesh.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Hamporsesh.Application.Questions
{
    public class QuestionService : IQuestionService
    {
        private readonly IPollService _pollService;
        private readonly IMapper _mapper;
        private readonly DbSet<Question> _questions;
        private readonly IUnitOfWork _uow;
        private readonly IUserService _userService;

        public QuestionService(
            IUserService userService,
            IUnitOfWork uow,
            IPollService pollService,
            IMapper mapper
        )
        {
            _userService = userService;
            _uow = uow;
            _pollService = pollService;
            _mapper = mapper;
            _questions = uow.Set<Question>();
        }


        /// <summary>
        /// </summary>
        public void Create(QuestionInputDto input)
        {
            var question = _mapper.Map<Question>(input);
            _questions.Add(question);
        }


        /// <summary>
        /// </summary>
        public void Update(QuestionInputDto input)
        {

            var question = _questions.FirstOrDefault(u => u.Id == input.Id);

            question.Title = input.Title;
            question.Type = input.Type;

            _questions.Update(question);
        }

        /// <summary>
        /// </summary>
        public QuestionOutputDto GetbyId(long id)
        {
            var question = _questions.FirstOrDefault(u => u.Id == id);

            return _mapper.Map<QuestionOutputDto>(question);
        }


        /// <summary>
        /// </summary>
        public IEnumerable<QuestionOutputDto> GetListByPollId(long pollId)
        {
            return _questions.Where(q => q.PollId == pollId)
                .Select(question => _mapper.Map<QuestionOutputDto>(question)).ToList();
        }


        /// <summary>
        /// </summary>
        public QuestionInputDto GetToUpdate(long id)
        {
            var question = _questions.FirstOrDefault(q => q.Id == id);
            return _mapper.Map<QuestionInputDto>(question);
        }


        /// <summary>
        /// </summary>
        public IEnumerable<QuestionOutputDto> GetAll()
        {
            return _questions.OrderByDescending(q => q.Id)
                .Select(question => _mapper.Map<QuestionOutputDto>(question)).ToList();
        }


        /// <summary>
        /// </summary>
        public void Delete(long id)
        {
            var question = _questions.FirstOrDefault(q => q.Id == id);
            _uow.MarkAsDeleted(question);
        }


        /// <summary>
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public long GetUserTotalQuestions(long userId)
        {
            var user = _userService.GetById(userId);
            var userPolls = _pollService.GetListByUserId(userId);
            long totalCount = 0;

            foreach (var poll in userPolls) totalCount += _questions.Count(q => q.PollId == poll.Id);

            return totalCount;
        }
    }
}