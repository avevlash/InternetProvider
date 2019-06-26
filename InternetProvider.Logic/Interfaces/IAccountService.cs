using InternetProvider.Logic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetProvider.Logic.Interfaces
{
    public interface IAccountService
    {
        AccountDTO GetUserAccount(string userId);
        void AddToBalance(string id, double value);
        void Withdraw(string id, double value);
        void AddTariffs(string accountId, IEnumerable<TariffDTO> tariffs);
        void RemoveTariffs(string accountId, IEnumerable<TariffDTO> tariffs);
        bool PayFees(string accountId);
        AccountDTO RegisterAccount(string UserId, double balance = 0.00);
        void RemoveAccount(string accountId);
    }
}
