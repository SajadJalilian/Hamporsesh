using System.ComponentModel.DataAnnotations;

namespace Hamporsesh.Application.Core.ViewModels.Users
{
    public class UserInputDto
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "فیلد باید پر شود")]
        public string DisplayName { get; set; }
        public string CreateDateTimeStr { get; set; }
    }
}
