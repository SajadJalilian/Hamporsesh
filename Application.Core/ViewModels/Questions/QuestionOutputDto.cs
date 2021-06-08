using Hamporsesh.Domain.Core.Enums;
using System;

namespace Hamporsesh.Application.Core.ViewModels.Questions
{
    public class QuestionOutputDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public QuestionType Type { get; set; }
        public long PollId { get; set; }
        public DateTime CreateDateTime { get; set; }

    }
}
