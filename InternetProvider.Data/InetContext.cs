using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using InternetProvider.Data.EntityModels;
using Microsoft.AspNet.Identity.EntityFramework;

namespace InternetProvider.Data
{
   public class InetContext : IdentityDbContext<UserEntity>
    {
        public InetContext():base("InternetProviderDb") { }
        public InetContext(string connectionString)
            : base(connectionString)
        {
        }
        public DbSet<UserTariffEntity> UserTariffEntities { get; set; }
        public DbSet<TariffEntity> TariffEntities { get; set; }
        public DbSet<ServiceEntity> ServiceEntities { get; set; }
        public DbSet<AccountEntity> AccountEntities { get; set; }
    }
}
