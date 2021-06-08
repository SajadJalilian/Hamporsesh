using Hamporsesh.Application.Core.ViewModels.Questions;
using System.Collections.Generic;

namespace Hamporsesh.Application.Core.ViewModels.Polls
{
    public class PollQuestionsAnswersDto
    {
        public PollOutputDto Poll { get; set; }
        public IEnumerable<QuestionDetailDto> Questions { get; set; }
    }
}
