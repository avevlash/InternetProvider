using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InternetProvider.Web.Models
{
    public class ServiceListViewModel
    {
        public string Id { get; set; }
        public string ServiceName { get; set; }
        public string Properties { get; set; }
        public double MinPrice { get; set; }
    }
}