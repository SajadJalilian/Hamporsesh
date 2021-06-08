using Hamporsesh.Application.Core.ViewModels.Polls;
using System.Collections.Generic;

namespace Hamporsesh.Application.Core.ViewModels.Users
{
    public class UserOutputDetailDto
    {
        public UserOutputDto User { get; set; }
        public IEnumerable<PollOutputDto> Polls { get; set; }
    }
}
