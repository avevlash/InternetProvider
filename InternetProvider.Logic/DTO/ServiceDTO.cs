using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetProvider.Logic.DTO
{
    public class ServiceDTO
    {
        public Guid Id { get; set; }
        public string ServiceName { get; set; }
        public string Properties { get; set; }
        public int CurrentUsers { get; set; }
        public virtual List<TariffDTO> TariffList { get; set; }
    }
}
