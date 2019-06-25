using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetProvider.Logic.DTO
{
    public class TariffDTO
    {
        public Guid Id { get; set; }
        public ServiceDTO Service { get; set; }
        public double Price { get; set; }
        public string TariffName { get; set; }
        public string TariffProperties { get; set; }
    }
}
