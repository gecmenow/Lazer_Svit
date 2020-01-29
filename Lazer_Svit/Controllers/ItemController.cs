using Lazer_Svit.Models;
using Lazer_Svit.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using PagedList.Mvc;
using PagedList;
using Lazer_Svit.Filters;

namespace Lazer_Svit.Controllers
{
    //Вывод товара
    [Culture]
    public class ItemController : Controller
    {
        // GET: Item
        public ActionResult Index(int id, int? page)
        {
            Category category = new Category();
            ViewBag.Category = category.GetCategories();

            Item item = new Item();
            var data = item.GetItemById(id);

            ViewBag.Item = data;

            ProductReviews reviews = new ProductReviews();

            IEnumerable<DbProductReview> review = reviews.GetReview(id);

            ViewBag.SameItems = item.GetSameItems(data.Category);

            int pageSize = 5;
            int pageNumber = (page ?? 1);

            return View(review.ToPagedList(pageNumber, pageSize));
        }

        [HttpPost]
        public ActionResult Index(int id, string name, string email, int rate, string message, int? page)
        {
            ProductReviews reviews = new ProductReviews();

            reviews.AddReview(id, name, email, rate, message);

            Category category = new Category();
            ViewBag.Category = category.GetCategories();

            Item item = new Item();
            var data = item.GetItemById(id);

            ViewBag.Item = data;

            IEnumerable<DbProductReview> review = reviews.GetReview(id);

            ViewBag.SameItems = item.GetSameItems(data.Category);

            string returnUrl = Request.UrlReferrer.AbsolutePath;

            int pageSize = 5;
            int pageNumber = (page ?? 1);

            return View(review.ToPagedList(pageNumber, pageSize));
        }
    }
}