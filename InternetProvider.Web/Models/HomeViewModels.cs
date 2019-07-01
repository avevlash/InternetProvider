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
    public class ServiceDetailsViewModel
    {
        public string ServiceName { get; set; }
        public string Properties { get; set; }
        public List<TariffDetailViewModel> Tariffs { get; set; }
    }

    public class TariffDetailViewModel
    {
        public string Id { get; set; }
        public double Price { get; set; }
        public string TariffName { get; set; }
        public string TariffProperties { get; set; }
        public int ValidityPeriod { get; set; }
    }
}