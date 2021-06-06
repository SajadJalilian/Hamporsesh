using System.ComponentModel.DataAnnotations;
using Hamporsesh.Application.Core.ViewModels.Answers;

namespace Hamporsesh.Application.Core.ViewModels.Choices
{
    public class ChoiceWithAnswerDto
    {
        public long Id { get; set; }
        [Required]
        public AnswerOutputDto Answer { get; set; }
        public long UserId { get; set; }
        public long PollId { get; set; }

    }
}
