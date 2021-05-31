using System.Collections.Generic;

namespace Hamporsesh.Application.Core.ViewModels.Polls
{
    public class PolldetailsViewModel
    {
        public PollOutPutViewModel Poll { get; set; }
        public IEnumerable<QuestionDetailViewModel> Questions { get; set; }
        public UserOutputViewModel User { get; set; }
    }
}