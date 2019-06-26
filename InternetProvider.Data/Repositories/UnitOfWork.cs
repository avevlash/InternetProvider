using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using InternetProvider.Data.EntityModels;
using InternetProvider.Logic.DTO;
using InternetProvider.Logic.Interfaces;
using Microsoft.AspNet.Identity;

namespace InternetProvider.Data.Repositories
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly InetContext _context;
        private readonly IMapper _mapper;
        private bool disposed = false;
        private AccountRepository _accountRepository;
        private ServiceRepository _serviceRepository;
        private TariffRepository _tariffRepository;
        private UserTariffRepository _userTariffRepository;
        private UserRepository _userRepository;

        public UnitOfWork(string connString, IMapper mapper)
        {
            _context = new InetContext(connString);
            _mapper = mapper;
        }

        public void Dispose()
        {
            if (!disposed)
            { 
                _context.Dispose();
                this.disposed = true;
            }
        }

        public IRepository<TariffDTO> Tariffs
        {
            get
            {
                if (_tariffRepository == null)
                {
                    _tariffRepository = new TariffRepository(_context, _mapper);
                }
                return _tariffRepository;
            }
        }
        public IRepository<UserTariffDTO> UserTariffs
        {
            get
            {
                if (_userTariffRepository == null)
                {
                    _userTariffRepository = new UserTariffRepository(_context, _mapper);
                }
                return _userTariffRepository;
            }
        }
        public IRepository<UserDTO> Users
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_context, _mapper);
                }
                return _userRepository;
            }
        }

        public IRepository<ServiceDTO> Services
        {
            get
            {
                if (_serviceRepository == null)
                {
                    _serviceRepository = new ServiceRepository(_context, _mapper);
                }
                return _serviceRepository;
            }
        }

        public IRepository<AccountDTO> Accounts
        {
            get
            {
                if (_accountRepository == null)
                {
                    _accountRepository = new AccountRepository(_context, _mapper);
                }
                return _accountRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
    
}
