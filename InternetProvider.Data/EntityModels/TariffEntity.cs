using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace InternetProvider.Data.EntityModels
{
    public class TariffEntity:BaseEntity
    {
        public virtual ServiceEntity Service { get; set; }
        [ForeignKey("Service")]
        public Guid Service_Id { get; set; }
        public double Price { get; set; }
        public string TariffName { get; set; }
        public string TariffProperties { get; set; }
        public long ValidityPeriodTicks { get; set; }
        [NotMapped]
        public TimeSpan ValidityPeriod
        {
            get { return TimeSpan.FromTicks(ValidityPeriodTicks); }
            set { ValidityPeriodTicks = value.Ticks; }
        }

    }
}
