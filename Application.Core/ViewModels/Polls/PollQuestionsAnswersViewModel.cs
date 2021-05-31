using System.Collections.Generic;

namespace Hamporsesh.Application.Core.ViewModels.Polls
{
    public class PollQuestionsAnswersViewModel
    {
        public PollOutPutViewModel Poll { get; set; }
        public IEnumerable<QuestionDetailViewModel> Questions { get; set; }
    }
}
