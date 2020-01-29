using Lazer_Svit.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lazer_Svit.Models
{
    public class AdminOrder
    {
        public int Id { get; set; }
        public string Items { get; set; }
        public double TotalCost { get; set; }
        public string UserInfo { get; set; }
        public string AdressInfo { get; set; }
        public string Name { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string PostOffice { get; set; }
        public string Delivery { get; set; }
        public string Payment { get; set; }
        public string PaymentStatus { get; set; }
        public string OrderStatus { get; set; }
        public string Country { get; set; }
        public DateTime OrderTime { get; set; }

        DatabaseContext _db = new DatabaseContext();

        public List<AdminOrder> GetOrders()
        {
            var data =
                (from entry in _db.OrderDB
                 orderby entry.Id descending
                 select new AdminOrder
                 {
                     Id = entry.Id,
                     Items = entry.Items,
                     TotalCost = entry.TotalCost,
                     AdressInfo = entry.Name + "," +
                                 entry.Tel + "," +
                                 entry.Country + "," +
                                 entry.City + "," +
                                 entry.Region + "," +
                                 entry.PostOffice + ";",
                     Delivery = entry.Delivery,
                     Payment = entry.Payment,
                     PaymentStatus = entry.PaymentStatus,
                     OrderStatus = entry.OrderStatus,
                     OrderTime = entry.OrderTime,
                 }).ToList();

            foreach (var order in data)
                if (order.AdressInfo == ";")
                    order.AdressInfo = "null";

            foreach (var order in data)
                if (order.UserInfo == ";")
                    order.UserInfo = "null";

            return data;
        }
        
        public AdminOrder GetOrder(int id)
        {
            var data =
                (from entry in _db.OrderDB
                 where entry.Id == id
                 select new AdminOrder
                 {
                    Id = entry.Id,
                    Items = entry.Items,
                    TotalCost = entry.TotalCost,
                    Name = entry.Name,
                    Tel = entry.Tel,
                    Email = entry.Email,
                    City = entry.City,
                    Region = entry.Region,
                    PostOffice = entry.PostOffice,
                    Delivery = entry.Delivery,
                    Payment = entry.Payment,
                    PaymentStatus = entry.PaymentStatus,
                    OrderStatus = entry.OrderStatus,
                    Country = entry.Country,
                    OrderTime = entry.OrderTime,
                 }).First();

            return data;
        }

        public void EditOrder(AdminOrder order)
        {
            var data =
                (from entry in _db.OrderDB
                 where entry.Id == order.Id
                 select entry).ToList();

            foreach (var oldOrder in data)
            {
                oldOrder.Items = order.Items;
                oldOrder.TotalCost = order.TotalCost;
                oldOrder.Name = order.Name;
                oldOrder.Tel = order.Tel;
                oldOrder.Email = order.Email;
                oldOrder.City = order.City;
                oldOrder.Region = order.Region;
                oldOrder.PostOffice = order.PostOffice;
                oldOrder.Delivery = order.Delivery;
                oldOrder.Payment = order.Payment;
                oldOrder.PaymentStatus = order.PaymentStatus;
                oldOrder.Country = order.Country;
                oldOrder.OrderStatus = order.OrderStatus;
            }

            _db.SaveChanges();
        }

        public void DeleteOrder(int id)
        {
            var data = _db.OrderDB.Find(id);

            _db.OrderDB.Remove(data);

            _db.SaveChanges();
        }
    }
}