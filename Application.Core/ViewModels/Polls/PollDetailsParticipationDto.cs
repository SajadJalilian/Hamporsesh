using System.Collections.Generic;
using Hamporsesh.Application.Core.ViewModels.Questions;

namespace Hamporsesh.Application.Core.ViewModels.Polls
{
    public class PollDetailsParticipationDto
    {
        public PollOutputDto Poll { get; set; }
        public IEnumerable<QuestionDetailDto> Questions { get; set; }
    }
}