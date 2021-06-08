using AutoMapper;
using Hamporsesh.Application.Core.ViewModels.Polls;
using Hamporsesh.Domain.Entities;

namespace Infrastructure.CrossCutting.Mapper.Profiles
{
    class ChoiceProfile : Profile
    {
        public ChoiceProfile()
        {
            //CreateMap<User, UserInput>();

            //CreateMap<BoardInput, UpdateBoardCommand>()
            //   .ConstructUsing(c => new UpdateBoardCommand(c.Id, c.Name, c.Description));

            CreateMap<Choice, PollParticipateDto>();
        }
    }
}
