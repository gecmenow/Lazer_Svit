using Lazer_Svit.Filters;
using Lazer_Svit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lazer_Svit.Controllers
{
    [Culture]
    public class InfoController : Controller
    {
        Category category = new Category();
        // GET: Info
        public ActionResult Materials()
        {
            ViewBag.Category = category.GetCategories();

            ViewBag.ActiveMaterials = "nav__link--current";

            return View();
        }

        public ActionResult Price()
        {
            ViewBag.Category = category.GetCategories();

            ViewBag.ActivePrice = "nav__link--current";

            Price price = new Price();
            var data = price.getPrice();

            return View(data);
        }

        public ActionResult OrderInfo()
        {
            ViewBag.Category = category.GetCategories();

            ViewBag.ActiveOrderInfo = "nav__link--current";

            return View();
        }

        public ActionResult UVPrinting()
        {
            ViewBag.Category = category.GetCategories();

            ViewBag.ActiveUVPrinting = "nav__link--current";

            Price price = new Price();
            var data = price.getPrice();

            return View(data);
        }
    }
}