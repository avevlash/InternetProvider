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
            var tariffs = _context.UserTariffEntities.ToList();
            var dtos = _mapper.Map<IEnumerable<UserTariffDTO>>(tariffs);
            return dtos;
        }

        public UserTariffDTO Get(string id)
        {
            var tariff = _context.UserTariffEntities.Find(id);
            return _mapper.Map<UserTariffDTO>(tariff);
        }

        public void Create(UserTariffDTO item)
        {
            _context.UserTariffEntities.Add(_mapper.Map<UserTariffEntity>(item));
        }

        public void Update(UserTariffDTO item)
        {
            _context.UserTariffEntities.AddOrUpdate(_mapper.Map<UserTariffEntity>(item));
        }

        public void Delete(string id)
        {
            _context.UserTariffEntities.Remove(_context.UserTariffEntities.Find(id));
        }
    }
}

