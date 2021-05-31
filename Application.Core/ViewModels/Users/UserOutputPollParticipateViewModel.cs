using System.Collections.Generic;
using Hamporsesh.Application.Core.ViewModels.Choices;

namespace Hamporsesh.Application.Core.ViewModels.Users
{
    public class UserOutputPollParticipateViewModel
    {
        public UserOutputViewModel User { get; set; }
        public PollOutPutViewModel Poll { get; set; }
        public IEnumerable<ChoiceOutputViewModel> Choices { get; set; }
    }
}
