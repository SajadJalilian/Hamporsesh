using Hamporsesh.Application.Core.Resources;
using Hamporsesh.Domain.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Hamporsesh.Application.Core.ViewModels.Questions
{
    public class QuestionInputDto
    {
        public long Id { get; set; }

        [Display(Name = nameof(ApplicationMetadata.QuestionTitle), ResourceType = typeof(ApplicationMetadata))]
        [Required(ErrorMessageResourceName = nameof(ApplicationMetadata.Required), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        public string Title { get; set; }

        [Display(Name = nameof(ApplicationMetadata.QuestionType), ResourceType = typeof(ApplicationMetadata))]
        [Required(ErrorMessageResourceName = nameof(ApplicationMetadata.Required), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        public QuestionType Type { get; set; }

        public long PollId { get; set; }
    }
}
