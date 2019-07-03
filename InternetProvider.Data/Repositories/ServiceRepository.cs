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
            return _mapper.Map<ServiceDTO>(_context.ServiceEntities.Include("TariffList").FirstOrDefault(x=>x.Id.ToString() == id));
        }

        public void Create(ServiceDTO item)
        {
            var service = _mapper.Map<ServiceEntity>(item);
            _context.ServiceEntities.Add(service);
        }

        public void Update(ServiceDTO item)
        {
            var oldService = _context.ServiceEntities.FirstOrDefault(x => x.Id == item.Id);
            if (oldService != null)
            {
                var service = _mapper.Map<ServiceEntity>(item);
                _context.Entry(oldService).CurrentValues.SetValues(service);
            }
            else throw new InvalidOperationException();
        }

        public void Delete(string id)
        {
            try
            {
                var Id = Guid.Parse(id);
                var tar = _context.ServiceEntities.First(x => x.Id == Id);
                _context.ServiceEntities.Remove(tar);
            }
            catch (Exception e)
            {
                var exc = e;
                throw;
            }
        }
    }
}
