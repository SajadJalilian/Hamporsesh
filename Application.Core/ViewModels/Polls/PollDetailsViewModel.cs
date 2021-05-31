using System.Collections.Generic;
using Hamporsesh.Application.Core.ViewModels.Questions;
using Hamporsesh.Application.Core.ViewModels.Users;

namespace Hamporsesh.Application.Core.ViewModels.Polls
{
    public class PolldetailsViewModel
    {
        public PollOutPutViewModel Poll { get; set; }
        public IEnumerable<QuestionDetailViewModel> Questions { get; set; }
        public UserOutputViewModel User { get; set; }
    }
}