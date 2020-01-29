using Lazer_Svit.Hashing;
using Lazer_Svit.LiqPay;
using Lazer_Svit.Models.Database;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Lazer_Svit.Models
{
    public class Checkout
    {
        string sharedKey = "5553535";

        public string Form { get; set; }

        // для вывода на view
        public PaymentData PaymentData { get; set; }
        public double totalAmount { get; set; }
        public string LiqPayId { get; set; }

        DatabaseContext _db = new DatabaseContext();

        const string cart = "Cart";
        const string cookieName = "CartCookie";//имя куки

        public double totalPrice;

        public Checkout ShowCheckout()
        {
            HttpCookie cookieReq = HttpContext.Current.Request.Cookies[cookieName];

            if (cookieReq != null)
            {
                #region Получение корзины из куки
                string data = cookieReq[cart];

                var temp = data.Split('|').ToList();

                Dictionary<int, int> cookieData = new Dictionary<int, int>();

                foreach (var t in temp)
                    cookieData.Add(Convert.ToInt32(t.Split(',')[0]), Convert.ToInt32(t.Split(',')[1]));

                foreach (var tempData in cookieData)
                {
                    totalPrice += _db.ItemsDB.Find(tempData.Key).Price * tempData.Value;
                }
                #endregion
            }

            Int32 unixTimeStamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

            var random = r.Next(1, 9999);

            LiqPayId = (unixTimeStamp + random).ToString();

            string orderId = LiqPayId;

            //LiqPayId = Hash.EncryptStringAES(LiqPayId.ToString(), sharedKey);
            
            Checkout checkout = new Checkout();
            checkout.totalAmount = totalPrice;

            if (HttpContext.Current.Request.Cookies["lang"].Value == "en")
            {
                var json = new WebClient().DownloadString(PrivatBankData.getUrl());

                dynamic stuff = JsonConvert.DeserializeObject<List<PrivatBankData>>(json).ToList();

                double sale = Convert.ToDouble(stuff[1].sale);

                checkout.totalAmount = Math.Round(totalPrice / sale, 2);
            }

            checkout.PaymentData = LiqPayData(orderId);
            checkout.LiqPayId = LiqPayId;

            return checkout;
        }

        Payment liqPay;
        LiqPay.Checkout testCheck = new LiqPay.Checkout();

        Random r = new Random();

        public PaymentData LiqPayData(string orderId)
        {
            //string publicKey = "i56661980553";
            //string privateKey = "aYw0ELHz22JA4Ci9NAlPgbvVxYy96s9RxuFaoN2y";

            string publicKey = "sandbox_i32455066557";
            string privateKey = "sandbox_eYz5jAZfNYIzcn4wOAYGdkLkBcozxBgEz4olJS24";

            Dictionary<double, string> payInfo = new Dictionary<double, string>();

            payInfo = GetPayInfo();

            decimal amount = Convert.ToDecimal(payInfo.First().Key);
            string description = payInfo.First().Value;

            string liqPayId = orderId;

            string url = "http://d8de30ce.ngrok.io/liqPay/" + liqPayId;

            liqPay = new Payment(publicKey, privateKey);
            testCheck.action = "pay";
            testCheck.amount = amount;
            testCheck.currency = "UAH";
            testCheck.language = "ru";

            if (HttpContext.Current.Request.Cookies["lang"].Value == "en")
            {
                testCheck.currency = "EUR";
                testCheck.language = "en";
            }

            if (HttpContext.Current.Request.Cookies["lang"].Value == "uk")
                testCheck.language = "uk";

            //testCheck.description = description;
            testCheck.order_id = orderId;
            testCheck.result_url = "http://localhost:54745/ClearCookie/Index";//возврат на сайт
            testCheck.server_url = url; //возврат данных (может быть метод)
            testCheck.version = 3;
            testCheck.sandbox = 0;

            var paymentData = Payment.HandleCheckout(testCheck);

            return paymentData;
        }

        Dictionary<double, string> GetPayInfo()
        {
            HttpCookie cookieReq = HttpContext.Current.Request.Cookies[cookieName];

            List<string> descr = new List<string>();

            if (cookieReq != null)
            {
                #region Получение корзины из куки
                string data = cookieReq[cart];

                var temp = data.Split('|').ToList();

                Dictionary<int, int> cookieData = new Dictionary<int, int>();

                foreach (var t in temp)
                    cookieData.Add(Convert.ToInt32(t.Split(',')[0]), Convert.ToInt32(t.Split(',')[1]));

                foreach (var tempData in cookieData)
                {
                    descr.Add("Товар: " + _db.ItemsDB.Find(tempData.Key).Id + "," +
                        "Количество: " + tempData.Value.ToString() + ";");
                }
                #endregion

                descr.Add("Общая стоимость: " + totalPrice.ToString());
            }

            var description = "";

            foreach (var data in descr)
                description += data.ToString();

            Dictionary<double, string> info = new Dictionary<double, string>();

            info.Add(totalPrice, description);

            return info;
        }
    }
}