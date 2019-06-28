using InternetProvider.Logic.DTO;
using InternetProvider.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetProvider.Logic.Services
{
    public class UserService:IUserService
    {
        private readonly IUnitOfWork _store;
        public UserService(IUnitOfWork unit)
        {
            _store = unit;
        }
        public List<UserDTO> GetAllUsers() => _store.Users.GetAll().ToList();
        public List<Tuple<string, string>> GetUnregistratedUsers() => 
            _store.Users.GetAll()
                .Where(x => string.IsNullOrEmpty(x.PasswordHash))
                .Select(x => new Tuple<string, string>(x.Id, x.Email))
                .ToList();
        
    }
}
