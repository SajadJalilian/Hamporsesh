using System.Collections.Generic;

namespace Hamporsesh.Application.Core.ViewModels.Choices
{

    public class ChoiceInputTest
    {
        public long PollId { get; set; }
        public int QuestionCount { get; set; }
        public string[] AnsweresId { get; set; }
        public long ParticipateUserId { get; set; }
    }

    public class ChoiceInputViewModel
    {

        public long VisitorId { get; set; }
        public long PollId { get; set; }
        public List<Question1> Questions { get; set; }
        public long ParticipateUserId { get; set; }

    }

    public class Question1
    {
        public long QuestionId { get; set; }
        public long[] AnsweresId { get; set; }
    }
}
