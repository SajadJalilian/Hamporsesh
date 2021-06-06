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
        private readonly DbSet<Choice> _choices;
        private readonly IMapper _mapper;

        public ChoiceService(
            IUnitOfWork uow,
            IMapper mapper
        )
        {
            _choices = uow.Set<Choice>();
            _mapper = mapper;
        }


        /// <summary>
        ///     لیستی از جواب‌ها میگیرد ذخیره میکند
        /// </summary>
        public void Create(PollParticipateDto input)
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
        /// <param name="pollId"></param>
        /// <returns></returns>
        public long GetPollTotalResponses(long pollId)
        {
              return _choices.Count(c => c.PollId == pollId);
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

        public IEnumerable<ChoiceOutputDto> UserChoices(long userId)
        {
            var userChoices = _choices.Where(r => r.UserId == userId);

            return userChoices.Select(c => _mapper.Map<ChoiceOutputDto>(c));

        }
    }
}