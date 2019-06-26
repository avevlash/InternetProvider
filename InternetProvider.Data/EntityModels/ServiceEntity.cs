using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetProvider.Data.EntityModels
{
    public class ServiceEntity : BaseEntity
    {
        public string ServiceName { get; set; }
        public string Properties { get; set; }
        public int  CurrentUsers { get; set; }
        public bool IsInUse { get; set; }
        public virtual List<TariffEntity> TariffList { get; set; }
    }
}
