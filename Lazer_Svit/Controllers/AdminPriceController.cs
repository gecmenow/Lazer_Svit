using Lazer_Svit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lazer_Svit.Controllers
{
    public class AdminPriceController : Controller
    {
        // GET: AdminPrice
        public ActionResult Index()
        {
            Category category = new Category();
            ViewBag.Category = category.GetCategories();

            Price price = new Price();
            var data = price.getPrice();

            return View(data);
        }

        [HttpPost]
        public ActionResult Woods(IEnumerable<string> materialThickness, IEnumerable<string> lowCost,
            IEnumerable<string> midCost, IEnumerable<string> highCost)
        {
            Price price = new Price();
            price.AddWoodsPrice(materialThickness, lowCost, midCost, highCost);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Acrylic(IEnumerable<string> materialThickness, IEnumerable<string> lowCost,
            IEnumerable<string> midCost, IEnumerable<string> highCost)
        {
            Price price = new Price();
            price.AddAcrylicPrice(materialThickness, lowCost, midCost, highCost);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Engraving(IEnumerable<string> type, IEnumerable<string> price)
        {
            Price p = new Price();
            p.AddEncgravingPrice(type, price);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult UV(List<string> cells1, List<string> cells2, List<string> cells3, List<string> cells4, List<string> cells5, List<string> cells6, List<string> cells7, List<string> cells8, List<string> cells9, List<string> cells10, List<string> cells11, List<string> cells12, List<string> cells13, List<string> cells14, List<string> cells15, List<string> cells16, List<string> cells17, List<string> cells18, List<string> cells19, List<string> cells20)
        {
            Price p = new Price();

            p.AddUVPrintingPrice(cells1, cells2, cells3, cells4, cells5, cells6, cells7, cells8, cells9, cells10, cells11, cells12, cells13,
                cells14, cells15, cells16, cells17, cells18, cells19, cells20);

            return RedirectToAction("Index");
        }
    }
}