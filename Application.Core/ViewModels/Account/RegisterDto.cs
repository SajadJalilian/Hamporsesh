using System.ComponentModel.DataAnnotations;

namespace Hamporsesh.Application.Core.ViewModels.Account
{
    public class RegisterDto
    {
        [Required]
        public string DisplayName { get; set; }

        [Required]
        public string UserName { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and Confirm Password do not match.")]
        public string ConfirmPassword { get; set; }

    }
}
