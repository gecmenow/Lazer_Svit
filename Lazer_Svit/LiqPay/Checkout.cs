using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lazer_Svit.LiqPay
{
    public class Checkout
    {
        public string public_key { get; set; }
        public int version { get; set; }
        public string action { get; set; }
        public decimal amount { get; set; }
        public string currency { get; set; }
        public string description { get; set; }
        public string order_id { get; set; }
        public string result_url { get; set; }
        public string language { get; set; }

        public string server_url { get; set; }
        public int sandbox { get; set; }
    }
}