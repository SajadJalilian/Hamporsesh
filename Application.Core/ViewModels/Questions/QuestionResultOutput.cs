using System.Collections.Generic;
using Hamporsesh.Application.Core.ViewModels.Answers;

namespace Hamporsesh.Application.Core.ViewModels.Questions
{
    public class QuestionResultOutput
    {
        public string QuestionName { get; set; }
        public IEnumerable<AnswerResultsViewModel> AnswersResults { get; set; }
    }
}
