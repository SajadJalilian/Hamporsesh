using AutoMapper;
using Hamporsesh.Application.Core.ViewModels.Polls;
using Hamporsesh.Domain.Entities;

namespace Infrastructure.CrossCutting.Mapper.Profiles
{
    class PollProfile : Profile
    {
        public PollProfile()
        {
            CreateMap<Poll, PollInputDto>();
            CreateMap<PollInputDto, Poll>();
            CreateMap<Poll, PollOutputDto>();
            CreateMap<PollOutputDto, Poll>();
        }
    }
}
