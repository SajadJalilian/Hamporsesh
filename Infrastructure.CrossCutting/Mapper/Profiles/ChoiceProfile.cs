using AutoMapper;
using Hamporsesh.Application.Core.ViewModels.Polls;
using Hamporsesh.Domain.Entities;

namespace Infrastructure.CrossCutting.Mapper.Profiles
{
    class ChoiceProfile : Profile
    {
        public ChoiceProfile()
        {
            CreateMap<Choice, PollParticipateDto>();
        }
    }
}
