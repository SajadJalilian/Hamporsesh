using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Hamporsesh.Domain.Core.Enums;
using Hamporsesh.Domain.Core.Models;

namespace Hamporsesh.Domain.Entities
{
    public class Poll: BaseEntity
    {
        
        public string Title { get; set; }
        
        public string Description { get; set; }
        public long UserId { get; set; }

        public List<Question> Questions { get; set; }
        public PollStatus Status { get; set; }
    }

   
}
