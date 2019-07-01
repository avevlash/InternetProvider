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
        public UserDTO User { get; set; }
        public List<UserTariffDTO> Tariffs { get; set; }
        public double Balance { get; set; }
    }
}
