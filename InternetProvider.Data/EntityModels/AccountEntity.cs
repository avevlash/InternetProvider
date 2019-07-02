using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetProvider.Data.EntityModels
{
    public class AccountEntity:BaseEntity
    {
        public virtual UserEntity User { get; set; }
        [ForeignKey("User")]
        public string User_Id { get; set; }
        public virtual List<UserTariffEntity> Tariffs { get; set; }
        public double Balance { get; set; }
    }
}
