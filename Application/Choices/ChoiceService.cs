using System;
using System.Collections.Generic;
using System.Linq;
using Hamporsesh.Application.Answers;
using Hamporsesh.Application.Polls;
using Hamporsesh.Application.Users;

namespace Hamporsesh.Application.Choices
{
    public class ChoiceService : IChoiceService
    {
        private readonly MainContext _mainContext;
        private readonly UserService _userService;
        private readonly AnswerService _answerService;
        private readonly PollService _pollService;

        public ChoiceService()
        {
            _mainContext = new MainContext();
            _userService = new UserService();
            _answerService = new AnswerService();
            _pollService = new PollService();
        }


        /// <summary>
        /// لیستی از جواب‌ها میگیرد ذخیره میکند
        /// </summary>
        public void Create(ChoiceInputViewModel input)
        {
            var _choices = _mainContext.Set<Choice>();

            foreach (var question in input.Questions)
            {
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

            _mainContext.SaveChanges();
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<PollOutPutViewModel> GetPollsByParticipatedUserId(long id)
        {
            var userChoices = _mainContext.Choices.Where(r => r.UserId == id);
            var user = _userService.GetById(id);
            var pollIds = new HashSet<long>();
            var polls = new List<PollOutPutViewModel>();

            foreach (var choice in userChoices)
            {
                var poll = _pollService.GetById(choice.PollId);

                if (pollIds.All(c => c != choice.PollId))
                {
                    polls.Add(poll);
                }

                pollIds.Add(choice.PollId);
            }

            return polls.OrderByDescending(p => p.Id)
                .Select(poll => new PollOutPutViewModel
                {
                    Id = poll.Id,
                    Title = poll.Title,
                    UserId = poll.UserId,
                    Description = poll.Description,
                    CreateDateTimeStr = poll.CreateDateTimeStr
                });
        }


        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<ChoiceOutputViewModel> GetUserPollChoices(long userId, long pollid)
        {
            var choices = _mainContext.Set<Choice>();

            return choices.Where(c => c.PollId == pollid && c.UserId == userId)
                .Select(choices => new ChoiceOutputViewModel
                {
                    id = choices.Id,
                    UserId = choices.UserId,
                    Answer = _answerService.GetById(choices.AnswereId)
                }).ToList();
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="pollId"></param>
        /// <returns></returns>
        public long GetPollTotalResponses(long pollId)
        {
            var choices = _mainContext.Set<Choice>();

            return choices.Count(c => c.PollId == pollId);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public long GetAllPollsTotalResponses(long userId)
        {
            var userPolls = _pollService.GetListByUserId(userId);
            var choices = _mainContext.Set<Choice>();
            long totalCount = 0;

            foreach (var poll in userPolls)
            {
                totalCount += choices.Count(c => c.PollId == poll.Id);
            }

            return totalCount;

            // return userPolls.Aggregate<PollOutPutViewModel, long>(0, (totalCount, poll) => totalCount + choices.Count(c => c.PollId == poll.Id));

        }





        /// <summary>
        /// 
        /// </summary>
        public ChoicesLas30DaysViewModel GetLast30DaysResponses()
        {
            var choices = _mainContext.Set<Choice>();
            var firstDay = DateTime.Today.AddDays(-30);
            var allChoices = choices.Where(c => c.CreateDateTime >= firstDay);
            var days = new List<DateTime>();
            var responseCount = new List<long>();
            foreach (DateTime day in EachDay(firstDay, DateTime.Today))
            {
                days.Add(day);
                
                responseCount.Add(
                        allChoices.Count(c => c.CreateDateTime.Date == day.Date)
                    );
            }

            return new ChoicesLas30DaysViewModel
            {
                Days = days,
                ResponseCounts = responseCount
            };
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="thru"></param>
        public IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public long GetAnswerTotalResponses(long id)
        {
            var choices = _mainContext.Set<Choice>();
            return choices.Count(c => c.AnswereId == id);
        }
    }
}