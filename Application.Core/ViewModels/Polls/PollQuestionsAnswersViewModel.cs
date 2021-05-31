using System.Collections.Generic;
using Hamporsesh.Application.Core.ViewModels.Questions;

namespace Hamporsesh.Application.Core.ViewModels.Polls
{
    public class PollQuestionsAnswersViewModel
    {
        public PollOutPutViewModel Poll { get; set; }
        public IEnumerable<QuestionDetailViewModel> Questions { get; set; }
    }
}
