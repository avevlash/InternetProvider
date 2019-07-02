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
        public string Service_Id { get; set; }
        public double Price { get; set; }
        public string TariffName { get; set; }
        public string TariffProperties { get; set; }
        public long ValidityPeriodTicks { get; set; }
        public TimeSpan ValidityPeriod
        {
            get { return TimeSpan.FromTicks(ValidityPeriodTicks); }
            set { ValidityPeriodTicks = value.Ticks; }
        }
    }
}
