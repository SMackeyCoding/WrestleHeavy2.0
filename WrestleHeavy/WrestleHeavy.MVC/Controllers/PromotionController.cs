using Models;
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
            var model = new PromotionListItem[0];
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
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}