using InternetProvider.Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace InternetProvider.Web.Infrastructure
{
    public class LiqPayHelper
    {
        static private readonly string _private_key;

        static private readonly string _public_key;

        static LiqPayHelper()
        {
            _public_key = "sandbox_i47543741564";     
            _private_key = "sandbox_muijWCC9WWEs38aIKsSH0tVxe9DZEWqxTH2HRXAK";    
        }
        static public LiqPayCheckoutFormModel GetLiqPayModel(string order_id, int value)
        {

            var signature_source = new LiqPayCheckout()
            {
                public_key = _public_key,
                version = 3,
                action = "pay",
                amount = value,
                currency = "UAH",
                description = "Оплата услуг Интернет и телевидения",
                order_id = order_id,
                result_url = "http://localhost:63897/Payment/Pay",
            };
            var json_string = JsonConvert.SerializeObject(signature_source);
            var data_hash = Convert.ToBase64String(Encoding.UTF8.GetBytes(json_string));
            var signature_hash = GetLiqPaySignature(data_hash);
            var model = new LiqPayCheckoutFormModel();
            model.Data = data_hash;
            model.Signature = signature_hash;
            return model;
        }

        static public string GetLiqPaySignature(string data)
        {
            return Convert.ToBase64String(SHA1.Create().ComputeHash(Encoding.UTF8.GetBytes(_private_key + data + _private_key)));
        }
    }
}