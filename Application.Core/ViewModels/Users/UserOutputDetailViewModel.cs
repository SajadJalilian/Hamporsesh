using System.Collections.Generic;
using Hamporsesh.Application.Core.ViewModels.Polls;

namespace Hamporsesh.Application.Core.ViewModels.Users
{
    public class UserOutputDetailViewModel
    {
        public UserOutputViewModel User { get; set; }
        public IEnumerable<PollOutPutViewModel> Polls { get; set; }
    }
}
