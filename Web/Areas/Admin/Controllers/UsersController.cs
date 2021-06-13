using Hamporsesh.Application.Core.ViewModels.Users;
using Hamporsesh.Application.Polls;
using Hamporsesh.Application.Users;
using Hamporsesh.Infrastructure.Data.Context;
using Hamporsesh.Web.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hamporsesh.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly IPollService _pollService;
        private readonly IUnitOfWork _uow;

        public UsersController(
                IUserService userService,
                IPollService pollService,
                IUnitOfWork uow
            )
        {
            _userService = userService;
            _pollService = pollService;
            _uow = uow;
        }



        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }



        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public IActionResult Update(long id)
        {
            var user = _userService.GetToUpdate(id);
            return View(user);
        }



        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        public IActionResult Update(UserInputDto input)
        {
            if (!ModelState.IsValid)
                return Json(new { result = false, message = Utilities.GetModelStateErrors(ModelState) });
            _userService.Update(input);
            _uow.SaveChanges();

            return RedirectToAction("Index");
        }



        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public IActionResult Profile(long id)
        {
            var user = _userService.GetById(id);
            ProfileOutputDto model = new()
            {
                User = user,
                Polls = _pollService.GetListByUserId(id),
                ParticipatedPolls = _pollService.GetPollsByParticipatedUserId(id)
            };
            return View(model);
        }

    }
}
