using Hamporsesh.Application.Users;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Web.Areas.Admin.Components
{
    public class UserMenu : ViewComponent
    {
        private readonly IUserService _userService;
        public UserMenu(IUserService userService)
        {
            _userService = userService;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var currentUserName = this.User.Identity.Name;
            var user = _userService.GetByUserName(currentUserName);

            return View(user);
        }


    }
}
