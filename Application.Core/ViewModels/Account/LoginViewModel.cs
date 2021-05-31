using System.ComponentModel.DataAnnotations;

namespace Hamporsesh.Application.Core.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
