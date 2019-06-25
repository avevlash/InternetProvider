using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetProvider.Logic.DTO
{
    public class AccountDTO
    {
        public Guid Id { get; set; }
        public virtual UserDTO User { get; set; }
        public virtual List<TariffDTO> Tariffs { get; set; }
        public double Balance { get; set; }
    }
}
