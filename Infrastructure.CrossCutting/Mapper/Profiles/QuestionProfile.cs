using AutoMapper;
using Hamporsesh.Application.Core.ViewModels.Questions;
using Hamporsesh.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
