using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetProvider.Data.EntityModels
{
    public class UserTariffEntity:BaseEntity
    {
        public virtual TariffEntity Tariff { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
