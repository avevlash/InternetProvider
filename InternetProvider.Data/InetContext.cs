using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternetProvider.Data.EntityModels;
using Microsoft.AspNet.Identity.EntityFramework;

namespace InternetProvider.Data
{
   public class InetContext : IdentityDbContext<UserEntity>
    {
        public InetContext(string connectionString)
            : base(connectionString, throwIfV1Schema: false)
        {

        }
        public DbSet<TariffEntity> TariffEntities { get; set; }
        public DbSet<ServiceEntity> ServiceEntites { get; set; }
        public DbSet<AccountEntity> AccountEntities { get; set; }
        public DbSet<UserEntity> UserEntities { get; set; }
       
    }
}
