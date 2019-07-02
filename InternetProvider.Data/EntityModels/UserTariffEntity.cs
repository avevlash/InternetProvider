using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetProvider.Data.EntityModels
{
    public class UserTariffEntity:BaseEntity
    {
        public virtual TariffEntity Tariff { get; set; }
        [ForeignKey("Tariff")]
        public Guid Tariff_Id { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
