using AutoMapper;
using Hamporsesh.Application.Core.ViewModels.Choices;
using Hamporsesh.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.CrossCutting.Mapper.Profiles
{
    class ChoiceProfile : Profile
    {
        public ChoiceProfile()
        {
            //CreateMap<User, UserInput>();

            //CreateMap<BoardInput, UpdateBoardCommand>()
            //   .ConstructUsing(c => new UpdateBoardCommand(c.Id, c.Name, c.Description));

            CreateMap<Choice, ChoiceInputDto>();
        }
    }
}
