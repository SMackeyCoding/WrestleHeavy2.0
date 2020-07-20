using Data;
using Data.Entities;
using Microsoft.AspNet.Identity;
using Models.WrestlerCRUD;
using Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WrestleHeavy.Data;
using static Data.Entities.Repos;

namespace WrestleHeavy.MVC.Controllers
{
    public class WrestlerController : Controller
    {
        private ApplicationDbContext ctx = new ApplicationDbContext();

        [Authorize]

        // GET: Wrestler
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new WrestlerService(userId);
            var model = service.GetWrestlers();

            return View(model);
        }

        // GET: Create
        public ActionResult Create()
        {
            var model = new WrestlerCreate();
            var promotionList = new PromotionRepo();
            model.Promotions = promotionList.GetPromotions();
            return View(model);
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WrestlerCreate model)
        {
            if (!ModelState.IsValid)
            {
                var promotionList = new PromotionRepo();
                model.Promotions = promotionList.GetPromotions();

                return View(model);
            }
            var service = CreateWrestlerService();

            if (service.CreateWrestler(model))
            {
                TempData["SaveResult"] = "Your wrestler has been created!";
                return RedirectToAction("Index");
            };



            ModelState.AddModelError("", "Wrestler could not be created.");

            return View(model);
        }

        // GET: Details
        public ActionResult Details(int id)
        {
            var svc = CreateWrestlerService();
            var model = svc.GetWrestlerById(id);

            return View(model);
        }

        //GET: Edit
        //Possible error on Promo ID
        public ActionResult Edit(int id)
        {
            var service = CreateWrestlerService();
            var detail = service.GetWrestlerById(id);

            var promotionList = new PromotionRepo();
            var model = new WrestlerEdit
            {
                WrestlerId = detail.WrestlerId,
                RingName = detail.RingName,
                Gender = detail.Gender,
                PromotionId = detail.PromotionId,
                Wins = detail.Wins,
                Losses = detail.Losses,
            };
            model.Promotions = promotionList.GetPromotions();

            return View(model);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, WrestlerEdit model)
        {
            if (!ModelState.IsValid)
            {
                var promotionList = new PromotionRepo();
                model.Promotions = promotionList.GetPromotions();

                return View(model);
            }

            if (model.WrestlerId != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = CreateWrestlerService();

            if (service.UpdateWrestler(model))
            {
                TempData["SaveResult"] = "The wrestler has been updated!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The wrestler could not be updated.");
            return View(model);
        }

        //GET: Delete
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateWrestlerService();
            var model = svc.GetWrestlerById(id);

            return View(model);
        }

        //POST: Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteWrestler(int id)
        {
            var service = CreateWrestlerService();
            service.DeleteWrestler(id);
            TempData["SaveResult"] = "The wrestler has been deleted.";
            return RedirectToAction("Index");
        }

        //Refactor
        private WrestlerService CreateWrestlerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new WrestlerService(userId);
            return service;
        }
    }
}