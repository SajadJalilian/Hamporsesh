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
                  opt => opt.MapFrom(src => src.CreateDateTime.ToPersianDateTimeString())
                );
            CreateMap<PollOutputDto, Poll>();
        }
    }
}
