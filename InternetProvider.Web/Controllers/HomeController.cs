using InternetProvider.Logic.Interfaces;
using InternetProvider.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace InternetProvider.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServService _servService;
        //public HomeController() { }
        public HomeController(IServService service)
        {
            _servService = service;
        }
        public ActionResult Index()
        {
            return View();
        }

       public ActionResult ServiceList()
        {
            var services = _servService.GetAllServices().Where(x => x.IsInUse);
            if (services != null)
            {
                var model = new List<ServiceListViewModel>();
                foreach (var service in services)
                {
                    model.Add(new ServiceListViewModel()
                    {
                        Id = service.Id.ToString(),
                        ServiceName = service.ServiceName,
                        Properties = service.Properties,
                        MinPrice = service.TariffList.Min(x => x.Price)
                    });
                }
                return View(model);
            }
            else return View();
        }

        public ActionResult ServiceDetails(string Id)
        {
            var service = _servService.GetServiceById(Id);
            if (service != null)
            {
                var model = new ServiceDetailsViewModel
                {
                    ServiceName = service.ServiceName,
                    Properties = service.Properties,
                    Tariffs = new List<TariffDetailViewModel>()
                };
                foreach(var tariff in service.TariffList)
                {
                    model.Tariffs.Add(new TariffDetailViewModel()
                    {
                        Id = tariff.Id.ToString(),
                        Price = tariff.Price,
                        TariffName = tariff.TariffName,
                        TariffProperties = tariff.TariffProperties,
                        ValidityPeriod = tariff.ValidityPeriod.Days
                    });
                }
                return View(model);
            }
            else return RedirectToAction("ServiceList");
        }

        public ActionResult SaveServices()
        {
            var pdfDoc = _servService.GetServicesInPdf();
            PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfWriter.CloseStream = false;
            pdfDoc.Close();
            Response.Buffer = true;
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=ServiceList.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(pdfDoc);
            Response.End();
            return View();
        }

        public ActionResult Error()
        {
            return View("Error");
        }
    }
}