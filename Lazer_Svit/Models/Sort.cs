using Lazer_Svit.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lazer_Svit.Models
{
    public class Sort
    {
        DatabaseContext _db = new DatabaseContext();

        public List<Item> SortItemByPopularity(string categoryName)
        {
            var language = Cookie.CheckLanguageCookie();

            List<Item> data = new List<Item>();

            switch (language)
            {
                case "uk":
                    var dataUA =
                        (from entry in _db.ItemsDB
                         where entry.CategoryUA == categoryName
                         orderby entry.orderCount descending
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
                    var dataEN =
                        (from entry in _db.ItemsDB
                         where entry.CategoryEN == categoryName
                         orderby entry.orderCount descending
                         select new Item
                         {
                             Id = entry.Id,
                             Category = entry.CategoryEN,
                             Name = entry.NameEN,
                             Image = entry.Image,
                             Price = entry.Price,
                             Description = entry.DescriptionEN
                         }).ToList();
                    data = dataEN;
                    break;
                default:
                    var dataRU =
                        (from entry in _db.ItemsDB
                         where entry.CategoryRU == categoryName
                         orderby entry.orderCount descending
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

        public List<Item> SortItemByPriceLow(string categoryName)
        {
            var language = Cookie.CheckLanguageCookie();

            List<Item> data = new List<Item>();

            switch (language)
            {
                case "uk":
                    var dataUA =
                        (from entry in _db.ItemsDB
                         where entry.CategoryUA == categoryName
                         orderby entry.Price ascending
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
                    var dataEN =
                        (from entry in _db.ItemsDB
                         where entry.CategoryEN == categoryName
                         orderby entry.Price ascending
                         select new Item
                         {
                             Id = entry.Id,
                             Category = entry.CategoryEN,
                             Name = entry.NameEN,
                             Image = entry.Image,
                             Price = entry.Price,
                             Description = entry.DescriptionEN
                         }).ToList();
                    data = dataEN;
                    break;
                default:
                    var dataRU =
                        (from entry in _db.ItemsDB
                         where entry.CategoryRU == categoryName
                         orderby entry.Price ascending
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

        public List<Item> SortItemByPriceHigh(string categoryName)
        {
            var language = Cookie.CheckLanguageCookie();

            List<Item> data = new List<Item>();

            switch (language)
            {
                case "uk":
                    var dataUA =
                        (from entry in _db.ItemsDB
                         where entry.CategoryUA == categoryName
                         orderby entry.Price descending
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
                    var dataEN =
                        (from entry in _db.ItemsDB
                         where entry.CategoryEN == categoryName
                         orderby entry.Price descending
                         select new Item
                         {
                             Id = entry.Id,
                             Category = entry.CategoryEN,
                             Name = entry.NameEN,
                             Image = entry.Image,
                             Price = entry.Price,
                             Description = entry.DescriptionEN
                         }).ToList();
                    data = dataEN;
                    break;
                default:
                    var dataRU =
                        (from entry in _db.ItemsDB
                         where entry.CategoryRU == categoryName
                         orderby entry.Price descending
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
    }
}