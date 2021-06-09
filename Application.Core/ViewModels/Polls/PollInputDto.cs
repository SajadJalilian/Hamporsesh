using Hamporsesh.Application.Core.Resources;
using Hamporsesh.Domain.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Hamporsesh.Application.Core.ViewModels.Polls
{
    public class PollInputDto
    {
        public long Id { get; set; }


        [Display(Name = nameof(ApplicationMetadata.Title), ResourceType = typeof(ApplicationMetadata))]
        [Required(ErrorMessageResourceName = nameof(ApplicationMetadata.Required), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        public string Title { get; set; }


        [Display(Name = nameof(ApplicationMetadata.Description), ResourceType = typeof(ApplicationMetadata))]
        [Required(ErrorMessageResourceName = nameof(ApplicationMetadata.Required), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        public string Description { get; set; }


        public long UserId { get; set; }


        public PollStatus Status { get; set; }

    }
}
