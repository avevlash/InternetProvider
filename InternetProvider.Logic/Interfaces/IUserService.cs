using InternetProvider.Logic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetProvider.Logic.Interfaces
{
   
    public interface IUserService
    {
        /// <summary>
        /// Gets all users from database
        /// </summary>
        /// <returns>List<UserDTO></returns>
        List<UserDTO> GetAllUsers();
        /// <summary>
        /// Gets all users that passed registration 
        /// </summary>
        /// <returns>List<UserDTO></returns>
        List<UserDTO> GetRegisteredUsers();
        /// <summary>
        /// Gets users that didn't get registered yet
        /// </summary>
        /// <returns>List<UserDTO></returns>
        List<Tuple<string, string>> GetUnregistratedUsers();
    }
}
