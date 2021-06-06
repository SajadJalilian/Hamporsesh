using AutoMapper;
using Hamporsesh.Application.Answers;
using Hamporsesh.Application.Choices;
using Hamporsesh.Application.Core.ViewModels.Answers;
using Hamporsesh.Application.Core.ViewModels.Choices;
using Hamporsesh.Application.Core.ViewModels.Polls;
using Hamporsesh.Application.Core.ViewModels.Questions;
using Hamporsesh.Application.Questions;
using Hamporsesh.Application.Users;
using Hamporsesh.Application.Visitors;
using Hamporsesh.Domain.Entities;
using Hamporsesh.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hamporsesh.Application.Polls
{
    public class PollService : IPollService
    {
        private readonly DbSet<Poll> _polls;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IQuestionService _questionService;
        private readonly IChoiceService _choiceService;
        private readonly IAnswerService _answerService;
        private readonly IUserService _userService;
        private readonly IVisitorService _visitorService;

        public PollService(
            IUnitOfWork uow,
            IMapper mapper,
            IQuestionService questionService,
            IChoiceService choiceService,
            IAnswerService answerService,
            IUserService userService,
            IVisitorService visitorService
            )
        {
            _uow = uow;
            _mapper = mapper;
            _questionService = questionService;
            _choiceService = choiceService;
            _answerService = answerService;
            _userService = userService;
            _visitorService = visitorService;
            _polls = uow.Set<Poll>();
        }


        /// <summary>
        /// </summary>
        public void Create(PollInputDto input)
        {
            _polls.Add(_mapper.Map<Poll>(input));
        }


        /// <summary>
        /// </summary>
        public void Update(PollInputDto input)
        {
            var poll = _polls.FirstOrDefault(u => u.Id == input.Id);

            _uow.MarkAsModified(_mapper.Map(input, poll));
        }


        /// <summary>
        /// </summary>
        public PollOutputDto GetById(long id)
        {
            var poll = _polls.FirstOrDefault(u => u.Id == id);

            return
                new PollOutputDto
                {
                    Id = poll.Id,
                    Title = poll.Title,
                    UserId = poll.UserId,
                    Description = poll.Description,
                    CreateDateTimeStr = poll.CreateDateTime.ToPersianDateTimeString()
                };
        }


        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public long GetUserPollCount(long userId)
        {
            return _polls.Count(p => p.UserId == userId);
        }


        /// <summary>
        /// </summary>
        public IEnumerable<PollOutputDto> GetListByUserId(long userId)
        {
            return _polls.Where(p => p.UserId == userId).OrderByDescending(u => u.Id)
                .Select(poll => _mapper.Map<PollOutputDto>(poll)).ToList();
        }


        /// <summary>
        /// </summary>
        public PollInputDto GetToUpdate(long id)
        {
            var poll = _polls.FirstOrDefault(u => u.Id == id);

            return _mapper.Map<PollInputDto>(poll);
        }


        /// <summary>
        /// </summary>
        public IEnumerable<PollOutputDto> GetAll(long userId)
        {
            return _polls.OrderByDescending(u => u.Id == userId)
                .Select(poll => _mapper.Map<PollOutputDto>(poll)).ToList();
        }


        /// <summary>
        /// </summary>
        public void Delete(long id)
        {
            var poll = _polls.FirstOrDefault(u => u.Id == id);
            _uow.MarkAsDeleted(poll);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<PollOutputDto> GetAllUserPolls(long id)
        {
            return _polls.OrderByDescending(u => u.Id == id)
                .Select(poll => _mapper.Map<PollOutputDto>(poll));
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PollDetailsDto GetPollDetails(long id)
        {
            var questions = _questionService.GetListByPollId(id);
            var poll = GetById(id);
            poll.TotalResponses = _choiceService.GetPollTotalResponses(poll.Id);
            var model = new PollDetailsDto
            {
                Poll = poll,
                Questions = questions.Select(question => new QuestionDetailDto
                {
                    Question = question,
                    Answers = _answerService.GetListByQuestionId(question.Id)
                }),
                User = _userService.GetById(poll.UserId)
            };
            return model;
        }

        public PollResultsDto GetPollResult(long id)
        {
            var poll = GetById(id);
            var pollQuestions = _questionService.GetListByPollId(id);
            var questions = new List<QuestionResultOutputDto>();

            foreach (var question in pollQuestions)
            {
                var questionAnswers = _answerService.GetListByQuestionId(question.Id);
                var answerResults = new List<AnswerResultsDto>();
                foreach (var ansResult in questionAnswers)
                {
                    answerResults.Add(
                        new AnswerResultsDto()
                        {
                            AnswerName = ansResult.Title,
                            TotalResponses = _choiceService.GetAnswerTotalResponses(ansResult.Id)
                        }
                    );
                }

                questions.Add(new QuestionResultOutputDto()
                {
                    QuestionName = question.Title,
                    AnswersResults = answerResults
                });
            }

            var model = new PollResultsDto
            {
                PollTitle = poll.Title,
                TotalResponses = _choiceService.GetPollTotalResponses(id),
                Questions = questions
            };

            return model;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public PollParticipateDto Participate(PollParticipateDto input, string ip)
        {
            var questionDetailList = new List<QuestionAnswersDto>();
            foreach (var item in input.AnsweresId)
            {
                var itemArr = item.Split("-");
                questionDetailList.Add(new QuestionAnswersDto
                {
                    QuestionId = long.Parse(itemArr[0]),
                    AnsweresId = new long[] { long.Parse(itemArr[1]) },
                });
            }


            var model = new PollParticipateDto
            {
                PollId = input.PollId,
                VisitorId = _visitorService.GetOrSetIdByIp(ip, input.PollId),
                Questions = questionDetailList,
            };

            return model;
        }


        /// <summary>
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public long GetUserTotalQuestions(long userId)
        {
            var userPolls = GetListByUserId(userId);
            long totalCount = 0;

            foreach (var poll in userPolls) totalCount += _questionService.GetpollQuestionCount(poll.Id);
                   
            return totalCount;
        }




        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<PollOutputDto> GetPollsByParticipatedUserId(long id)
        {
            var userChoices = _choiceService.UserChoices(id);
            var user = _userService.GetById(id);
            var pollIds = new HashSet<long>();
            var polls = new List<PollOutputDto>();

            foreach (var choice in userChoices)
            {
                var poll = GetById(choice.PollId);

                if (pollIds.All(c => c != choice.PollId)) polls.Add(poll);

                pollIds.Add(choice.PollId);
            }

            return polls.OrderByDescending(p => p.Id)
                .Select(poll => _mapper.Map<PollOutputDto>(poll));
        }


        /// <summary>
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public long GetAllPollsTotalResponses(long userId)
        {
            var userPolls = GetListByUserId(userId);
            long totalCount = 0;
            foreach (var poll in userPolls) totalCount += _choiceService.GetPollTotalResponses(poll.Id);

            return totalCount;
        }



        /// <summary>
        /// </summary>
        public IEnumerable<ChoiceWithAnswerDto> GetUserPollChoices(long userId, long pollid)
        {
            var choices = _uow.Set<Choice>();

            return choices.Where(c => c.PollId == pollid && c.UserId == userId)
                .Select(choices =>

                new ChoiceWithAnswerDto
                {
                    Id = choices.Id,
                    UserId = choices.UserId,
                    Answer = _answerService.GetById(choices.AnswereId)
                }

                ).ToList();
        }



        /// <summary>
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public long GetUserTotalAnswers(long userId)
        {
            var userPolls = GetListByUserId(userId);
            var userQuestions = new List<QuestionOutputDto>();
            long totalCount = 0;

            foreach (var poll in userPolls)
                userQuestions.AddRange(
                    _questionService.GetListByPollId(poll.Id)
                );

            foreach (var question in userQuestions) totalCount += _answerService.GetAnswerQuestionCount(question.Id);

            return totalCount;
        }



        /// <summary>
        /// </summary>
        public IEnumerable<AnswerOutputDto> GetAllPollAnswers(long pollId)
        {
            var pollQuestions = _questionService.GetListByPollId(pollId);
            List<AnswerOutputDto> pollAnswers = new();
            foreach (var question in pollQuestions)
            {
                var questionAnswers = _answerService.GetAnswerByQuestionId(question.Id);
                pollAnswers.AddRange(questionAnswers.ToList());
            }

            return pollAnswers;
        }
    }
}