using System;
using System.Collections.Generic;
using InternetProvider.Logic.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternetProvider.Logic.DTO;
using InternetProvider.Logic.Interfaces;

namespace InternetProvider.Logic.Services
{
    public class AccountService:IAccountService
    {
        private readonly IUnitOfWork _store;
        public AccountService(IUnitOfWork unit)
        {
            _store = unit;
        }
        public AccountDTO GetUserAccount(string userId)
        {
            return _store.Accounts.GetAll().FirstOrDefault(x => x.User_Id == userId);
        }

        public void AddToBalance(string id, double value)
        {
            if (value < 0.0) throw new ValidationException("Added value cannot be negative", "Balance");
            var account = _store.Accounts.Get(id);
            account.Balance +=value;
            _store.Accounts.Update(account);
            _store.Save();
        }

        public void Withdraw(string id, double value)
        {
            if (value < 0.0) throw new ValidationException("Withdrawn value cannot be negative", "Balance");
            var account = _store.Accounts.Get(id);
            account.Balance -= value;
            _store.Accounts.Update(account);
            _store.Save();
        }

        public void AddTariffs(string accountId, IEnumerable<TariffDTO> tariffs)
        {
            var account = _store.Accounts.Get(accountId);
            foreach(var item in account.Tariffs)
            {
                if (tariffs.Any(x=>x.Service.Id == item.Tariff.Service.Id)) account.Tariffs.Remove(item); //replacing old tariff with new
                
                if (tariffs.Contains(item.Tariff)) throw new ValidationException("User can be subscribed to tariff only once", "Tariffs");
            }
            foreach(var tariff in tariffs)
            {
                _store.UserTariffs.Create(new UserTariffDTO()
                {
                    Account_Id = account.Id,
                    Tariff_Id = tariff.Id.ToString(),
                    BeginDate = DateTime.Now,
                    EndDate = DateTime.Now + tariff.ValidityPeriod
                });
            }
            _store.Accounts.Update(account);
            _store.Save();
        }
        public void RemoveTariffs(string accountId, IEnumerable<TariffDTO> tariffs)
        {
            var account = _store.Accounts.Get(accountId);
            //foreach (var item in account.Tariffs)
            //{
            //    if (!tariffs.Contains(item.Tariff)) throw new ValidationException("User can't be unsubscribed from tariff he didn't subscribe to", "Tariffs");
            //}
            foreach(var tariff in tariffs)
            {
                var usertariff = _store.UserTariffs.GetAll().FirstOrDefault(x => x.Tariff_Id == tariff.Id.ToString() && x.Account_Id == account.Id);
                if (usertariff != null)
                    _store.UserTariffs.Delete(usertariff.Id.ToString());
                else throw new ValidationException($"Attempt to delete unexisting user tariff {tariff.TariffName}", "UserTariffs");
            }
            _store.Save();
        }

        public bool PayFees(string accountId)
        {
            var account = _store.Accounts.Get(accountId);
            var tariffsToPay = account.Tariffs.FindAll(x=>x.EndDate < DateTime.Now);
            var price = tariffsToPay.Sum(x => x.Tariff.Price);
            if (price > account.Balance) return false;
            Withdraw(accountId, price);
            return true;
        }

        public AccountDTO RegisterAccount(string userId, double balance = 0.00)
        {
            var account = new AccountDTO()
            {
                User_Id = userId,
                Balance = balance,
                Tariffs = new List<UserTariffDTO>()
            };
            _store.Accounts.Create(account);
            _store.Save();
            return account;
        }

        public void RemoveAccount(string accountId)
        {
            _store.Accounts.Delete(accountId);
            _store.Save();
        }
    }
}
