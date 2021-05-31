using System.Collections.Generic;
using Hamporsesh.Application.Core.ViewModels.Polls;

namespace Hamporsesh.Application.Core.ViewModels.Users

{
    public class ProfileOutputViewModel
    {
        public UserOutputViewModel User { get; set; }

        public IEnumerable<PollOutputViewModelAdmin> Polls { get; set; }
        public IEnumerable<PollOutPutViewModel> ParticipatedPolls { get; set; }
    }
}
