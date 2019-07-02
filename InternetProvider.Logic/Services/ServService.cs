using InternetProvider.Logic.DTO;
using InternetProvider.Logic.Infrastructure;
using InternetProvider.Logic.Interfaces;
using iTextSharp.text;
using iTextSharp.text.pdf;
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
            foreach(var tar in service.TariffList)
            {
                if (tar.Id == Guid.Empty || tar.Id == null)
                {
                    tar.Service_Id = service.Id.ToString();
                    _store.Tariffs.Create(tar);
                }
                else _store.Tariffs.Update(tar);
            }
            _store.Save();
        }

        public void RemoveService(string serviceId)
        {
            var service = _store.Services.Get(serviceId);
            service.IsInUse = false;
            _store.Services.Update(service);
            _store.Save();
        }
        public void ResetService(string serviceId)
        {
            var service = _store.Services.Get(serviceId);
            service.IsInUse = true;
            _store.Services.Update(service);
            _store.Save();
        }

        public TariffDTO GetTariffById(string id) => _store.Tariffs.Get(id);

        public Document GetServicesInPdf()
        {
            Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 15);
            pdfDoc.Open();
            Chunk header = new Chunk("Список услуг и тарифов по ним на " + DateTime.Now.ToShortDateString(), FontFactory.GetFont("Arial", 18, Font.BOLD, BaseColor.BLACK));
            Paragraph para = new Paragraph(header);
            pdfDoc.Add(para);
            PdfPTable table = new PdfPTable(4);
            table.WidthPercentage = 100;
            table.HorizontalAlignment = 1;
            table.SpacingBefore = 20f;
            table.SpacingAfter = 30f;
            var serviceList = _store.Services.GetAll().Where(x => x.IsInUse).ToArray();
            foreach (var service in serviceList)
            {
                PdfPCell nameCell = new PdfPCell();
                nameCell.Colspan = 4;
                nameCell.AddElement(new Chunk(service.ServiceName));
                table.AddCell(nameCell);
                PdfPCell propCell = new PdfPCell();
                propCell.Colspan = 4;
                propCell.AddElement(new Chunk(service.Properties));
                table.AddCell(propCell);
                table.AddCell("Название тарифа");
                table.AddCell("Описание тарифа");
                table.AddCell("Стоимость");
                table.AddCell("Длительность");
                foreach (var item in service.TariffList)
                {
                    table.AddCell(item.TariffName);
                    table.AddCell(item.TariffProperties);
                    table.AddCell($"{item.Price:0.00}");
                    table.AddCell(item.ValidityPeriod.Days +
                         item.ValidityPeriod.Days % 10 == 1 ? " день"
                        : item.ValidityPeriod.Days % 10 > 1 && item.ValidityPeriod.Days % 10 < 5 ? " дня"
                        : " дней");
                }
                PdfPCell emptyCell = new PdfPCell();
                emptyCell.Colspan = 4;
                emptyCell.BorderColor = BaseColor.WHITE;
                emptyCell.AddElement(new Chunk(" "));
                table.AddCell(emptyCell);
            }
            return pdfDoc;
        }

        public void AddUserToService(string tariffId)
        {
            var tariff = _store.Tariffs.Get(tariffId);
            var service = tariff.Service;
            service.CurrentUsers += 1;
            _store.Services.Update(service);
            _store.Save();
        }

        public void RemoveUserFromService(string tariffId)
        {
            var tariff = _store.Tariffs.Get(tariffId);
            var service = tariff.Service;
            service.CurrentUsers -= 1;
            _store.Services.Update(service);
            _store.Save();
        }
    }
}
