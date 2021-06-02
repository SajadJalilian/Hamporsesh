using AutoMapper;
using Hamporsesh.Application.Answers;
using Hamporsesh.Application.Core.ViewModels.Choices;
using Hamporsesh.Application.Core.ViewModels.Polls;
using Hamporsesh.Application.Polls;
using Hamporsesh.Application.Users;
using Hamporsesh.Domain.Entities;
using Hamporsesh.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hamporsesh.Application.Choices
{
    public class ChoiceService : IChoiceService
    {
        private readonly IAnswerService _answerService;
        private readonly DbSet<Choice> _choices;
        private readonly IPollService _pollService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly IUserService _userService;


        public ChoiceService(
            IUnitOfWork uow,
            IUserService userService,
            IAnswerService answerService,
            IPollService pollService,
            IMapper mapper
        )
        {
            _uow = uow;
            _userService = userService;
            _answerService = answerService;
            _pollService = pollService;
            _mapper = mapper;
            _choices = uow.Set<Choice>();
        }


        /// <summary>
        ///     لیستی از جواب‌ها میگیرد ذخیره میکند
        /// </summary>
        public void Create(ChoiceInputDto input)
        {

            foreach (var question in input.Questions)
                foreach (var answereId in question.AnsweresId)
                {
                    var choice = new Choice
                    {
                        PollId = input.PollId,
                        QuestionId = question.QuestionId,
                        AnswereId = answereId,
                        VisitorId = input.VisitorId,
                        UserId = input.ParticipateUserId
                    };

                    _choices.Add(choice);
                }
        }


        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<PollOutputDto> GetPollsByParticipatedUserId(long id)
        {
            var userChoices = _choices.Where(r => r.UserId == id);
            var user = _userService.GetById(id);
            var pollIds = new HashSet<long>();
            var polls = new List<PollOutputDto>();

            foreach (var choice in userChoices)
            {
                var poll = _pollService.GetById(choice.PollId);

                if (pollIds.All(c => c != choice.PollId)) polls.Add(poll);

                pollIds.Add(choice.PollId);
            }

            return polls.OrderByDescending(p => p.Id)
                .Select(poll => _mapper.Map<PollOutputDto>(poll));
        }


        /// <summary>
        /// </summary>
        public IEnumerable<ChoiceOutputDto> GetUserPollChoices(long userId, long pollid)
        {
            var choices = _uow.Set<Choice>();

            return choices.Where(c => c.PollId == pollid && c.UserId == userId)
                .Select(choices =>

                new ChoiceOutputDto
                {
                    id = choices.Id,
                    UserId = choices.UserId,
                    Answer = _answerService.GetById(choices.AnswereId)
                }

                ).ToList();
        }


        /// <summary>
        /// </summary>
        /// <param name="pollId"></param>
        /// <returns></returns>
        public long GetPollTotalResponses(long pollId)
        {
              return _choices.Count(c => c.PollId == pollId);
        }


        /// <summary>
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public long GetAllPollsTotalResponses(long userId)
        {
            var userPolls = _pollService.GetListByUserId(userId);
            long totalCount = 0;
            foreach (var poll in userPolls) totalCount += _choices.Count(c => c.PollId == poll.Id);

            return totalCount;
        }


        /// <summary>
        /// </summary>
        public ChoicesLas30DaysDto GetLast30DaysResponses()
        {
            var firstDay = DateTime.Today.AddDays(-30);
            var allChoices = _choices.Where(c => c.CreateDateTime >= firstDay);
            var days = new List<DateTime>();
            var responseCount = new List<long>();
            foreach (var day in EachDay(firstDay, DateTime.Today))
            {
                days.Add(day);

                responseCount.Add(
                    allChoices.Count(c => c.CreateDateTime.Date == day.Date)
                );
            }

            return new ChoicesLas30DaysDto
            {
                Days = days,
                ResponseCounts = responseCount
            };
        }


        /// <summary>
        /// </summary>
        /// <param name="from"></param>
        /// <param name="thru"></param>
        public IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }


        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public long GetAnswerTotalResponses(long id)
        {
            return _choices.Count(c => c.AnswereId == id);
        }
    }
}