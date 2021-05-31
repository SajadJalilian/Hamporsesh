using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Hamporsesh.Application.Core.ViewModels.Users;
using Web.Extensions;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly UserService _userService;
        private readonly PollService _pollService;
        private readonly ChoiceService _choiceService;

        public UsersController()
        {
            _userService = new UserService();
            _pollService = new PollService();
            _choiceService = new ChoiceService();
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
