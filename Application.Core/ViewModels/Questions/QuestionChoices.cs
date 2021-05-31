using System.Collections.Generic;
using Hamporsesh.Application.Core.ViewModels.Answers;

namespace Hamporsesh.Application.Core.ViewModels.Questions
{
    public class QuestionChoices
    {
        public QuestionOutputViewModel Question { get; set; }
        public IEnumerable<AnswerOutputViewModel> Answers { get; set; }
    }
}
