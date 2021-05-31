using System.Threading.Tasks;
using Hamporsesh.Application.Core.ViewModels.Account;
using Hamporsesh.Application.Users;
using Hamporsesh.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Web.Extensions;

namespace Web.Controllers
{

    public class AccountsController : BaseController
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IUserService _userService;

        public AccountsController(UserManager<User> userManager, SignInManager<User> signInManager, IUserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userService = userService;
        }



        /// <summary>
        /// 
        /// </summary>
        [HttpGet("/login")]
        public IActionResult Login()
        {
            return View();
        }



        /// <summary>
        /// 
        /// </summary>
        [HttpPost("/login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (!ModelState.IsValid)
            {
                var errors = Utilities.GetModelStateErrors(ModelState);
                return Json(new { result = false, message = errors });
            }


            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, set lockoutOnFailure: true
            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, true, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                TempData["Message"] = "Not Found";
                return RedirectToAction(controllerName: "Accounts", actionName: "Login");
            }
            return RedirectToAction(actionName: "index", controllerName: "Dashboard", new { area = "Admin"});
            
        }



        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }




        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }



        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel input)
        {
            if (!ModelState.IsValid)
                return View(input);

            var user = new User
            {
                DisplayName = input.DisplayName,
                UserName = input.UserName
            };

            var result = await _userManager.CreateAsync(user, input.Password);
            if (!result.Succeeded)
            {
                Utilities.AddIdentityErrorsToModelState(ModelState, result);
                return View(input);
            }

            await _signInManager.SignInAsync(user, true);

            return RedirectToAction(controllerName: "home", actionName: "index");

        }



        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }  
        

        
        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                {
                    return RedirectToAction("Login");
                }

                // ChangePasswordAsync changes the user password
                var result = await _userManager.ChangePasswordAsync(user,
                    model.CurrentPassword, model.NewPassword);

                // The new password did not meet the complexity rules or
                // the current password is incorrect. Add these errors to
                // the ModelState and rerender ChangePassword view
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View();
                }

                // Upon successfully changing the password refresh sign-in cookie
                await _signInManager.RefreshSignInAsync(user);
                return View("ChangePasswordConfirmation");
            }

            return View(model);
        }
        
        
        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View();
        }  
        
        
        
        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        public IActionResult ForgetPassword(string s)
        {
            return View();
        }

    }
}
