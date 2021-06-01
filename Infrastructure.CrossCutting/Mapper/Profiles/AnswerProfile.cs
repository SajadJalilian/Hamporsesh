using AutoMapper;
using Hamporsesh.Application.Core.ViewModels.Answers;
using Hamporsesh.Domain.Entities;

namespace Infrastructure.CrossCutting.Mapper.Profiles
{
    class AnswerProfile: Profile
    {
        public AnswerProfile()
        {
            //CreateMap<User, UserInput>();
            CreateMap<Answer, AnswerOutputDto>();
            CreateMap<Answer, AnswerInputDto>();
        }
    }
}
