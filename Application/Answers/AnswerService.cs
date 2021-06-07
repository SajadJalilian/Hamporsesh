using AutoMapper;
using Hamporsesh.Application.Core.ViewModels.Answers;
using Hamporsesh.Domain.Entities;
using Hamporsesh.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Hamporsesh.Application.Answers
{
    public class AnswerService : IAnswerService
    {
        private readonly DbSet<Answer> _answers;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public AnswerService(
            IUnitOfWork uow,
            IMapper mapper
        )
        {
            _uow = uow;
            _mapper = mapper;
            _answers = uow.Set<Answer>();
        }


        /// <summary>
        /// </summary>
        public void Create(AnswerInputDto input)
        {
            var answer = new Answer { Title = input.Title, QuestionId = input.QuestionId };
            _answers.Add(answer);
        }


        /// <summary>
        /// </summary>
        public void Update(AnswerInputDto input)
        {
            var answer = _answers.FirstOrDefault(a => a.Id == input.Id);
            answer.Title = input.Title;
            _uow.MarkAsModified(answer);
        }


        /// <summary>
        /// </summary>
        public AnswerOutputDto GetById(long id)
        {
            var answer = _answers.FirstOrDefault(a => a.Id == id);
            return _mapper.Map<AnswerOutputDto>(answer);
        }


        /// <summary>
        /// </summary>
        public IEnumerable<AnswerOutputDto> GetListByQuestionId(long QuestionId)
        {
            var answers = _answers.Where(a => a.QuestionId == QuestionId);
            return _mapper.Map<IEnumerable<AnswerOutputDto>>(answers);
        }


        /// <summary>
        /// </summary>
        public AnswerInputDto GetToUpdate(long id)
        {
            var answer = _answers.FirstOrDefault(a => a.Id == id);
            return _mapper.Map<AnswerInputDto>(answer);
        }


        /// <summary>
        /// </summary>
        public IEnumerable<AnswerOutputDto> GetAll()
        {
            var answers = _answers.OrderByDescending(u => u.Id);
            return _mapper.Map<IEnumerable<AnswerOutputDto>>(answers);
        }


        /// <summary>
        /// </summary>
        public void Delete(long id)
        {
            var answer = _answers.FirstOrDefault(a => a.Id == id);
            _uow.MarkAsDeleted(answer);
        }


        /// <summary>
        /// 
        /// </summary>
        public long GetAnswerQuestionCount(long id)
        {
            return _answers.Count(a => a.QuestionId == id);
        }


        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<AnswerOutputDto> GetAnswerByQuestionId(long id)
        {
            var answers = _answers.Where(a => a.QuestionId == id);
            return _mapper.Map<IEnumerable<AnswerOutputDto>>(answers);
        }


        /// <summary>
        /// </summary>
        public long GetUserTotalAnswers(long userId)
        {
            return _answers.Count(a => a.Question.Poll.UserId == userId);
        }


        /// <summary>
        /// </summary>
        public IEnumerable<AnswerOutputDto> GetAllPollAnswers(long pollId)
        {
            var answers = _answers.Where(a => a.Question.PollId == pollId);
            return _mapper.Map<IEnumerable<AnswerOutputDto>>(answers);
        }
    }
}