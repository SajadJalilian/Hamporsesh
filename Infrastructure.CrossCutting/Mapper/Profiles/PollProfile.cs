using AutoMapper;
using Hamporsesh.Application.Core.ViewModels.Polls;
using Hamporsesh.Domain.Entities;

namespace Hamporsesh.Infrastructure.CrossCutting.Mapper.Profiles
{
    class PollProfile : Profile
    {
        public PollProfile()
        {
            CreateMap<Poll, PollInputDto>();
            CreateMap<PollInputDto, Poll>();
            CreateMap<Poll, PollOutputDto>().ForMember(
                  dest => dest.CreateDateTimeStr,
                  src => src.MapFrom(d => d.CreateDateTime.ToPersianDateTimeString())
                );
            CreateMap<PollOutputDto, Poll>();
        }
    }
}
