using Lazer_Svit.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lazer_Svit.Controllers
{
    public class AdminItemsController : Controller
    {
        // GET: AdminItems
        public ActionResult Index(int? page)
        {
            Category category = new Category();
            ViewBag.Category = category.GetCategories();

            Products product = new Products();
            var data = product.GetItems();

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            return View(data.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult AddItem()
        {
            Category category = new Category();
            ViewBag.Category = category.GetCategories();

            return View();
        }

        [HttpPost]
        public ActionResult AddItem(IEnumerable<HttpPostedFileBase> uploads, AdminItem item)
        {
            Category category = new Category();
            ViewBag.Category = category.GetCategories();

            if (ModelState.IsValid)
            {
                Products products = new Products();
                products.AddItem(uploads, item);

                return RedirectToAction("Index");
            }

            return View();
        }

        //выввод полей товара на редактирование или удаление комментариев о товаре
        public ActionResult Edit(int id)
        {
            Category category = new Category();
            ViewBag.Category = category.GetCategories();

            AdminItem item = new AdminItem();
            var data = item.ItemInfo(id);

            return View(data);
        }

        //применение отредактирванного товара
        [HttpPost]
        public ActionResult EditItem(IEnumerable<HttpPostedFileBase> uploads, AdminItem item)
        {
            Category category = new Category();
            ViewBag.Category = category.GetCategories();

            if (ModelState.IsValid)
            {
                //TODO Редактиваронеи товара
                Products products = new Products();
                products.EditItem(uploads, item);
            }

            return RedirectToAction("Index");
        }

        public ActionResult DeleteItem(int id)
        {
            Item item = new Item();
            item.DeleteItem(id);

            Products product = new Products();
            var data = product.GetItems();

            return PartialView(data);
        }

        public ActionResult DeleteReview(int reviewId, int itemId)
        {
            ProductReviews reviews = new ProductReviews();
            reviews.DeleteReview(reviewId);

            AdminItem product = new AdminItem();
            var data = product.ItemInfo(itemId);

            return PartialView(data);
        }
    }
}