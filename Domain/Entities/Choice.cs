using Hamporsesh.Domain.Core.Models;

namespace Hamporsesh.Domain.Entities
{
    public class Choice : BaseEntity
    {
        public long VisitorId { get; set; }

        public long PollId { get; set; }

        public long QuestionId { get; set; }

        public long AnswereId { get; set; }

        public long UserId { get; set; }

        public Poll Poll { get; set; }

    }
}
