using AutoMapper;
using Hamporsesh.Application.Core.ViewModels.Users;
using Hamporsesh.Domain.Entities;

namespace Infrastructure.CrossCutting.Mapper.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserOutputDto>();
            CreateMap<User, UserInputDto>();
            CreateMap<User, UserInputDto > ().ForMember(
                  dst => dst.CreateDateTimeStr,
                  src => src.MapFrom(c => c.CreateDateTime.ToPersianDateTimeString())
                );
            CreateMap<UserOutputDto, UserInputDto>();
        }
    }
}
