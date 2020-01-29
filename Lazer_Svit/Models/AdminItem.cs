using Lazer_Svit.Models.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lazer_Svit.Models
{
    public class AdminItem
    {
        public int Id { get; set; }
        //для вывода
        public string Category { get; set; }
        [Required]
        public string CategoryUA { get; set; }
        [Required]
        public string CategoryEN { get; set; }
        [Required]
        public string CategoryRU { get; set; }
        //для вывода
        public string Name { get; set; }
        [Required]
        public string NameUA { get; set; }
        [Required]
        public string NameEN { get; set; }
        [Required]
        public string NameRU { get; set; }
        public string Image { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public string Image4 { get; set; }
        [Required]
        public double Price { get; set; }
        //для вывода
        public string Description { get; set; }
        [Required]
        public string DescriptionUA { get; set; }
        [Required]
        public string DescriptionEN { get; set; }
        [Required]
        public string DescriptionRU { get; set; }
        public List<DbProductReview> Reviews { get; set; }

        DatabaseContext _db = new DatabaseContext();

        public AdminItem ItemInfo(int id)
        {
            var data =
                (from entry in _db.ItemsDB
                where entry.Id == id
                select new AdminItem
                {
                    Id = entry.Id,
                    CategoryUA = entry.CategoryUA,
                    CategoryRU = entry.CategoryRU,
                    CategoryEN = entry.CategoryEN,
                    NameUA = entry.NameUA,
                    NameRU = entry.NameRU,
                    NameEN = entry.NameEN,
                    Image = entry.Image,
                    Image2 = entry.Image2,
                    Image3 = entry.Image3,
                    Image4 = entry.Image4,
                    Price = entry.Price,
                    DescriptionUA = entry.DescriptionUA,
                    DescriptionRU = entry.DescriptionRU,
                    DescriptionEN = entry.DescriptionEN
                }).First();

            var reviews =
                 (from entry in _db.ProductReviewsDB
                  where entry.ItemId == id
                  select entry).ToList();

            data.Reviews = reviews;

            return data;
        }
    }
}