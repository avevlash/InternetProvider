﻿using InternetProvider.Logic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetProvider.Logic.Interfaces
{
    public interface IServService
    {
        IEnumerable<ServiceDTO> GetAllServices();
        void AddService(ServiceDTO service);
        void RemoveService(string serviceId);
        void ChangeTariffList(string serviceId, IEnumerable<TariffDTO> tariffs);
    }
}