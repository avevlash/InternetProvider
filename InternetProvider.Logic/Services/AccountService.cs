using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternetProvider.Logic.Interfaces;

namespace InternetProvider.Logic.Services
{
    public class AccountService
    {
        private readonly IUnitOfWork _store;
        public AccountService(IUnitOfWork unit)
        {
            _store = unit;
        }
    }
}
