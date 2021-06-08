using AutoMapper;
using Hamporsesh.Application.Core.ViewModels.Questions;
using Hamporsesh.Domain.Entities;

namespace Infrastructure.CrossCutting.Mapper.Profiles
{
    class QuestionProfile : Profile
    {
        public QuestionProfile()
        {
            CreateMap<QuestionInputDto, Question>();
            CreateMap<Question, QuestionInputDto>();
        }
    }
}
