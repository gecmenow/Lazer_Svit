using Lazer_Svit.LiqPay;
using Lazer_Svit.Models.Database;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.UI;

namespace Lazer_Svit.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public string Image4 { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }

        DatabaseContext _db = new DatabaseContext();

        public Item GetItemById(int id)
        {
            var language = Cookie.CheckLanguageCookie();

            Item data;

            switch (language)
            {
                case "uk":
                    var dataUA =
                    (from temp in _db.ItemsDB
                     where temp.Id == id
                     select new Item
                     {
                         Id = temp.Id,
                         Category = temp.CategoryUA,
                         Name = temp.NameUA,
                         Image = temp.Image,
                         Image2 = temp.Image2,
                         Image3 = temp.Image3,
                         Image4 = temp.Image4,
                         Price = temp.Price,
                         Description = temp.DescriptionUA
                     }).First();

                    data = dataUA;

                    break;
                case "en":

                    var json = new WebClient().DownloadString(PrivatBankData.getUrl());

                    dynamic stuff = JsonConvert.DeserializeObject<List<PrivatBankData>>(json).ToList();

                    double sale = Convert.ToDouble(stuff[1].sale);

                    var dataEN =
                    (from temp in _db.ItemsDB
                     where temp.Id == id
                     select new Item
                     {
                         Id = temp.Id,
                         Category = temp.CategoryEN,
                         Name = temp.NameEN,
                         Image = temp.Image,
                         Image2 = temp.Image2,
                         Image3 = temp.Image3,
                         Image4 = temp.Image4,
                         Price = Math.Round(temp.Price / sale, 2),
                         Description = temp.DescriptionEN
                     }).First();

                    data = dataEN;

                    break;
                default:
                    var dataRU =
                    (from temp in _db.ItemsDB
                     where temp.Id == id
                     select new Item
                     {
                         Id = temp.Id,
                         Category = temp.CategoryRU,
                         Name = temp.NameRU,
                         Image = temp.Image,
                         Image2 = temp.Image2,
                         Image3 = temp.Image3,
                         Image4 = temp.Image4,
                         Price = temp.Price,
                         Description = temp.DescriptionRU
                     }).First();

                    data = dataRU;

                    break;
            }

            return data;
        }

        public List<Item> GetSameItems(string categoryName)
        {
            var language = Cookie.CheckLanguageCookie();

            List<Item> data = new List<Item>();

            switch (language)
            {
                case "uk":
                    var dataUA =
                    (from temp in _db.ItemsDB
                     where temp.CategoryUA == categoryName
                     select new Item
                     {
                         Id = temp.Id,
                         Category = temp.CategoryUA,
                         Name = temp.NameUA,
                         Image = temp.Image,
                         Price = temp.Price,
                         Description = temp.DescriptionUA
                     }).ToList();

                    data = dataUA;

                    break;
                case "en":
                    var json = new WebClient().DownloadString(PrivatBankData.getUrl());

                    dynamic stuff = JsonConvert.DeserializeObject<List<PrivatBankData>>(json).ToList();

                    double sale = Convert.ToDouble(stuff[1].sale);

                    var dataEN =
                    (from temp in _db.ItemsDB
                     where temp.CategoryEN == categoryName
                     select new Item
                     {
                         Id = temp.Id,
                         Category = temp.CategoryEN,
                         Name = temp.NameEN,
                         Image = temp.Image,
                         Price = Math.Round(temp.Price / sale, 2),
                         Description = temp.DescriptionEN
                     }).ToList();

                    data = dataEN;

                    break;
                default:
                    var dataRU =
                    (from temp in _db.ItemsDB
                     where temp.CategoryRU == categoryName
                     select new Item
                     {
                         Id = temp.Id,
                         Category = temp.CategoryRU,
                         Name = temp.NameRU,
                         Image = temp.Image,
                         Price = temp.Price,
                         Description = temp.DescriptionRU
                     }).ToList();

                    data = dataRU;

                    break;    
            }
                
            List<Item> sameItems = new List<Item>();

            Random r = new Random();

            while(sameItems.Count < 5)
            {
                var number = r.Next(data.Count());

                if (!sameItems.Contains(data[number]))
                    sameItems.Add(data[number]);

                if (sameItems.Count == data.Count)
                    break;
            }

            return sameItems;
        }

        public void DeleteItem(int id)
        {
            var data = _db.ItemsDB.Find(id);

            _db.ItemsDB.Remove(data);

            _db.SaveChanges();
        }
    }
}