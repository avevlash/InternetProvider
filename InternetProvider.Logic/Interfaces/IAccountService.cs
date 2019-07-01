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
        /// <summary>
        /// Gets user account by user's id
        /// </summary>
        /// <param name="userId">User id</param>
        /// <returns>AccountDTO</returns>
        AccountDTO GetUserAccount(string userId);
        /// <summary>
        /// Adds value to account balance found by id
        /// </summary>
        /// <param name="id">Id of account</param>
        /// <param name="value">Balance value to add</param>
        void AddToBalance(string id, double value);
        /// <summary>
        /// Withdraws value from account balance found by id
        /// </summary>
        /// <param name="id">Id of account</param>
        /// <param name="value">Value to withdraw</param>
        void Withdraw(string id, double value);
        /// <summary>
        /// Subscribes user to tariffs
        /// </summary>
        /// <param name="accountId">Id of account</param>
        /// <param name="tariffs">List of tariffs to add</param>
        void AddTariffs(string accountId, IEnumerable<TariffDTO> tariffs);
        /// <summary>
        /// Unsubscribes user from tariffs
        /// </summary>
        /// <param name="accountId">Id of sccount</param>
        /// <param name="tariffs">List of tariffs to remove</param>
        void RemoveTariffs(string accountId, IEnumerable<TariffDTO> tariffs);
        /// <summary>
        /// Withdraws all fees due to tariffs user subscribed to
        /// </summary>
        /// <param name="accountId">Id of account to withdraw</param>
        /// <returns>true if withdrawal was successful and false if balance was unsufficient</returns>
        bool PayFees(string accountId);
        /// <summary>
        /// Method gets called after user registartion or changing accounts of user
        /// </summary>
        /// <param name="UserId">Id of user</param>
        /// <param name="balance">Start balance. Default value is null</param>
        /// <returns></returns>
        AccountDTO RegisterAccount(string UserId, double balance = 0.00);
        /// <summary>
        /// Removes account
        /// </summary>
        /// <param name="accountId">Id of account to remove</param>
        void RemoveAccount(string accountId);
    }
}
