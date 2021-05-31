using System.Collections.Generic;
using Hamporsesh.Application.Polls;
using Hamporsesh.Application.Questions;

namespace Hamporsesh.Application.Answers
{
    public class AnswerService : IAnswerService
    {
        private readonly MainContext _mainContext;
        private readonly QuestionService _questionService;
        private readonly PollService _pollService;

        public AnswerService()
        {
            _mainContext = new MainContext();
            _questionService = new QuestionService();
            _pollService = new PollService();
        }


        /// <summary>
        /// 
        /// </summary>
        public void Create(AnswerInputViewModel input)
        {
            var mContext = new MainContext();
            var answers = mContext.Set<Answer>();
            var answer = new Answer
            {
                Title = input.Title,
                QuestionId = input.QuestionId
            };
            answers.Add(answer);
            mContext.SaveChanges();
        }


        /// <summary>
        /// 
        /// </summary>
        public void Update(AnswerInputViewModel input)
        {
            var mContext = new MainContext();
            var answer = mContext.Answers.FirstOrDefault(
                a => a.Id == input.Id);


            answer.Title = input.Title;

            mContext.Update(answer);
            mContext.SaveChanges();
        }


        /// <summary>
        /// 
        /// </summary>
        public AnswerOutputViewModel GetById(long id)
        {
            var mContext = new MainContext();
            var answer = mContext.Answers.FirstOrDefault(a => a.Id == id);

            return new AnswerOutputViewModel
            {
                Id = answer.Id,
                Title = answer.Title,
                QuestionId = answer.QuestionId
            };
        }


        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<AnswerOutputViewModel> GetListByQuestionId(long QuestionId)
        {
            var mContext = new MainContext();
            var answers = mContext.Set<Answer>();

            return answers.Where(a => a.QuestionId == QuestionId)
                .Select(answer => new AnswerOutputViewModel
                {
                    Id = answer.Id,
                    Title = answer.Title,
                    QuestionId = answer.QuestionId
                }).ToList();
        }


        /// <summary>
        /// 
        /// </summary>
        public AnswerInputViewModel GetToUpdate(long id)
        {
            var mContext = new MainContext();
            var answer = mContext.Answers.FirstOrDefault(a => a.Id == id);

            return new AnswerInputViewModel
            {
                Id = answer.Id,
                QuestionId = answer.QuestionId,
                Title = answer.Title,
            };
        }


        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<AnswerOutputViewModel> GetAll()
        {
            var mContext = new MainContext();
            var answers = mContext.Set<Answer>();

            return answers.OrderByDescending(u => u.Id)
                .Select(answer => new AnswerOutputViewModel
                {
                    Id = answer.Id,
                    Title = answer.Title,
                    QuestionId = answer.QuestionId
                }).ToList();
        }


        /// <summary>
        /// 
        /// </summary>
        public void Delete(long id)
        {
            var mContext = new MainContext();
            var answer = mContext.Answers.FirstOrDefault(a => a.Id == id);
            mContext.Remove(answer);
            mContext.SaveChanges();
        }


        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<AnswerOutputViewModel> GetAllPollAnswers(long pollId)
        {
            var answers = _mainContext.Set<Answer>();

            var pollQuestions = _questionService.GetListByPollId(pollId);
            List<AnswerOutputViewModel> pollAnswers = new();
            foreach (var question in pollQuestions)
            {
                pollAnswers.Add((AnswerOutputViewModel) answers.Where(a => a.QuestionId == question.Id)
                    .Select(answer => new AnswerOutputViewModel
                    {
                        Id = answer.Id,
                        QuestionId = answer.QuestionId,
                        Title = answer.Title
                    }));
            }

            return pollAnswers;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public long GetUserTotalAnswers(long userId)
        {
            var answers = _mainContext.Set<Answer>();
            var userPolls = _pollService.GetListByUserId(userId);
            var userQuestions = new List<QuestionOutputViewModel>();
            var totalCount = 0;

            foreach (var poll in userPolls)
            {
                userQuestions.AddRange(
                    _questionService.GetListByPollId(poll.Id)
                );
            }

            foreach (var question in userQuestions)
            {
                totalCount += answers.Count(a => a.QuestionId == question.Id);
            }

            return totalCount;
        }
    }
}