using Hamporsesh.Domain.Core.Models;

namespace Hamporsesh.Domain.Entities
{
    public class User : ApplicationUser
    {
        public User()
        {

        }

        public string DisplayName { get; set; }

    }
}
