using System.Collections.Generic;
using Hamporsesh.Application.Core.ViewModels.Choices;
using Hamporsesh.Application.Core.ViewModels.Polls;

namespace Hamporsesh.Application.Core.ViewModels.Users
{
    public class UserOutputPollParticipateDto
    {
        public UserOutputDto User { get; set; }
        public PollOutputDto Poll { get; set; }
        public IEnumerable<ChoiceOutputDto> Choices { get; set; }
    }
}
