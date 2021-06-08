using Hamporsesh.Application.Core.ViewModels.Choices;
using Hamporsesh.Application.Core.ViewModels.Polls;
using System.Collections.Generic;

namespace Hamporsesh.Application.Core.ViewModels.Users
{
    public class UserOutputPollParticipateDto
    {
        public UserOutputDto User { get; set; }
        public PollOutputDto Poll { get; set; }
        public IEnumerable<ChoiceWithAnswerDto> Choices { get; set; }
    }
}
