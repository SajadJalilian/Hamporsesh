using Hamporsesh.Application.Core.ViewModels.Answers;
using System.ComponentModel.DataAnnotations;

namespace Hamporsesh.Application.Core.ViewModels.Choices
{
    public class ChoiceInputDto
    {
        public long Id { get; set; }
        [Required]
        public AnswerOutputDto Answer { get; set; }
        public long UserId { get; set; }
    }
}
