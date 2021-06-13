using AutoMapper;
using Hamporsesh.Application.Core.ViewModels.Questions;
using Hamporsesh.Domain.Entities;

namespace Hamporsesh.Infrastructure.CrossCutting.Mapper.Profiles
{
    class QuestionProfile : Profile
    {
        public QuestionProfile()
        {
            // <source -> destination>
            CreateMap<QuestionInputDto, Question>();
            CreateMap<Question, QuestionInputDto>();
            CreateMap<QuestionOutputDto, Question>();
            CreateMap<Question, QuestionOutputDto>();
        }
    }
}
