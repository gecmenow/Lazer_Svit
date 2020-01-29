using Lazer_Svit.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lazer_Svit.Models
{
    public class Cart
    {
        public DbItems Items { get; set; }
        public Item Item { get; set; }
        public int Quantity { get; set; }
        public double ItemTotalPrice { get; set; }

        public Cart(DbItems items, int quantity, double itemTotalPrice)
        {
            Items = items;
            Quantity = quantity;
            ItemTotalPrice = itemTotalPrice;
        }

        public Cart(Item item, int quantity, double itemTotalPrice)
        {
            Item = item;
            Quantity = quantity;
            ItemTotalPrice = itemTotalPrice;
        }

        public Cart()
        { }

        DatabaseContext _db = new DatabaseContext();

        const string cart = "Cart";
        const string cookieName = "CartCookie";//имя куки

        const string quantity = "Quantity";
        const string cookieCartQuantity = "QuantityCookie";//имя куки

        // Создать объект cookie-набора
        HttpCookie cookie = new HttpCookie(cookieName);
        HttpCookie cookieQuantity = new HttpCookie(cookieCartQuantity);

        List<Cart> cartList = new List<Cart>();

        public List<Cart> ShowCart()
        {
            cartList = CartList.getCartList(); 

            return cartList;
        }

        public void AddProductToEmptyCart(int id)
        {
            cartList.Add(
                new Cart(
                    _db.ItemsDB.Find(id),
                    1,
                    _db.ItemsDB.Find(id).Price
                    )
            );

            string cartString = string.Join("|", cartList.Select(v => v.Items.Id + "," + v.Quantity));

            // Установить значения в нем
            cookie[cart] = cartString;

            // Добавить куки в ответ
            HttpContext.Current.Response.Cookies.Add(cookie);

            // Этот cookie-набор будет оставаться 
            // действительным в течение одного года
            cookie.Expires = DateTime.Now.AddMonths(1);

            cookieQuantity.Value = "1";

            HttpContext.Current.Response.Cookies.Add(cookieQuantity);

            cookieQuantity.Expires = DateTime.Now.AddMonths(1);
        }

        public void AddProductIfCartNotNull(int id)
        {
            HttpCookie cookieReq = HttpContext.Current.Request.Cookies[cookieName];

            #region Получение корзины из куки
            string data = cookieReq[cart];

            var temp = data.Split('|').ToList();

            Dictionary<int, int> cookieData = new Dictionary<int, int>();

            foreach (var t in temp)
                cookieData.Add(Convert.ToInt32(t.Split(',')[0]), Convert.ToInt32(t.Split(',')[1]));

            List<Cart> cartList = new List<Cart>();

            foreach (var tempData in cookieData)
            {
                cartList.Add(
                    new Cart(
                        _db.ItemsDB.Find(tempData.Key),
                        tempData.Value,
                        _db.ItemsDB.Find(tempData.Key).Price
                        )
                        );
            }
            #endregion
            cartList.Add(
                new Cart(
                        _db.ItemsDB.Find(id),
                        1,
                        _db.ItemsDB.Find(id).Price
                        )
                        );

            string arrayJoin = string.Join("|", cartList.Select(v => v.Items.Id + "," + v.Quantity));

            cookie[cart] = arrayJoin;

            HttpContext.Current.Response.Cookies.Add(cookie);

            cookie.Expires = DateTime.Now.AddMonths(1);

            int number = 0;

            foreach (var dataCounter in cartList)
                number += dataCounter.Quantity;

            cookieQuantity.Value = number.ToString();

            HttpContext.Current.Response.Cookies.Add(cookieQuantity);

            cookieQuantity.Expires = DateTime.Now.AddMonths(1);
        }

        public void EditItemQuantity(int id, int quantity)
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

                List<Cart> cartList = new List<Cart>();

                foreach (var tempData in cookieData)
                {
                    cartList.Add(
                        new Cart(
                            _db.ItemsDB.Find(tempData.Key),
                            tempData.Value,
                            _db.ItemsDB.Find(tempData.Key).Price * tempData.Value
                            )
                            );
                }
                #endregion

                foreach (var item in cartList)
                    if (item.Items.Id == id)
                        item.Quantity = quantity;

                string cartString = string.Join("|", cartList.Select(v => v.Items.Id + "," + v.Quantity));

                cookie[cart] = cartString;

                HttpContext.Current.Response.Cookies.Add(cookie);

                cookie.Expires = DateTime.Now.AddMonths(1);

                int number = 0;

                foreach (var item in cartList)
                    number += item.Quantity;

                cookieQuantity.Value = number.ToString();

                HttpContext.Current.Response.Cookies.Add(cookieQuantity);

                cookieQuantity.Expires = DateTime.Now.AddMonths(1);
            }
        }

        [OutputCache(Duration = 0)]
        public List<Cart> DeleteItem(int id)
        {
            HttpCookie cookieReq = HttpContext.Current.Request.Cookies[cookieName];
       
            if (cookieReq != null)
            {
                cartList = CartList.getCartList();

                int index = 0;

                for (int i = 0; i < cartList.Count; i++)
                {
                    if (cartList[i].Item.Id == id)
                        index = i;
                }

                cartList.RemoveAt(index);

                if (cartList.Count != 0)
                {
                    string cartString = string.Join("|", cartList.Select(v => v.Item.Id + "," + v.Quantity));

                    cookie[cart] = cartString;

                    HttpContext.Current.Response.Cookies.Add(cookie);

                    cookie.Expires = DateTime.Now.AddMonths(1);

                    int number = 0;

                    foreach (var item in cartList)
                        number += item.Quantity;

                    cookieQuantity.Value = number.ToString();

                    HttpContext.Current.Response.Cookies.Add(cookieQuantity);

                    cookieQuantity.Expires = DateTime.Now.AddMonths(1);
                }
                else
                {
                    Cookie.ClearCookie();
                }
            }

            return cartList;
        }

        public bool IsExisting(int? id)
        {
            HttpCookie cookieReq = HttpContext.Current.Request.Cookies[cookieName];

            #region Получение корзины из куки
            string data = cookieReq[cart];

            var temp = data.Split('|').ToList();

            Dictionary<int, int> cookieData = new Dictionary<int, int>();

            foreach (var t in temp)
                cookieData.Add(Convert.ToInt32(t.Split(',')[0]), Convert.ToInt32(t.Split(',')[1]));

            List<Cart> cartList = new List<Cart>();

            foreach (var tempData in cookieData)
            {
                cartList.Add(
                    new Cart(
                        _db.ItemsDB.Find(tempData.Key),
                        tempData.Value,
                        _db.ItemsDB.Find(tempData.Key).Price * tempData.Value
                        )
                        );
            }
            #endregion

            bool flag = false;

            if (cartList.Any(v => v.Items.Id == id))
                flag = true;

            return flag;
        }
    }
}