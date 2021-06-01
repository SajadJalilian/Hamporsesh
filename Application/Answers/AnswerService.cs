using AutoMapper;
using Hamporsesh.Application.Core.ViewModels.Answers;
using Hamporsesh.Application.Core.ViewModels.Questions;
using Hamporsesh.Application.Polls;
using Hamporsesh.Application.Questions;
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
        private readonly IPollService _pollService;
        private readonly IQuestionService _questionService;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public AnswerService(
            IPollService pollService,
            IQuestionService questionService,
            IUnitOfWork uow,
            IMapper mapper
        )
        {
            _pollService = pollService;
            _questionService = questionService;
            _uow = uow;
            _mapper = mapper;
            _answers = uow.Set<Answer>();
        }


        /// <summary>
        /// </summary>
        public void Create(AnswerInputDto input)
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
        public void Update(AnswerInputDto input)
        {
            var answer = _answers.FirstOrDefault(
                a => a.Id == input.Id);


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
            return _answers.Where(a => a.QuestionId == QuestionId)
                .Select(answer => _mapper.Map<AnswerOutputDto>(answer)).ToList();
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
            return _answers.OrderByDescending(u => u.Id)
                .Select(answer => _mapper.Map<AnswerOutputDto>(answer)).ToList();
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
        public IEnumerable<AnswerOutputDto> GetAllPollAnswers(long pollId)
        {
            var pollQuestions = _questionService.GetListByPollId(pollId);
            List<AnswerOutputDto> pollAnswers = new();
            foreach (var question in pollQuestions)
                pollAnswers.Add((AnswerOutputDto)_answers.Where(a => a.QuestionId == question.Id)
                    .Select(answer => _mapper.Map<AnswerOutputDto>(answer)));

            return pollAnswers;
        }


        /// <summary>
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public long GetUserTotalAnswers(long userId)
        {
            var userPolls = _pollService.GetListByUserId(userId);
            var userQuestions = new List<QuestionOutputDto>();
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