using Hamporsesh.Application.Core.ViewModels.Polls;
using Hamporsesh.Application.Polls;
using Hamporsesh.Infrastructure.Data.Context;
using Hamporsesh.Web.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;


namespace Hamporsesh.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class PollsController : BaseController
    {
        private readonly IPollService _pollService;
        private readonly IUnitOfWork _uow;


        public PollsController(
            IPollService pollService,
            IUnitOfWork uow
        )
        {
            _pollService = pollService;
            _uow = uow;
        }


        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public IActionResult Index()
        {
            var polls = _pollService.GetUserPollIndex(GetCurrentUserId());
            return View(polls);
        }


        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        public IActionResult Create(PollInputDto input)
        {
            input.UserId = GetCurrentUserId();
            if (!ModelState.IsValid)
                return Json(new { result = false, message = Utilities.GetModelStateErrors(ModelState) });

            _pollService.Create(input);
            _uow.SaveChanges();

            return RedirectToAction("Index");
        }


        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public IActionResult Update(long id)
        {
            var poll = _pollService.GetToUpdate(id);
            return View(poll);
        }


        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        public IActionResult Update(PollInputDto input)
        {
            if (!ModelState.IsValid)
                return Json(new { result = false, message = Utilities.GetModelStateErrors(ModelState) });

            _pollService.Update(input);
            _uow.SaveChanges();
            return RedirectToAction("Details", new { id = input.Id });
        }


        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public IActionResult Details(long id)
        {
            var poll = _pollService.GetPollDetails(id);
            return View(poll);
        }


        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public IActionResult Delete(long id, string returnUrl)
        {
            var poll = _pollService.GetById(id);
            var userId = GetCurrentUserId();
            if (poll.UserId == userId)
            {
                _pollService.Delete(id);
                _uow.SaveChanges();
            }
            else
            {
                throw new Exception("You are not the owner");
            }

            if (returnUrl is not null)
                return LocalRedirect(returnUrl);

            return RedirectToAction("Index");
        }


        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public IActionResult Results(long id)
        {
            var model = _pollService.GetPollResult(id);
            return View(model);
        }
    }
}