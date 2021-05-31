using System.Collections.Generic;

namespace Hamporsesh.Application.Polls
{
    public class PollService : IPollService
    {
        private readonly MainContext _mainContext;

        public PollService()
        {
            _mainContext = new MainContext();
        }


        /// <summary>
        /// 
        /// </summary>
        public void Create(PollInputViewModelAdmin input)
        {
            var polls = _mainContext.Set<Poll>();
            var poll = new Poll
            {
                Title = input.Title,
                Description = input.Description,
                UserId = input.UserId
            };

            polls.Add(poll);
            _mainContext.SaveChanges();
        }


        /// <summary>
        /// 
        /// </summary>
        public void Update(PollInputViewModelAdmin input)
        {
            var polls = _mainContext.Set<Poll>();

            var poll = polls.FirstOrDefault(u => u.Id == input.Id);

            poll.Title = input.Title;
            poll.Description = input.Description;
            poll.Status = input.PollStatus;

            _mainContext.Update(poll);
            _mainContext.SaveChanges();
        }


        /// <summary>
        /// 
        /// </summary>
        public PollOutPutViewModel GetById(long id)
        {
            var poll = _mainContext.Polls.FirstOrDefault(u => u.Id == id);

            return new PollOutPutViewModel
            {
                Id = poll.Id,
                Title = poll.Title,
                UserId = poll.UserId,
                Description = poll.Description,
                CreateDateTimeStr = poll.CreateDateTime.ToPersianDateTimeString()
            };
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public long GetUserPollCount(long userId)
        {
            var polls = _mainContext.Set<Poll>();
            return polls.Count(p => p.UserId == userId);
        }


        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<PollOutPutViewModel> GetListByUserId(long userId)
        {
            var polls = _mainContext.Set<Poll>();

            return polls.Where(p => p.UserId == userId).OrderByDescending(u => u.Id)
                .Select(poll => new PollOutPutViewModel
                {
                    Id = poll.Id,
                    Title = poll.Title,
                    UserId = poll.UserId,
                    Description = poll.Description
                }).ToList();
        }


        /// <summary>
        /// 
        /// </summary>
        public PollInputViewModelAdmin GetToUpdate(long id)
        {
            var poll = _mainContext.Polls.FirstOrDefault(u => u.Id == id);

            return new PollInputViewModelAdmin()
            {
                Id = poll.Id,
                Title = poll.Title,
                UserId = poll.UserId,
                Description = poll.Description
            };
        }


        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<PollOutPutViewModel> GetAll()
        {
            var polls = _mainContext.Set<Poll>();

            return polls.OrderByDescending(u => u.Id)
                .Select(poll => new PollOutPutViewModel
                {
                    Id = poll.Id,
                    Title = poll.Title,
                    UserId = poll.UserId,
                    Description = poll.Description
                }).ToList();
        }


        /// <summary>
        /// 
        /// </summary>
        public void Delete(long id)
        {
            var poll = _mainContext.Polls.FirstOrDefault(u => u.Id == id);
            _mainContext.Remove(poll);
            _mainContext.SaveChanges();
        }


        #region Admin

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<PollOutputViewModelAdmin> GetAllAdmin()
        {
            var polls = _mainContext.Set<Poll>();

            return polls.OrderByDescending(u => u.Id)
                .Select(poll => new PollOutputViewModelAdmin
                {
                    Id = poll.Id,
                    Title = poll.Title,
                    UserId = poll.UserId,
                    Description = poll.Description,
                    CreateDateTimeStr = poll.CreateDateTime.ToPersianDateTimeString(),
                    Status = poll.Status

                }).ToList();
        }


        /// <summary>
        /// 
        /// </summary>
        public PollOutputViewModelAdmin GetByIdAdmin(long id)
        {
            var poll = _mainContext.Polls.FirstOrDefault(u => u.Id == id);

            return new PollOutputViewModelAdmin
            {
                Id = poll.Id,
                Title = poll.Title,
                UserId = poll.UserId,
                Description = poll.Description,
                CreateDateTimeStr = poll.CreateDateTime.ToPersianDateTimeString(),
                Status = poll.Status,
            };
        }


        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<PollOutputViewModelAdmin> GetListByUserIdAdmin(long userId)
        {
            var polls = _mainContext.Set<Poll>();

            return polls.Where(p => p.UserId == userId).OrderByDescending(u => u.Id)
                .Select(poll => new PollOutputViewModelAdmin
                {
                    Id = poll.Id,
                    Title = poll.Title,
                    UserId = poll.UserId,
                    Description = poll.Description,
                    CreateDateTimeStr = poll.CreateDateTime.ToPersianDateTimeString(),
                    Status = poll.Status,
                }).ToList();
        }

        #endregion
    }
}