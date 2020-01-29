using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lazer_Svit.Models.Database
{
    public class DbItems
    {
        public int Id { get; set; }
        [Required]
        public string CategoryUA { get; set; }
        [Required]
        public string CategoryRU { get; set; }
        [Required]
        public string CategoryEN { get; set; }
        [Required]
        public string NameUA { get; set; }
        [Required]
        public string NameRU { get; set; }
        [Required]
        public string NameEN { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public string Image2 { get; set; }
        [Required]
        public string Image3 { get; set; }
        [Required]
        public string Image4 { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string DescriptionUA { get; set; }
        [Required]
        public string DescriptionRU { get; set; }
        [Required]
        public string DescriptionEN { get; set; }
        public int orderCount { get; set; }
    }
}