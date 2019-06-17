using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetProvider.Data.EntityModels
{
    public class AccountEntity
    {
        public virtual UserEntity User { get; set; }
        public virtual List<ServiceEntity> Services { get; set; }
        public double Balance { get; set; }
    }
}
