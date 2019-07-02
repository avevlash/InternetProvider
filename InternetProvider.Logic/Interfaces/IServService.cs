using InternetProvider.Logic.DTO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetProvider.Logic.Interfaces
{
    public interface IServService
    {
        /// <summary>
        /// Returns all available services
        /// </summary>
        /// <returns>List<ServiceDTO></returns>
        IEnumerable<ServiceDTO> GetAllServices();
        /// <summary>
        /// Gets service by it's Id
        /// </summary>
        /// <param name="id">Id of service</param>
        /// <returns>ServiceDTO</returns>
        ServiceDTO GetServiceById(string id);
        /// <summary>
        /// Adds new service to database
        /// </summary>
        /// <param name="service">Service to be added</param>
        void AddService(ServiceDTO service);
        /// <summary>
        /// Updates or adds(if record doesn't exist) service to database
        /// </summary>
        /// <param name="service">Service to update or add</param>
        void UpdateService(ServiceDTO service);
        /// <summary>
        /// Removes service from use without deleting
        /// </summary>
        /// <param name="serviceId">Id of service to delete</param>
        void RemoveService(string serviceId);
        /// <summary>
        /// Resets service to use
        /// </summary>
        /// <param name="serviceId">Id of service to restore</param>
        void ResetService(string serviceId);
        /// <summary>
        /// Gets tariff by it's id
        /// </summary>
        /// <param name="id">Id of tariff</param>
        /// <returns>TariffDTO</returns>
        TariffDTO GetTariffById(string id);
        /// <summary>
        /// Returns Pdf document with list of all services and tariffs
        /// </summary>
        /// <returns></returns>
        Document GetServicesInPdf();
        /// <summary>
        /// Adds +1 to CurrentUsers property of service user subscribed to
        /// </summary>
        /// <param name="tariffId">Tariff of service</param>
        void AddUserToService(string tariffId);
        /// <summary>
        /// Removes -1 from CurrentUsers property of service user unsubscribed from
        /// </summary>
        /// <param name="tariffId">Tariff of service</param>
        void RemoveUserFromService(string tariffId);
    }
}
