using System;
using Hamporsesh.Domain.Core.Enums;

namespace Hamporsesh.Application.Core.ViewModels.Questions
{
    public class QuestionOutputViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public QuestionType Type { get; set; }
        public long PollId { get; set; }
        public DateTime CreateDateTime { get; set; }

    }
}
