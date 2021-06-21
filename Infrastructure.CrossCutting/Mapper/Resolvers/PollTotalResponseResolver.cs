using AutoMapper;
using Hamporsesh.Application.Choices;
using Hamporsesh.Application.Core.ViewModels.Polls;
using Hamporsesh.Domain.Entities;

namespace Hamporsesh.Infrastructure.CrossCutting.Mapper.Resolvers
{
    class PollTotalResponseResolver : IValueResolver<Poll, PollOutputDto, long>
    {
        private readonly IChoiceService _choiceService;

        public PollTotalResponseResolver(IChoiceService choiceService)
        {
            _choiceService = choiceService;
        }

        public long Resolve(Poll source, PollOutputDto destination, long destMember, ResolutionContext context)
        {
            long test = 545452;
            return test;
            return _choiceService.GetPollTotalResponses(source.Id);
        }
    }



}
