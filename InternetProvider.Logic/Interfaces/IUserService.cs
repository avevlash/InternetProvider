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
        List<UserDTO> GetAllUsers();
        List<Tuple<string, string>> GetUnregistratedUsers();
    }
}
