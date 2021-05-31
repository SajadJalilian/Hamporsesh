using System.Collections.Generic;
using Hamporsesh.Application.Core.ViewModels.Users;

namespace Hamporsesh.Application.Core.ViewModels.Polls
{
    public class PollIndexViewModelAdmin
    {
        public UserOutputViewModel User { get; set; }
        public IEnumerable<PollOutputViewModelAdmin> Polls { get; set; }
    }
}
