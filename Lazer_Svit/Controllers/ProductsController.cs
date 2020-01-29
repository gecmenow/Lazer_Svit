using Lazer_Svit.Filters;
using Lazer_Svit.Models;
using Lazer_Svit.Models.Database;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lazer_Svit.Controllers
{
    [Culture]
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index(string urlName, int? page)
        {
            DefCookie.SetDefCookie();

            Category category = new Category();
            ViewBag.Category = category.GetCategories();

            ViewBag.ActiveProduct = "nav__link--current";

            string categoryName = Category.GetCategoryName(urlName);

            ViewBag.EngCategoryName = Category.GetEngCategoryName();

            ViewBag.CategoryName = categoryName;

            ViewBag.SortRu = "Новинки";
            ViewBag.SortUa = "Новинки";
            ViewBag.SortEn = "Latest";

            Products product = new Products();
            var data = product.GetItems(categoryName);

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            return View(data.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Popular(string urlName, int? page)
        {
            DefCookie.SetDefCookie();

            Category category = new Category();
            ViewBag.Category = category.GetCategories();

            ViewBag.ActiveProduct = "nav__link--current";

            string categoryName = Category.GetCategoryName(urlName);

            ViewBag.EngCategoryName = Category.GetEngCategoryName();

            ViewBag.CategoryName = categoryName;

            ViewBag.SortRu = "Поуплярные";
            ViewBag.SortUa = "Популярнi";
            ViewBag.SortEn = "Popular";

            Sort sort = new Sort();
            var data = sort.SortItemByPopularity(categoryName);

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            return View(data.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Low(string urlName, int? page)
        {
            DefCookie.SetDefCookie();

            Category category = new Category();
            ViewBag.Category = category.GetCategories();

            ViewBag.ActiveProduct = "nav__link--current";

            string categoryName = Category.GetCategoryName(urlName);

            ViewBag.EngCategoryName = Category.GetEngCategoryName();

            ViewBag.CategoryName = categoryName;

            ViewBag.SortRu = "От дешёвых к дорогим";
            ViewBag.SortUa = "Вiд дешевих до дорогих";
            ViewBag.SortEn = "Low to high";

            Sort sort = new Sort();
            var data = sort.SortItemByPriceLow(categoryName);

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            return View(data.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult High(string urlName, int? page)
        {
            DefCookie.SetDefCookie();

            Category category = new Category();
            ViewBag.Category = category.GetCategories();

            ViewBag.ActiveProduct = "nav__link--current";

            string categoryName = Category.GetCategoryName(urlName);

            ViewBag.EngCategoryName = Category.GetEngCategoryName();

            ViewBag.CategoryName = categoryName;

            ViewBag.SortRu = "От дорогих к дешёвым";
            ViewBag.SortUa = "Вiд дорогих до дешевих";
            ViewBag.SortEn = "High to low";

            Sort sort = new Sort();
            var data = sort.SortItemByPriceHigh(categoryName);

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            return View(data.ToPagedList(pageNumber, pageSize));
        }
    }
}