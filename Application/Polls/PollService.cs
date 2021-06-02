using System.Collections.Generic;
using System.Linq;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public PollService(
            IUnitOfWork uow,
            IMapper mapper
            )
        {
            _uow = uow;
            _mapper = mapper;
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
        public IEnumerable<PollOutputDto> GetAll()
        {
            return _polls.OrderByDescending(u => u.Id)
                .Select(poll => _mapper.Map<PollOutputDto>(poll)).ToList();
        }


        /// <summary>
        /// </summary>
        public void Delete(long id)
        {
            var poll = _polls.FirstOrDefault(u => u.Id == id);
            _uow.MarkAsDeleted(poll);
        }
    }
}