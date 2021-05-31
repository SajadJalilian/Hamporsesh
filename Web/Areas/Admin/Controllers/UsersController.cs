using Hamporsesh.Application.Choices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Hamporsesh.Application.Core.ViewModels.Users;
using Hamporsesh.Application.Polls;
using Hamporsesh.Application.Users;
using Web.Extensions;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly IPollService _pollService;
        private readonly IChoiceService _choiceService;

        public UsersController(
                IUserService userService,
                IPollService pollService,
                IChoiceService choiceService
            )
        {
            _userService = userService;
            _pollService = pollService;
            _choiceService = choiceService;
        }


        
        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            if (!ModelState.IsValid)
            {
                var errors = Utilities.GetModelStateErrors(ModelState);
                return Json(new { result = false, message = errors });
            }
            return View();
        }

        
        
        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        [Authorize]
        public IActionResult Update(long id)
        {
            if (!ModelState.IsValid)
            {
                var errors = Utilities.GetModelStateErrors(ModelState);
                return Json(new { result = false, message = errors });
            }
            var user = _userService.GetToUpdate(id);
            return View(user);
        }



        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        [Authorize]
        public IActionResult Update(UserInputViewModel input)
        {
            if (!ModelState.IsValid)
            {
                var errors = Utilities.GetModelStateErrors(ModelState);
                return Json(new { result = false, message = errors });
            }
            _userService.Update(input);

            return RedirectToAction("Index");
        }


        
        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        [Authorize]
        public IActionResult Profile(long id)
        {
            #region Validations

            if (!ModelState.IsValid)
            {
                var errors = Utilities.GetModelStateErrors(ModelState);
                return Json(new { result = false, message = errors });
            }

            #endregion
            var user = _userService.GetById(id);
            ProfileOutputViewModel model = new()
            {
                User = user,
                Polls = _pollService.GetListByUserIdAdmin(id),
                ParticipatedPolls = _choiceService.GetPollsByParticipatedUserId(id)
        };
            return View(model);
        }

    }
}
