using Lazer_Svit.Hashing;
using Lazer_Svit.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lazer_Svit.Models
{
    public class Order
    {
        string sharedKey = "5553535";

        public int Id { get; set; }
        public string Items { get; set; }
        public double TotalCost { get; set; }
        public string UserInfo { get; set; }
        public string AdressInfo { get; set; }
        public string Delivery { get; set; }
        public string Payment { get; set; }
        public string PaymentStatus { get; set; }
        public string OrderStatus { get; set; }
        public DateTime OrderTime { get; set; }

        DatabaseContext _db = new DatabaseContext();

        public void AddOrder(string name, string tel, string email,
            string region, string city, string address, string delivery, string payment,
            string payStatus, string country, string liqPyaId)
        {
            string orderStatus = "";

            if (name == null)
                name = "ФИО";
            if (tel == null)
                tel = "Номер";
            if (email == null)
                email = "Почта";
            if (region == null)
                region = "Область";
            if (city == null)
                city = "Город";
            if (address == null)
                address = "Адрес";
            if (delivery == null)
                delivery = "Доставка";
            if (payment == null)
                payment = "Оплата";
            if (payStatus == "" || payStatus == null)
                payStatus = "Не оплачено";
            if (country == null)
                country = "Страна";
            if (orderStatus == null || orderStatus == "")
                orderStatus = "В обработке";
            if (payment != "Visa/MaterCard")
                liqPyaId = "000";

            payStatus = "Не оплачено";

            _db.OrderDB.Add(new DbOrder
            {
                Items = GetItemsFromCookie(),
                TotalCost = GetTotalCost(),
                Name = name,
                Tel = tel,
                Email = email,
                Region = region,
                City = city,
                PostOffice = address,
                Delivery = delivery,
                Payment = payment,
                OrderTime = DateTime.Now,
                PaymentStatus = payStatus,
                Country = country,
                OrderStatus = orderStatus,
                LiqPayId = liqPyaId,
            });

            _db.SaveChanges();
        }

        public void AddOneClikOrder(int id, string tel)
        {
            string name = "ФИО";
            string email = "Почта";
            string region = "Область";
            string city = "Город";
            string address = "Адрес";
            string delivery = "Доставка";
            string payment = "Оплата";
            string payStatus = "Не оплачено";
            string country = "Страна";
            string orderStatus = "В обработке";
            string liqPyaId = "000";

            _db.OrderDB.Add(new DbOrder
            {
                Items = _db.ItemsDB.Where(v => v.Id == id).Select(v => v.NameRU).First(),
                TotalCost = 0,
                Name = name,
                Tel = tel,
                Email = email,
                Region = region,
                City = city,
                PostOffice = address,
                Delivery = delivery,
                Payment = payment,
                OrderTime = DateTime.Now,
                PaymentStatus = payStatus,
                Country = country,
                OrderStatus = orderStatus,
                LiqPayId = liqPyaId,
            });

            _db.SaveChanges();
        }

            public double GetTotalCost()
        {
            const string cart = "Cart";
            const string cookieName = "CartCookie";//имя куки

            HttpCookie cookieReq = HttpContext.Current.Request.Cookies[cookieName];

            string data = cookieReq[cart];

            var temp = data.Split('|').ToList();

            Dictionary<int, int> cookieData = new Dictionary<int, int>();

            foreach (var t in temp)
                cookieData.Add(Convert.ToInt32(t.Split(',')[0]), Convert.ToInt32(t.Split(',')[1]));

            double totaPrice = 0;

            foreach (var tempData in cookieData)
                totaPrice += tempData.Value * _db.ItemsDB.Find(tempData.Key).Price;

            return totaPrice;
        }

        public void EditOrderByLiqPayID(string liqPayId, string status)
        {
            var data =
                (from entry in _db.OrderDB
                 where entry.LiqPayId == liqPayId
                 select entry).ToList();

            if(status == "sucess")
                foreach (var oldOrder in data)
                    oldOrder.PaymentStatus = "Оплачено";
            
            _db.SaveChanges();
        }

        public string GetItemsFromCookie()
        {
            const string cart = "Cart";
            const string cookieName = "CartCookie";//имя куки

            HttpCookie cookieReq = HttpContext.Current.Request.Cookies[cookieName];

            List<string> items = new List<string>();

            string data = cookieReq[cart];

            var temp = data.Split('|').ToList();

            Dictionary<int, int> cookieData = new Dictionary<int, int>();

            foreach (var t in temp)
                cookieData.Add(Convert.ToInt32(t.Split(',')[0]), Convert.ToInt32(t.Split(',')[1]));

            double totalPrice = 0;

            foreach (var tempData in cookieData)
            {
                items.Add("Id: " + _db.ItemsDB.Find(tempData.Key).Id + "," +
                    "Название: " + _db.ItemsDB.Find(tempData.Key).NameRU + "," +
                    "Кол-во: " + tempData.Value.ToString() + ";");
                _db.ItemsDB.Find(tempData.Key).orderCount += 1;

                totalPrice += _db.ItemsDB.Find(tempData.Key).Price * tempData.Value;
            }

            items.Add("Общая стоимость: " + totalPrice.ToString() + ".");

            var info = "";

            foreach (var item in items)
                info += item.ToString();

            return info;
        }
    }

}