using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace InternetProvider.Data.EntityModels
{
    public class UserEntity: IdentityUser
    {
        public string AccountNumber { get; set; }
        public string Password { get; set; }
    }
}
