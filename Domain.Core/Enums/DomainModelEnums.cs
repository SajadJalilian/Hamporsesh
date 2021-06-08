using Hamporsesh.Domain.Core.Resorces;
using System.ComponentModel.DataAnnotations;

namespace Hamporsesh.Domain.Core.Enums
{

    public enum PollStatus
    {
        [Display(Name = nameof(DomainCoreMetadata.Enum_PollStatus_Active), ResourceType = typeof(DomainCoreMetadata))]
        Active = 1,
        [Display(Name = nameof(DomainCoreMetadata.Enum_PollStatus_Inactive), ResourceType = typeof(DomainCoreMetadata))]
        Inactive = 0
    }



    public enum QuestionType
    {
        [Display(Name = nameof(DomainCoreMetadata.Enum_QuestionType_Single), ResourceType = typeof(DomainCoreMetadata))]
        Single = 0,
        [Display(Name = nameof(DomainCoreMetadata.Enum_QuestionType_Multi), ResourceType = typeof(DomainCoreMetadata))]
        Multi = 1
    }

}
