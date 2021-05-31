using System.Collections.Generic;
using Hamporsesh.Application.Polls;
using Hamporsesh.Application.Users;

namespace Hamporsesh.Application.Questions
{
    public class QuestionService : IQuestionService
    {
        private readonly UserService _userService;
        private readonly MainContext _mainContext;
        private readonly PollService _pollService;

        public QuestionService()
        {
            _mainContext = new MainContext();
            _userService = new UserService();
            _pollService = new PollService();
        }


        /// <summary>
        /// 
        /// </summary>
        public void Create(QuestionInputViewModel input)
        {
            var questions = _mainContext.Set<Question>();
            var question = new Question
            {
                Title = input.Title,
                Type = input.Type,
                PollId = input.PollId
            };

            questions.Add(question);
            _mainContext.SaveChanges();
        }


        /// <summary>
        /// 
        /// </summary>
        public void Update(QuestionInputViewModel input)
        {
            var questions = _mainContext.Set<Question>();

            var question = questions.FirstOrDefault(u => u.Id == input.Id);

            question.Title = input.Title;
            question.Type = input.Type;

            questions.Update(question);
            _mainContext.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        public QuestionOutputViewModel GetbyId(long id)
        {
            var question = _mainContext.Questions.FirstOrDefault(u => u.Id == id);

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
            var questions = _mainContext.Set<Question>();

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
            var questions = _mainContext.Set<Question>();
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
            var questions = _mainContext.Set<Question>();

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
            var question = _mainContext.Questions.FirstOrDefault(q => q.Id == id);
            _mainContext.Remove(question);
            _mainContext.SaveChanges();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public long GetUserTotalQuestions(long userId)
        {
            var questions = _mainContext.Set<Question>();
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