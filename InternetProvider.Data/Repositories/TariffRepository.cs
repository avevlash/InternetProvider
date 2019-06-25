using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public class TariffRepository:IRepository<TariffDTO>
    {
        private readonly InetContext _context;
        private readonly IMapper _mapper;

        public TariffRepository(InetContext ctx, IMapper mapper)
        {
            _context = ctx;
            _mapper = mapper;
        }
        public IEnumerable<TariffDTO> GetAll()
        {
            var tariffs = _context.TariffEntities.ToList();
            var dtos = _mapper.Map<IEnumerable<TariffDTO>>(tariffs);
            return dtos;
        }

        public TariffDTO Get(string id)
        {
            var tariff = _context.TariffEntities.Find(id);
            return _mapper.Map<TariffDTO>(tariff);
        }

        public void Create(TariffDTO item)
        {
            _context.TariffEntities.Add(_mapper.Map<TariffEntity>(item));
        }

        public void Update(TariffDTO item)
        {
            _context.TariffEntities.AddOrUpdate(_mapper.Map<TariffEntity>(item));
        }

        public void Delete(string id)
        {
            _context.TariffEntities.Remove(_context.TariffEntities.Find(id));
        }
    }
}
