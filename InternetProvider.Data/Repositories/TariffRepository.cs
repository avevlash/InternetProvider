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
            var tariffs = _context.TariffEntities.Include("Service").ToList();
            var dtos = _mapper.Map<IEnumerable<TariffDTO>>(tariffs);
            return dtos;
        }

        public TariffDTO Get(string id)
        {
            var tariff = _context.TariffEntities.Include("Service").FirstOrDefault(x=>x.Id.ToString() == id);
            return _mapper.Map<TariffDTO>(tariff);
        }

        public void Create(TariffDTO item)
        {
            var tariff = _mapper.Map<TariffEntity>(item);
            _context.TariffEntities.Add(tariff);
        }

        public void Update(TariffDTO item)
        {
            var oldTariff = _context.TariffEntities.FirstOrDefault(x => x.Id == item.Id);
            if (oldTariff != null)
            {
                TariffEntity tariff = _mapper.Map<TariffEntity>(item);
                _context.Entry(oldTariff).CurrentValues.SetValues(tariff);
            }
            else throw new InvalidOperationException();
        }

        public void Delete(string id)
        {
            _context.TariffEntities.Remove(_context.TariffEntities.Find(id));
        }
    }
}
