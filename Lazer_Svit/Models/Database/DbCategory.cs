using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lazer_Svit.Models.Database
{
    public class DbCategory
    {
        public int Id { get; set; }
        [Required]
        public string NameRU { get; set; }
        [Required]
        public string NameUA { get; set; }
        [Required]
        public string NameEN { get; set; }
        [Required]
        public string UrlName { get; set; }
    }
}