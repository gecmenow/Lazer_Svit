using Lazer_Svit.Filters;
using Lazer_Svit.Models;
using Lazer_Svit.Models.Database;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Lazer_Svit.Controllers
{
    [Culture]
    public class CartController : Controller
    {
        const string cookieName = "CartCookie";//имя куки

        Cart cart = new Cart();

        // GET: Cart
        public ActionResult Index()
        {
            DefCookie.SetDefCookie();

            Category category = new Category();
            ViewBag.Category = category.GetCategories();

            var cartItems = cart.ShowCart();

            CartList cartList = new CartList();

            ViewBag.Price = cartList.TotalPrice();

            return View(cartItems);
        }

        public ActionResult AddToCart(int id)
        {
            List<Cart> cartList = new List<Cart>();

            HttpCookie cookieReq = Request.Cookies[cookieName];

            if (cookieReq == null)
            {
                cart.AddProductToEmptyCart(id);
            }
            else
            {
                bool checkItem = cart.IsExisting(id);

                if (cart.IsExisting(id) == true)
                    return PartialView("Decoy");

                cart.AddProductIfCartNotNull(id);
            }
            return PartialView("Decoy");
        }

        public ActionResult EditItemQuantity(int id, int quantity)
        {
            if (id == 0 || id <= 0)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            cart.EditItemQuantity(id, quantity);

            return PartialView("Decoy");
        }

        public ActionResult DeleteItem(int id)
        {
            if (id == 0 || id <= 0)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            var cartItems = cart.DeleteItem(id);

            CartList cartList = new CartList();

            ViewBag.Price = cartList.DeleteTotalPrice(id);

            return PartialView(cartItems);
        }
    }
}