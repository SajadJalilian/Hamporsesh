using System.Collections.Generic;
using Hamporsesh.Application.Core.ViewModels.Questions;

namespace Hamporsesh.Application.Core.ViewModels.Polls
{
    public class PollResultsViewModel
    {
        public string PollTitle { get; set; }
        public long TotalResponses { get; set; }
        public IEnumerable<QuestionResultOutput> Questions { get; set; }
    }
}
