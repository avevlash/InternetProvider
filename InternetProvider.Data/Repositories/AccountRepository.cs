using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using InternetProvider.Data.EntityModels;
using InternetProvider.Logic.DTO;
using InternetProvider.Logic.Interfaces;

namespace InternetProvider.Data.Repositories
{
    public class AccountRepository:IRepository<AccountDTO>
    {
        private readonly InetContext _context;
        private readonly IMapper _mapper;

        public AccountRepository(InetContext ctx, IMapper mapper)
        {
            _context = ctx;
            _mapper = mapper;
        }

        public IEnumerable<AccountDTO> GetAll()
        {
            var accounts = _context.AccountEntities.ToList();
            var dtos = _mapper.Map<IEnumerable<AccountDTO>>(accounts);
            return dtos;
        }

        public AccountDTO Get(string id)
        {
            return _mapper.Map<AccountDTO>(_context.AccountEntities.Find(id));
        }

        public void Create(AccountDTO item)
        {
            _context.AccountEntities.Add(_mapper.Map<AccountEntity>(item));
        }

        public void Update(AccountDTO item)
        {
            _context.AccountEntities.AddOrUpdate(_mapper.Map<AccountEntity>(item));
        }

        public void Delete(string id)
        {
            _context.AccountEntities.Remove(_context.AccountEntities.Find(id));
        }
    }
}
