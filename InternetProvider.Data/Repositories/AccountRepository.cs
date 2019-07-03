using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            var accounts = _context.AccountEntities.Include("Tariffs").Include("User").ToList();
            var dtos = _mapper.Map<IEnumerable<AccountDTO>>(accounts);
            return dtos;
        }

        public AccountDTO Get(string id)
        {
            return _mapper.Map<AccountDTO>(_context.AccountEntities.Include("Tariffs").Include("User").FirstOrDefault(x=>x.Id.ToString() == id));
        }

        public void Create(AccountDTO item)
        {
            var account = _mapper.Map<AccountEntity>(item);
            _context.AccountEntities.Add(account);
        }

        public void Update(AccountDTO item)
        {
            var oldAccount = _context.AccountEntities.FirstOrDefault(x => x.Id == item.Id);
            if (oldAccount != null)
            {
                var account = _mapper.Map<AccountEntity>(item);
                _context.Entry(oldAccount).CurrentValues.SetValues(account);
            }
            else throw new InvalidOperationException();
        }

        public void Delete(string id)
        {
            try
            {
                var Id = Guid.Parse(id);
                var tar = _context.AccountEntities.First(x => x.Id == Id);
                _context.AccountEntities.Remove(tar);
            }
            catch (Exception e)
            {
                var exc = e;
            }
            _context.AccountEntities.Remove(_context.AccountEntities.Find(id));
        }
    }
}
