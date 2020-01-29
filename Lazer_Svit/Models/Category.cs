using Lazer_Svit.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lazer_Svit.Models
{
    public class Category
    {
        static DatabaseContext _db = new DatabaseContext();

        public int Id { get; set; }
        public string Name { get; set; }
        public string UrlName { get; set; }

        public List<Category> GetCategories()
        {
            var language = Cookie.CheckLanguageCookie();

            List<Category> data = new List<Category>();

            switch (language)
            {
                case "uk":
                    var dataUA =
                        (from entry in _db.CategoryDB
                         select new Category
                         {
                             Id = entry.Id,
                             Name = entry.NameUA,
                             UrlName = entry.UrlName
                         }).ToList();
                    data = dataUA;
                    break;
                case "en":
                    var dataEN =
                        (from entry in _db.CategoryDB
                         select new Category
                         {
                             Id = entry.Id,
                             Name = entry.NameEN,
                             UrlName = entry.UrlName
                         }).ToList();
                    data = dataEN;
                    break;
                default:
                    var dataRU =
                        (from entry in _db.CategoryDB
                         select new Category
                         {
                             Id = entry.Id,
                             Name = entry.NameRU,
                             UrlName = entry.UrlName
                         }).ToList();
                    data = dataRU;
                    break;
            }

            return data;
        }

        public static string GetCategoryName(string urlName)
        {
            var language = Cookie.CheckLanguageCookie();

            string data = "";

            switch (language)
            {
                case "uk":
                    var dataUA =
                        (from entry in _db.CategoryDB
                         where entry.UrlName == urlName
                         select entry.NameUA).First().ToString();
                    data = dataUA;
                    break;
                case "en":
                    var dataEN =
                       (from entry in _db.CategoryDB
                        where entry.UrlName == urlName
                        select entry.NameEN).First().ToString();
                    data = dataEN;
                    break;
                default:
                    var dataRU =
                       (from entry in _db.CategoryDB
                        where entry.UrlName == urlName
                        select entry.NameRU).First().ToString();
                    data = dataRU;
                    break;
            }

            return data;
        }

        public static string GetEngCategoryName()
        {
            var data =
                (from entry in _db.CategoryDB
                    select entry.UrlName).First().ToString();

            return data;
        }

    }
}