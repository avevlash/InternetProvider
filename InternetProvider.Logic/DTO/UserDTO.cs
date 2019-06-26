using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetProvider.Logic.DTO
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; } 
        public string Password { get; set; }
        public string AccountNumber { get; set; }
        public DateTime LockoutEndDateUtc { get; set; }
    }
}
