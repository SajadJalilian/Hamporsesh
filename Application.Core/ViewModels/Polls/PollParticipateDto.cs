using Hamporsesh.Application.Core.ViewModels.Questions;
using System.Collections.Generic;

namespace Hamporsesh.Application.Core.ViewModels.Polls

{
    public class PollParticipateDto
    {
        public long VisitorId { get; set; }
        public long PollId { get; set; }
        public List<QuestionAnswersDto> Questions { get; set; }
        public long ParticipateUserId { get; set; }
        public string[] AnsweresId { get; set; }
        public long QuestionCount { get; set; }
    }
}
