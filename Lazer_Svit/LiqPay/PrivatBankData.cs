using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lazer_Svit.LiqPay
{
    public class PrivatBankData
    {
        public string ccy { get; set; }
        public string base_ccy { get; set; }
        public string buy { get; set; }
        public string sale { get; set; }

        public string PbUrl = "https://api.privatbank.ua/p24api/pubinfo?exchange&json&coursid=11";

        public static string getUrl()
        {
            PrivatBankData pb = new PrivatBankData();
            
            return pb.PbUrl;
        }
    }
}