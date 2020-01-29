using Lazer_Svit.Filters;
using Lazer_Svit.LiqPay;
using Lazer_Svit.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Checkout = Lazer_Svit.Models.Checkout;
using Cookie = Lazer_Svit.Models.Cookie;

namespace Lazer_Svit.Controllers
{
    [Culture]
    public class CheckoutController : Controller
    {
        // GET: Checkout
        public ActionResult Index()
        {
            Category category = new Category();
            ViewBag.Category = category.GetCategories();

            Checkout checkout = new Checkout();
            checkout = checkout.ShowCheckout();

            //PaymentData paymentData = checkout.LiqPayData();

            return View(checkout);
        }

        public ActionResult LiqPayStatus(string liqPayId)
        {
            // --- Перетворюю відповідь LiqPay в Dictionary<string, string> для зручності:
            var request_dictionary = Request.Form.AllKeys.ToDictionary(key => key, key => Request.Form[key]);
            if (request_dictionary.Count != 0)
            {
                // --- Розшифровую параметр data відповіді LiqPay та перетворюю в Dictionary<string, string> для зручності:
                byte[] request_data = Convert.FromBase64String(request_dictionary["data"]);
                string decodedString = Encoding.UTF8.GetString(request_data);
                var request_data_dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(decodedString);

                // --- Отримую сигнатуру для перевірки
                var mySignature = Payment.GetSignature(request_dictionary["data"]);

                // --- Якщо сигнатура серевера не співпадає з сигнатурою відповіді LiqPay - щось пішло не так
                if (mySignature != request_dictionary["signature"])
                    //return View("~/Views/Shared/_Error.cshtml");
                    Session["msg"] = "Error";

                // --- Якщо статус відповіді "Тест" або "Успіх" - все добре
                if (request_data_dictionary["status"] == "sandbox" || request_data_dictionary["status"] == "success")
                {
                    // Тут можна оновити статус замовлення та зробити всі необхідні речі. Id замовлення можна взяти тут: request_data_dictionary[order_id]
                    // ...
                    var status = "sucess";
                    Order order = new Order();
                    order.EditOrderByLiqPayID(liqPayId, status);
                }
            }

            return Redirect(Url.Content("~/"));
        }

        public ActionResult Confirm(string name, string tel, string email,
            string region, string city, string address, string delivery, string payment, string country, string liqPayId)
        {
            string payStatus = "";

            Order order = new Order();
            order.AddOrder(name, tel, email,
            region, city, address, delivery, payment, payStatus, country, liqPayId);

            Cookie.ClearCart();

            return Redirect(Url.Content("~/"));
        }

        
        public ActionResult ConfirmLiqPay(string name, string tel, string email,
            string region, string city, string adress, string delivery, string payment, string country, string liqPayId)
        {
            string payStatus = "";

            Order order = new Order();
            order.AddOrder(name, tel, email,
            region, city, adress, delivery, payment, payStatus, country, liqPayId);

            return PartialView("Decoy");
        }

        public ActionResult OneClickBuy(int id, string tel)
        {
            Order order = new Order();
            order.AddOneClikOrder(id, tel);

            return Redirect(Url.Content("~/"));
        }

    }
}