using AutoMapper;
using Hamporsesh.Application.Core.ViewModels.Polls;
using Hamporsesh.Domain.Entities;
using Hamporsesh.Infrastructure.CrossCutting.Mapper.Resolvers;

namespace Hamporsesh.Infrastructure.CrossCutting.Mapper.Profiles
{
    class PollProfile : Profile
    {
        public PollProfile()
        {
            CreateMap<Poll, PollInputDto>();
            CreateMap<PollInputDto, Poll>();
            CreateMap<Poll, PollOutputDto>()
                .ForMember(
                  dest => dest.CreateDateTimeStr,
                  opt => opt.MapFrom(src => src.CreateDateTime.ToPersianDateTimeString()))
                .ForMember(
                    dest => dest.TotalResponses,
                    opt => opt.MapFrom<PollTotalResponseResolver>());
            CreateMap<PollOutputDto, Poll>();
        }
    }
}
