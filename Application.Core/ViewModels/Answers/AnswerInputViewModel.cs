using System.ComponentModel.DataAnnotations;

namespace Hamporsesh.Application.Core.ViewModels.Answers
{
    public class AnswerInputViewModel
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "فیلد باید پر شود")]
        public string Title { get; set; }
        public long QuestionId { get; set; }

    }
}
