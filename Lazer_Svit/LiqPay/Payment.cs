using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Lazer_Svit.LiqPay
{
    public class Payment
    {
        private static string private_key;
        private static string public_key;

        public Payment(string public_key, string private_key)
        {
            Payment.private_key = private_key;
            Payment.public_key = public_key;
        }

        public static PaymentData HandleCheckout(Checkout checkout)
        {
            var paymentData = new PaymentData();

            checkout.public_key = Payment.public_key;

            var json_string = JsonConvert.SerializeObject(checkout);
            var data = Convert.ToBase64String(Encoding.UTF8.GetBytes(json_string));
            var signature = GetSignature(data);

            paymentData.data = data;
            paymentData.signature = signature;

            return paymentData;
        }
        public static string GetSignature(string data)
        {
            return Convert.ToBase64String(SHA1.Create().ComputeHash(Encoding.UTF8.GetBytes(private_key + data + private_key)));
        }
    }
}