using Hamporsesh.Domain.Core.Models;

namespace Hamporsesh.Domain.Entities
{
    public class Answer : BaseEntity
    {
        public string Title { get; set; }

        public long QuestionId { get; set; }
        public Question Question { get; set; }
    }
}