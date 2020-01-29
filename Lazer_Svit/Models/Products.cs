using Lazer_Svit.LiqPay;
using Lazer_Svit.Models.Database;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Lazer_Svit.Models
{
    public class Products
    {
        DatabaseContext _db = new DatabaseContext();

        public List<DbItems> GetItems()
        {
            var json = new WebClient().DownloadString(PrivatBankData.getUrl());

            dynamic stuff = JsonConvert.DeserializeObject<List<PrivatBankData>>(json).ToList();

            double sale = stuff[1].sale;

            var data =
                (from entry in _db.ItemsDB
                 select entry).ToList();

            foreach (var item in data)
                item.Price = item.Price / sale;

            return data;
        }

        public List<Item> GetItems(string categoryName)
        {
            var language = Cookie.CheckLanguageCookie();

            List<Item> data = new List<Item>();

            switch (language)
            {
                case "uk":
                    var dataUA =
                        (from entry in _db.ItemsDB
                         where entry.CategoryUA == categoryName
                         orderby entry.Id descending
                         select new Item
                         {
                             Id = entry.Id,
                             Category = entry.CategoryUA,
                             Name = entry.NameUA,
                             Image = entry.Image,
                             Price = entry.Price,
                             Description = entry.DescriptionUA
                         }).ToList();
                    data = dataUA;
                    break;
                case "en":
                    var json = new WebClient().DownloadString(PrivatBankData.getUrl());

                    dynamic stuff = JsonConvert.DeserializeObject<List<PrivatBankData>>(json).ToList();

                    double sale = Convert.ToDouble(stuff[1].sale);

                    var dataEN =
                        (from entry in _db.ItemsDB
                         where entry.CategoryEN == categoryName
                         orderby entry.Id descending
                         select new Item
                         {
                             Id = entry.Id,
                             Category = entry.CategoryEN,
                             Name = entry.NameEN,
                             Image = entry.Image,
                             Price = Math.Round(entry.Price / sale, 2),
                             Description = entry.DescriptionEN
                         }).ToList();
                    data = dataEN;
                    break;
                default:
                    var dataRU =
                        (from entry in _db.ItemsDB
                         where entry.CategoryRU == categoryName
                         orderby entry.Id descending
                         select new Item
                         {
                             Id = entry.Id,
                             Category = entry.CategoryRU,
                             Name = entry.NameRU,
                             Image = entry.Image,
                             Price = entry.Price,
                             Description = entry.DescriptionRU
                         }).ToList();
                    data = dataRU;
                    break;
            }
            return data;
        }

        public void AddItem(IEnumerable<HttpPostedFileBase> uploads, AdminItem item)
        {
            string image = "no_image.png";
            string image2 = "no_image.png";
            string image3 = "no_image.png";
            string image4 = "no_image.png";

            int number = 0;

            foreach (var img in uploads)
            {
                if (img != null && number == 0)
                {
                    image = img.FileName;
                    img.SaveAs(HttpContext.Current.Server.MapPath("~/Content/images/products/" + img.FileName));
                }
                if (img != null && number == 1)
                {
                    image2 = img.FileName;
                    img.SaveAs(HttpContext.Current.Server.MapPath("~/Content/images/products/" + img.FileName));
                }
                if (img != null && number == 2)
                {
                    image3 = img.FileName;
                    img.SaveAs(HttpContext.Current.Server.MapPath("~/Content/images/products/" + img.FileName));
                }
                if (img != null && number == 3)
                {
                    image4 = img.FileName;
                    img.SaveAs(HttpContext.Current.Server.MapPath("~/Content/images/products/" + img.FileName));
                }
                number++;
            }

            _db.ItemsDB.Add(new DbItems
            {
                NameUA = item.NameUA,
                NameRU = item.NameRU,
                NameEN = item.NameEN,
                CategoryUA = item.CategoryUA,
                CategoryRU = item.CategoryRU,
                CategoryEN = item.CategoryEN,
                Image = image,
                Image2 = image2,
                Image3 = image3,
                Image4 = image4,
                Price = item.Price,
                DescriptionUA = item.DescriptionUA,
                DescriptionRU = item.DescriptionRU,
                DescriptionEN = item.DescriptionEN,
                orderCount = 0,
            });

            _db.SaveChanges();
        }

        public void EditItem(IEnumerable<HttpPostedFileBase> uploads, AdminItem item)
        {
            string image = item.Image;
            string image2 = item.Image2;
            string image3 = item.Image3;
            string image4 = item.Image4;

            int number = 0;

            foreach (var img in uploads)
            {
                if (img != null && number == 0)
                {
                    image = img.FileName;
                    img.SaveAs(HttpContext.Current.Server.MapPath("~/Content/images/products/" + img.FileName));
                }
                if (img != null && number == 1)
                {
                    image2 = img.FileName;
                    img.SaveAs(HttpContext.Current.Server.MapPath("~/Content/images/products/" + img.FileName));
                }
                if (img != null && number == 2)
                {
                    image3 = img.FileName;
                    img.SaveAs(HttpContext.Current.Server.MapPath("~/Content/images/products/" + img.FileName));
                }
                if (img != null && number == 3)
                {
                    image4 = img.FileName;
                    img.SaveAs(HttpContext.Current.Server.MapPath("~/Content/images/products/" + img.FileName));
                }
                number++;
            }

            var data =
                 (from entry in _db.ItemsDB
                  where entry.Id == item.Id
                  select entry).ToList();

            foreach (var oldItem in data)
            {
                oldItem.NameUA = item.NameUA;
                oldItem.NameRU = item.NameRU;
                oldItem.NameEN = item.NameEN;
                oldItem.CategoryUA = item.CategoryUA;
                oldItem.CategoryRU = item.CategoryRU;
                oldItem.CategoryEN = item.CategoryEN;
                oldItem.Price = item.Price;
                oldItem.DescriptionUA = item.DescriptionUA;
                oldItem.DescriptionRU = item.DescriptionRU;
                oldItem.DescriptionEN = item.DescriptionEN;
                oldItem.Image = image;
                oldItem.Image2 = image2;
                oldItem.Image3 = image3;
                oldItem.Image4 = image4;
            }

            _db.SaveChanges();
        }        
    }
}