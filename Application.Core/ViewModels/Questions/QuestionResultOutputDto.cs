using System.Collections.Generic;
using Hamporsesh.Application.Core.ViewModels.Answers;

namespace Hamporsesh.Application.Core.ViewModels.Questions
{
    public class QuestionResultOutputDto
    {
        public string QuestionName { get; set; }
        public IEnumerable<AnswerResultsDto> AnswersResults { get; set; }
    }
}
