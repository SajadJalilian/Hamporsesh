using System.Collections.Generic;
using Hamporsesh.Application.Core.ViewModels.Questions;

namespace Hamporsesh.Application.Core.ViewModels.Polls
{
    public class PollResultsDto
    {
        public string PollTitle { get; set; }
        public long TotalResponses { get; set; }
        public IEnumerable<QuestionResultOutputDto> Questions { get; set; }
    }
}
