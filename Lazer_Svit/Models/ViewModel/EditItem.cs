using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lazer_Svit.Models.ViewModel
{
    public class EditItem
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Feedback { get; set; }
    }
}