using System.Collections.Generic;
using Hamporsesh.Application.Core.ViewModels.Answers;

namespace Hamporsesh.Application.Core.ViewModels.Questions
{
    public class QuestionChoicesDto
    {
        public QuestionOutputDto Question { get; set; }
        public IEnumerable<AnswerOutputDto> Answers { get; set; }
    }
}
