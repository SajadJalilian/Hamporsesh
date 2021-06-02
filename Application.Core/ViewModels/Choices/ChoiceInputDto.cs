using Hamporsesh.Application.Core.ViewModels.Questions;
using System.Collections.Generic;

namespace Hamporsesh.Application.Core.ViewModels.Choices
{
    public class ChoiceInputDto
    {

        public long VisitorId { get; set; }
        public long PollId { get; set; }
        public List<QuestionAnswersDto> Questions { get; set; }
        public long ParticipateUserId { get; set; }

    }

}
