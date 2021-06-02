using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hamporsesh.Application.Users;
using Microsoft.AspNetCore.Mvc;

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
