using Hamporsesh.Domain.Core.Enums;
using Hamporsesh.Domain.Core.Models;
using System.Collections.Generic;

namespace Hamporsesh.Domain.Entities
{
    public class Question : BaseEntity
    {

        public string Title { get; set; }

        public QuestionType Type { get; set; }
        public long PollId { get; set; }

        public List<Answer> Answers { get; set; }


        // [ForeignKey("PollId")]
        public Poll Poll { get; set; }
    }


}
