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
    public class CartList
    {
        public static List<Cart> getCartList()
        {
            const string cart = "Cart";
            const string cookieName = "CartCookie";//имя куки

            HttpCookie cookieReq = HttpContext.Current.Request.Cookies[cookieName];

            DatabaseContext _db = new DatabaseContext();

            List<Cart> cartList = new List<Cart>();

            if (cookieReq != null)
            {
                #region Получение корзины из куки
                string data = cookieReq[cart];

                var temp = data.Split('|').ToList();

                Dictionary<int, int> cookieData = new Dictionary<int, int>();

                foreach (var t in temp)
                    cookieData.Add(Convert.ToInt32(t.Split(',')[0]), Convert.ToInt32(t.Split(',')[1]));

                var language = Cookie.CheckLanguageCookie();

                switch (language)
                {
                    case "uk":

                        foreach (var tempData in cookieData)
                        {
                            var itemData =
                                (from entry in _db.ItemsDB
                                 where entry.Id == tempData.Key
                                 select new Item
                                 {
                                     Id = entry.Id,
                                     Category = entry.CategoryUA,
                                     Name = entry.NameUA,
                                     Image = entry.Image,
                                     Price = entry.Price,
                                     Description = entry.DescriptionUA
                                 }).First();

                            cartList.Add(
                                new Cart(
                                    itemData,
                                    tempData.Value,
                                    _db.ItemsDB.Find(tempData.Key).Price * tempData.Value
                                    ));
                        }
                        break;

                    case "en":
                        var json = new WebClient().DownloadString(PrivatBankData.getUrl());

                        dynamic stuff = JsonConvert.DeserializeObject<List<PrivatBankData>>(json).ToList();

                        double sale = Convert.ToDouble(stuff[1].sale);

                        foreach (var tempData in cookieData)
                        {
                            var itemData =
                                (from entry in _db.ItemsDB
                                 where entry.Id == tempData.Key
                                 select new Item
                                 {
                                     Id = entry.Id,
                                     Category = entry.CategoryEN,
                                     Name = entry.NameEN,
                                     Image = entry.Image,
                                     Price = Math.Round(entry.Price / sale, 2),
                                     Description = entry.DescriptionEN
                                 }).First();

                            cartList.Add(
                                new Cart(
                                    itemData,
                                    tempData.Value,
                                    Math.Round(_db.ItemsDB.Find(tempData.Key).Price / sale * tempData.Value, 2)
                                    ));
                        }
                        break;
                    default:
                        foreach (var tempData in cookieData)
                        {
                            var itemData =
                                (from entry in _db.ItemsDB
                                 where entry.Id == tempData.Key
                                 select new Item
                                 {
                                     Id = entry.Id,
                                     Category = entry.CategoryRU,
                                     Name = entry.NameRU,
                                     Image = entry.Image,
                                     Price = entry.Price,
                                     Description = entry.DescriptionRU
                                 }).First();

                            cartList.Add(
                                new Cart(
                                    itemData,
                                    tempData.Value,
                                    _db.ItemsDB.Find(tempData.Key).Price * tempData.Value
                                    ));
                        }
                        break;
                }
                #endregion
            }

            return cartList;
        }

        public double TotalPrice()
        {
            const string cart = "Cart";
            const string cookieName = "CartCookie";//имя куки

            DatabaseContext _db = new DatabaseContext();

            HttpCookie cookieReq = HttpContext.Current.Request.Cookies[cookieName];

            double totalPrice = 0;

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

            if (HttpContext.Current.Request.Cookies["lang"].Value == "en")
            {

                var json = new WebClient().DownloadString(PrivatBankData.getUrl());

                dynamic stuff = JsonConvert.DeserializeObject<List<PrivatBankData>>(json).ToList();

                double sale = Convert.ToDouble(stuff[1].sale);

                totalPrice = Math.Round(totalPrice / sale, 2);
            }

            return totalPrice;
        }

        public double DeleteTotalPrice(int id)
        {
            List<Cart> cartList = new List<Cart>();

            cartList = CartList.getCartList();

            int index = 0;

            for (int i = 0; i < cartList.Count; i++)
                if (cartList[i].Item.Id == id)
                    index = i;

            cartList.RemoveAt(index);

            double totalPrice = 0;

            if (cartList.Count != 0)
                foreach (var data in cartList)
                    totalPrice += data.ItemTotalPrice;

            return totalPrice;
        }
    }
}