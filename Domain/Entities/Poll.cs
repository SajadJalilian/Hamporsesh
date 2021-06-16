using Hamporsesh.Domain.Core.Enums;
using Hamporsesh.Domain.Core.Models;
using System.Collections.Generic;

namespace Hamporsesh.Domain.Entities
{
    public class Poll : BaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public long UserId { get; set; }

        public virtual ICollection<Question> Questions { get; set; }

        public PollStatus Status { get; set; }
    }
}
