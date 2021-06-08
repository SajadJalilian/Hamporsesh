using Hamporsesh.Application.Core.ViewModels.Questions;
using System.Collections.Generic;

namespace Hamporsesh.Application.Core.ViewModels.Polls
{
    public class PollResultsDto
    {
        public string PollTitle { get; set; }
        public long TotalResponses { get; set; }
        public IEnumerable<QuestionResultOutputDto> Questions { get; set; }
    }
}
