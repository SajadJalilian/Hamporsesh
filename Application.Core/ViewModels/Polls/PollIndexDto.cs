using System.Collections.Generic;
using Hamporsesh.Application.Core.ViewModels.Users;

namespace Hamporsesh.Application.Core.ViewModels.Polls
{
    public class PollIndexDto
    {
        public UserOutputDto User { get; set; }
        public IEnumerable<PollOutputViewModelAdmin> Polls { get; set; }
    }
}
