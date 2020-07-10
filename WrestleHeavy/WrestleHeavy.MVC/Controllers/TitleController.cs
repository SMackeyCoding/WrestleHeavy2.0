using Microsoft.AspNet.Identity;
using Models.TitleCRUD;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WrestleHeavy.MVC.Controllers
{
    [Authorize]
    public class TitleController : Controller
    {
        // GET: Title
        public ActionResult Index()
        {

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TitleService(userId);
            var model = service.GetTitles();

            return View(model);
        }

        //GET: Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TitleCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateTitleService();

            if (service.CreateTitle(model))
            {
                TempData["SaveResult"] = "Your title has been created!";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Title could not be created.");

            return View(model);
        }

        // GET: Detail
        public ActionResult Details(int id)
        {
            var svc = CreateTitleService();
            var model = svc.GetTitleById(id);

            return View(model);
        }

        //GET: Edit
        public ActionResult Edit(int id)
        {
            var service = CreateTitleService();
            var detail = service.GetTitleById(id);
            var model = new TitleEdit
            {
                TitleId = detail.TitleId,
                TitleName = detail.TitleName,
                WrestlerId = detail.WrestlerId
            };
            return View(model);
        }

        //POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TitleEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.TitleId != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = CreateTitleService();

            if (service.UpdateTitle(model))
            {
                TempData["SaveResult"] = "The title has been updated!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The promotion could not be updated.");
            return View(model);
        }

        //GET: Delete
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateTitleService();
            var model = svc.GetTitleById(id);

            return View(model);
        }

        //POST: Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteTitle(int id)
        {
            var service = CreateTitleService();
            service.DeleteTitle(id);
            TempData["SaveResult"] = "The title has been deleted";
            return RedirectToAction("Index");
        }

        //Refactor
        private TitleService CreateTitleService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TitleService(userId);
            return service;
        }
    }
}