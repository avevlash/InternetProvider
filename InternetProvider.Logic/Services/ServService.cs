using InternetProvider.Logic.DTO;
using InternetProvider.Logic.Infrastructure;
using InternetProvider.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetProvider.Logic.Services
{
    public class ServService:IServService
    {
        private readonly IUnitOfWork _store;
        public ServService(IUnitOfWork unit)
        {
            _store = unit;
        }
        public IEnumerable<ServiceDTO> GetAllServices() => _store.Services.GetAll();

        public ServiceDTO GetServiceById(string id) => _store.Services.Get(id);

        public void AddService(ServiceDTO service)
        {
            _store.Services.Create(service);
            _store.Save();
        }

        public void UpdateService(ServiceDTO service)
        {
            _store.Services.Update(service);
            _store.Save();
        }

        public void RemoveService(string serviceId)
        {
            _store.Services.Delete(serviceId);
            _store.Save();
        }

        public void ChangeTariffList(string serviceId, IEnumerable<TariffDTO> tariffs)
        {
            var service = _store.Services.Get(serviceId);
            service.TariffList = tariffs.ToList();
            _store.Services.Update(service);
            _store.Save();
        }
    }
}
