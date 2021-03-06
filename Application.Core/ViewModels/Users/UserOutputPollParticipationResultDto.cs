using Hamporsesh.Application.Core.ViewModels.Choices;
using Hamporsesh.Application.Core.ViewModels.Polls;
using System.Collections.Generic;

namespace Hamporsesh.Application.Core.ViewModels.Users
{
    public class UserOutputPollParticipationResultDto
    {
        public PollOutputDto Poll { get; set; }
        public UserInputDto User { get; set; }
        public IEnumerable<ChoiceOutputDto> Choices { get; set; }
    }
}
