using Hamporsesh.Application.Core.ViewModels.Answers;
using System.Collections.Generic;

namespace Hamporsesh.Application.Core.ViewModels.Questions
{
    public class QuestionDetailDto
    {
        public QuestionOutputDto Question { get; set; }
        public IEnumerable<AnswerOutputDto> Answers { get; set; }
    }
}
