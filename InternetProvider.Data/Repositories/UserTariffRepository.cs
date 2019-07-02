using AutoMapper;
using InternetProvider.Data.EntityModels;
using InternetProvider.Logic.DTO;
using InternetProvider.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetProvider.Data.Repositories
{
    class UserTariffRepository : IRepository<UserTariffDTO>
    {
        private readonly InetContext _context;
        private readonly IMapper _mapper;

        public UserTariffRepository(InetContext ctx, IMapper mapper)
        {
            _context = ctx;
            _mapper = mapper;
        }
        public IEnumerable<UserTariffDTO> GetAll()
        {
            var tariffs = _context.UserTariffEntities.Include("Tariff").ToList();
            var dtos = _mapper.Map<IEnumerable<UserTariffDTO>>(tariffs);
            return dtos;
        }

        public UserTariffDTO Get(string id)
        {
            var tariff = _context.UserTariffEntities.Include("Tariff").FirstOrDefault(x=>x.Id.ToString() == id);
            return _mapper.Map<UserTariffDTO>(tariff);
        }

        public void Create(UserTariffDTO item)
        {
            var usertariff = _mapper.Map<UserTariffEntity>(item);
            _context.UserTariffEntities.Add(usertariff);
        }

        public void Update(UserTariffDTO item)
        {
            var oldUserTariff = _context.UserTariffEntities.FirstOrDefault(x => x.Id == item.Id);
            if (oldUserTariff != null)
            {
                var userTariff = _mapper.Map<UserTariffEntity>(item);
                _context.Entry(oldUserTariff).CurrentValues.SetValues(userTariff);
            }
            else throw new InvalidOperationException();
        }

        public void Delete(string id)
        {
            try
            {
                var Id = Guid.Parse(id);
                var tar = _context.UserTariffEntities.First(x=>x.Id==Id);
                _context.UserTariffEntities.Remove(tar);
            }
            catch(Exception e)
            {
                var exc = e;
            }
        }
    }
}

