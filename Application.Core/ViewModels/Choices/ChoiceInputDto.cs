using System.ComponentModel.DataAnnotations;
using Hamporsesh.Application.Core.ViewModels.Answers;

namespace Hamporsesh.Application.Core.ViewModels.Choices
{
    public class ChoiceInputDto
    {
        public long id { get; set; }
        [Required]
        public AnswerOutputDto Answer { get; set; }
        public long UserId { get; set; }
    }
}
