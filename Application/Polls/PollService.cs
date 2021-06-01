using System.Collections.Generic;
using System.Linq;
using Hamporsesh.Application.Core.ViewModels.Polls;
using Hamporsesh.Domain.Entities;
using Hamporsesh.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Hamporsesh.Application.Polls
{
    public class PollService : IPollService
    {
        private readonly DbSet<Poll> _polls;
        private readonly IUnitOfWork _uow;

        public PollService(IUnitOfWork uow)
        {
            _uow = uow;
            _polls = uow.Set<Poll>();
        }


        /// <summary>
        /// </summary>
        public void Create(PollInputDto input)
        {
            var poll = new Poll
            {
                Title = input.Title,
                Description = input.Description,
                UserId = input.UserId
            };

            _polls.Add(poll);
        }


        /// <summary>
        /// </summary>
        public void Update(PollInputDto input)
        {
            var poll = _polls.FirstOrDefault(u => u.Id == input.Id);

            poll.Title = input.Title;
            poll.Description = input.Description;
            poll.Status = input.PollStatus;

            _uow.MarkAsModified(poll);
        }


        /// <summary>
        /// </summary>
        public PollOutputDto GetById(long id)
        {
            var poll = _polls.FirstOrDefault(u => u.Id == id);

            return new PollOutputDto
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
                .Select(poll => new PollOutputDto
                {
                    Id = poll.Id,
                    Title = poll.Title,
                    UserId = poll.UserId,
                    Description = poll.Description
                }).ToList();
        }


        /// <summary>
        /// </summary>
        public PollInputDto GetToUpdate(long id)
        {
            var poll = _polls.FirstOrDefault(u => u.Id == id);

            return new PollInputDto
            {
                Id = poll.Id,
                Title = poll.Title,
                UserId = poll.UserId,
                Description = poll.Description
            };
        }


        /// <summary>
        /// </summary>
        public IEnumerable<PollOutputDto> GetAll()
        {
            return _polls.OrderByDescending(u => u.Id)
                .Select(poll => new PollOutputDto
                {
                    Id = poll.Id,
                    Title = poll.Title,
                    UserId = poll.UserId,
                    Description = poll.Description
                }).ToList();
        }


        /// <summary>
        /// </summary>
        public void Delete(long id)
        {
            var poll = _polls.FirstOrDefault(u => u.Id == id);
            _uow.MarkAsDeleted(poll);
        }


        #region Admin

        /// <summary>
        /// </summary>
        public IEnumerable<PollOutputViewModelAdmin> GetAllAdmin()
        {
            return _polls.OrderByDescending(u => u.Id)
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
                Status = poll.Status
            };
        }


        /// <summary>
        /// </summary>
        public IEnumerable<PollOutputViewModelAdmin> GetListByUserIdAdmin(long userId)
        {
            return _polls.Where(p => p.UserId == userId).OrderByDescending(u => u.Id)
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

        #endregion
    }
}