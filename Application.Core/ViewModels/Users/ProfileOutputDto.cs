using System.Collections.Generic;
using Hamporsesh.Application.Core.ViewModels.Polls;

namespace Hamporsesh.Application.Core.ViewModels.Users

{
    public class ProfileOutputDto
    {
        public UserOutputDto User { get; set; }

        public IEnumerable<PollOutputDto> Polls { get; set; }
        public IEnumerable<PollOutputDto> ParticipatedPolls { get; set; }
    }
}
