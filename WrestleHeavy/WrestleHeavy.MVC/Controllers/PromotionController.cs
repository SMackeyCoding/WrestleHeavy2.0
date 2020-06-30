using Microsoft.AspNet.Identity;
using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WrestleHeavy.MVC.Controllers
{
    public class PromotionController : Controller
    {
        [Authorize]

        // GET: Promotion
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PromotionService(userId);
            var model = service.GetPromotions();

            return View(model);
        }

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PromotionCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreatePromotionService();

            if (service.CreatePromotion(model))
            {
                TempData["SaveResult"] = "Your promotion has been created!";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Promotion could not be created.");

            return View(model);
        }

        // GET: Details
        public ActionResult Details(int id)
        {
            var svc = CreatePromotionService();
            var model = svc.GetPromotionById(id);

            return View(model);
        }

        // GET: Edit
        public ActionResult Edit(int id)
        {
            var service = CreatePromotionService();
            var detail = service.GetPromotionById(id);
            var model = new PromotionEdit
            {
                PromotionId = detail.PromotionId,
                Name = detail.Name,
                DateFounded = detail.DateFounded,
                Website = detail.Website
            };
            return View(model);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PromotionEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.PromotionId != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = CreatePromotionService();

            if (service.UpdatePromotion(model))
            {
                TempData["SaveResult"] = "The promotion has been updated!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The promotion could not be updated.");
            return View(model);
        }

        //GET: Delete
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreatePromotionService();
            var model = svc.GetPromotionById(id);

            return View(model);
        }

        //POST: Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePromotion(int id)
        {
            var service = CreatePromotionService();
            service.DeletePromotion(id);
            TempData["SaveResult"] = "The promotion has been deleted.";
            return RedirectToAction("Index");
        }

        // Refactored
        private PromotionService CreatePromotionService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PromotionService(userId);
            return service;
        }
    }
}