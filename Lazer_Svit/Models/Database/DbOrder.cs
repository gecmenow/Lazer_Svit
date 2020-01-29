using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lazer_Svit.Models.Database
{
    public class DbOrder
    {
        public int Id { get; set; }
        public string Items { get; set; }
        public double TotalCost { get; set; }
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
        public string LiqPayId { get; set; }
        [Required]
        public DateTime OrderTime { get; set; }
    }
}