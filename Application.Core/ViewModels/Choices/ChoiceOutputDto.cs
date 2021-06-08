using System.ComponentModel.DataAnnotations;

namespace Hamporsesh.Application.Core.ViewModels.Choices
{
    public class ChoiceOutputDto
    {
        public long Id { get; set; }
        [Required]
        public long UserId { get; set; }
        public long PollId { get; set; }

    }
}
