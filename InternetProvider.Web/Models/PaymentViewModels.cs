using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InternetProvider.Web.Models
{
    public class LiqPayCheckout
    {
        public int version { get; set; }
        public string public_key { get; set; }
        public string action { get; set; }
        public decimal amount { get; set; }
        public string currency { get; set; }
        public string description { get; set; }
        public string order_id { get; set; }
        public string result_url { get; set; }
        public int sandbox { get { return 1; } }
    }
    public class LiqPayCheckoutFormModel
    {
        public string Data { get; set; }
        public string Signature { get; set; }
    }

}