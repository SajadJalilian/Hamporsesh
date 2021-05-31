using System.Collections.Generic;
using Hamporsesh.Application.Core.ViewModels.Polls;
using Hamporsesh.Domain.Entities;
using Hamporsesh.Infrastructure.Data.Context;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Hamporsesh.Application.Polls
{
    public class PollService : IPollService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Poll> _polls;

        public PollService(IUnitOfWork uow)
        {
            _uow = uow;
            _polls = uow.Set<Poll>();
        }


        /// <summary>
        /// 
        /// </summary>
        public void Create(PollInputViewModelAdmin input)
        {
          
            var poll = new Poll
            {
                Title = input.Title,
                Description = input.Description,
                UserId = input.UserId
            };

            _polls.Add(poll);
            _uow.SaveChanges();
        }


        /// <summary>
        /// 
        /// </summary>
        public void Update(PollInputViewModelAdmin input)
        {
            var polls = _uow.Set<Poll>();

            var poll = polls.FirstOrDefault(u => u.Id == input.Id);

            poll.Title = input.Title;
            poll.Description = input.Description;
            poll.Status = input.PollStatus;

            _uow.MarkAsModified(poll);
            _uow.SaveChanges();
        }


        /// <summary>
        /// 
        /// </summary>
        public PollOutPutViewModel GetById(long id)
        {
            var poll = _polls.FirstOrDefault(u => u.Id == id);

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
            var polls = _uow.Set<Poll>();
            return polls.Count(p => p.UserId == userId);
        }


        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<PollOutPutViewModel> GetListByUserId(long userId)
        {
            var polls = _uow.Set<Poll>();

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
            var poll = _polls.FirstOrDefault(u => u.Id == id);

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
            var polls = _uow.Set<Poll>();

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
            var poll = _polls.FirstOrDefault(u => u.Id == id);
            _uow.MarkAsDeleted(poll);
            _uow.SaveChanges();
        }


        #region Admin

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<PollOutputViewModelAdmin> GetAllAdmin()
        {
            var polls = _uow.Set<Poll>();

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
            var poll = _polls.FirstOrDefault(u => u.Id == id);

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
            var polls = _uow.Set<Poll>();

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