using System.ComponentModel.DataAnnotations;
using Hamporsesh.Application.Core.ViewModels.Answers;

namespace Hamporsesh.Application.Core.ViewModels.Choices
{
    public class ChoiceOutputDto
    {
        public long id { get; set; }
        [Required]
        public AnswerOutputViewModel Answer { get; set; }
        public long UserId { get; set; }
    }
}
