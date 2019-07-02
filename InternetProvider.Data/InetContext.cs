using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
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

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join(";", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, "The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
            catch(Exception e)
            {
                var innerEx = e.InnerException;
                throw new Exception(e.Message+" "+innerEx?.Message??"");
            }
        }
    }
}
