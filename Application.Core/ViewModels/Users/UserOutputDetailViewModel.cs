using System.Collections.Generic;

namespace Hamporsesh.Application.Core.ViewModels.Users
{
    public class UserOutputDetailViewModel
    {
        public UserOutputViewModel User { get; set; }
        public IEnumerable<PollOutPutViewModel> Polls { get; set; }
    }
}
