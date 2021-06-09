using AutoMapper;
using Hamporsesh.Application.Core.ViewModels.Questions;
using Hamporsesh.Domain.Entities;
using Hamporsesh.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Hamporsesh.Application.Questions
{
    public class QuestionService : IQuestionService
    {
        private readonly IMapper _mapper;
        private readonly DbSet<Question> _questions;
        private readonly IUnitOfWork _uow;

        public QuestionService(
            IUnitOfWork uow,
            IMapper mapper
        )
        {
            _uow = uow;
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
        /// 
        /// </summary>
        public long GetUserTotalQuestions(long userId)
        {
            return _questions.Count(q => q.Poll.UserId == userId);
        }


        /// <summary>
        /// </summary>
        public IEnumerable<QuestionOutputDto> GetListByPollId(long pollId)
        {
            var question = _questions.Where(q => q.PollId == pollId);
            return _mapper.Map<IEnumerable<QuestionOutputDto>>(question).ToList();
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
            var questions = _questions.OrderByDescending(q => q.Id);
            return _mapper.Map<IEnumerable<QuestionOutputDto>>(questions).ToList();
        }


        /// <summary>
        /// </summary>
        public void Delete(long id)
        {
            var question = _questions.FirstOrDefault(q => q.Id == id);
            _uow.MarkAsDeleted(question);
        }


        /// <summary>
        /// 
        /// </summary>
        public long GetpollQuestionCount(long id)
        {
            return _questions.Count(q => q.PollId == id);
        }
    }
}