using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternetProvider.Logic.DTO;

namespace InternetProvider.Logic.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IRepository<UserTariffDTO> UserTariffs { get; }
        IRepository<TariffDTO> Tariffs { get; }
        IRepository<ServiceDTO> Services { get; }
        IRepository<AccountDTO> Accounts { get; }
        IRepository<UserDTO> Users { get; }
        void Save();
    }
}
