using AutoMapper;
using Hamporsesh.Application.Core.ViewModels.Answers;
using Hamporsesh.Domain.Entities;

namespace Hamporsesh.Infrastructure.CrossCutting.Mapper.Profiles
{
    class AnswerProfile : Profile
    {
        public AnswerProfile()
        {
            CreateMap<Answer, AnswerOutputDto>();
            CreateMap<Answer, AnswerInputDto>();
        }
    }
}
