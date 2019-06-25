using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace InternetProvider.Data.EntityModels
{
    public class RoleEntity : IdentityRole
    {
        public RoleEntity() : base()
        {
        }

        public RoleEntity(string name) : base(name)
        {
        }

    }
}