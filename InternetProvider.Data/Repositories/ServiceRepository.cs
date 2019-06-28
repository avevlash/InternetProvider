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
    public class ServiceRepository:IRepository<ServiceDTO>
    {
        private readonly InetContext _context;
        private readonly IMapper _mapper;

        public ServiceRepository(InetContext ctx, IMapper mapper)
        {
            _context = ctx;
            _mapper = mapper;
        }
        public IEnumerable<ServiceDTO> GetAll()
        {
            var services = _context.ServiceEntities.Include("TariffList").ToList();
            var dtos = _mapper.Map<IEnumerable<ServiceDTO>>(services);
            return dtos;
        }

        public ServiceDTO Get(string id)
        {
            return _mapper.Map<ServiceDTO>(_context.ServiceEntities.Find(id));
        }

        public void Create(ServiceDTO item)
        {
            _context.ServiceEntities.Add(_mapper.Map<ServiceEntity>(item));
        }

        public void Update(ServiceDTO item)
        {
            _context.ServiceEntities.AddOrUpdate(_mapper.Map<ServiceEntity>(item));
        }

        public void Delete(string id)
        {
            _context.ServiceEntities.Remove(_context.ServiceEntities.Find(id));
        }
    }
}
