using Hamporsesh.Application.Core.ViewModels.Answers;
using System.Collections.Generic;

namespace Hamporsesh.Application.Core.ViewModels.Questions
{
    public class QuestionResultOutputDto
    {
        public string QuestionName { get; set; }
        public IEnumerable<AnswerResultsDto> AnswersResults { get; set; }
    }
}
