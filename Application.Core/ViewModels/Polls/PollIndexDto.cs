using Hamporsesh.Application.Core.ViewModels.Users;
using System.Collections.Generic;

namespace Hamporsesh.Application.Core.ViewModels.Polls
{
    public class PollIndexDto
    {
        public UserOutputDto User { get; set; }
        public IEnumerable<PollOutputDto> Polls { get; set; }
    }
}
