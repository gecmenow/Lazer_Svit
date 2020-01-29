using Lazer_Svit.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lazer_Svit.Controllers
{
    public class AdminOrdersController : Controller
    {
        // GET: AdminOrders
        public ActionResult Index(int? page)
        {
            Category category = new Category();
            ViewBag.Category = category.GetCategories();

            AdminOrder adminOrder = new AdminOrder();
            var data = adminOrder.GetOrders();

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            return View(data.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult EditOrder(int id)
        {
            Category category = new Category();
            ViewBag.Category = category.GetCategories();

            AdminOrder adminOrder = new AdminOrder();
            var data = adminOrder.GetOrder(id);

            return View(data);
        }

        [HttpPost]
        public ActionResult EditOrder(AdminOrder order)
        {
            Category category = new Category();
            ViewBag.Category = category.GetCategories();

            AdminOrder adminOrder = new AdminOrder();
            adminOrder.EditOrder(order);

            return RedirectToAction("Index");
        }

        public ActionResult DeleteOrder(int id)
        {
            Category category = new Category();
            ViewBag.Category = category.GetCategories();

            AdminOrder adminOrder = new AdminOrder();
            adminOrder.DeleteOrder(id);

            var data = adminOrder.GetOrders();

            return PartialView(data);
        }
    }
}