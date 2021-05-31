using System.ComponentModel.DataAnnotations;

namespace Hamporsesh.Application.Core.ViewModels.Questions
{
    public class QuestionInputViewModel
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "فیلد باید پر شود")]
        public string Title { get; set; }
        [Required(ErrorMessage = "فیلد باید پر شود")]
        public QuestionType Type { get; set; }
        public long PollId { get; set; }
    }
}
