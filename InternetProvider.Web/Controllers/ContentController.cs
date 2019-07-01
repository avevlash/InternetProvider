using InternetProvider.Logic.DTO;
using InternetProvider.Logic.Interfaces;
using InternetProvider.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InternetProvider.Web.Controllers
{
    [Authorize(Roles ="admin")]
    public class ContentController : Controller
    {
        private readonly IServService _servService;
        public ContentController()
        {

        }

        public ContentController(IServService service)
        {
            _servService = service;
        }
        // GET: Content/ServiceIndex
        public ActionResult ServiceIndex()
        {
            var services = _servService.GetAllServices();
            return View(services);
        }

        //GET: Content/AddService
        [HttpGet]
        public ActionResult AddService()
        {
            return View();
        }

        //POST: Content/AddService
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddService(AddServiceViewModel model)
        {
            if (ModelState.IsValid)
            {
                ServiceDTO service = new ServiceDTO()
                {
                    ServiceName = model.ServiceName,
                    Properties = model.Properties,
                    IsInUse = true,
                    CurrentUsers = 0,
                    TariffList = new List<TariffDTO>()
                };
                foreach(var tariff in model.TariffList)
                {
                    service.TariffList.Add(new TariffDTO()
                    {
                        Price = tariff.Price,
                        TariffName = tariff.TariffName,
                        TariffProperties = tariff.TariffProperties,
                        ValidityPeriodTicks = tariff.ValidityPeriod*864000000000
                    });
                }
                _servService.AddService(service);
                return View();
            }
            else return View(model);
        }

        //GET: Content/AddService
        [HttpGet]
        public ActionResult EditService(string serviceId)
        {
            var service = _servService.GetServiceById(serviceId);
            var model = new AddServiceViewModel()
            {
                ServiceName = service.ServiceName,
                Properties = service.Properties,
                TariffList = new List<TariffViewModel>()
            };
            foreach(var tariff in service.TariffList)
            {
                model.TariffList.Add(new TariffViewModel()
                {
                    TariffName = tariff.TariffName,
                    TariffProperties = tariff.TariffProperties,
                    Price = tariff.Price,
                    ValidityPeriod = tariff.ValidityPeriod.Days
                });
            }
            return View(model);
        }

        //POST: Content/AddService
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditService(EditServiceViewModel model)
        {
            if (ModelState.IsValid)
            {
                ServiceDTO service = new ServiceDTO()
                {
                    Id = Guid.Parse(model.Id),
                    ServiceName = model.ServiceName,
                    Properties = model.Properties,
                    IsInUse = true,
                    CurrentUsers = 0,
                    TariffList = new List<TariffDTO>()
                };
                Guid id;
                foreach (var tariff in model.TariffList)
                {
                    var res = Guid.TryParse(tariff.Id, out id);
                    service.TariffList.Add(new TariffDTO()
                    {
                        Id = res?id:Guid.Empty,
                        Price = tariff.Price,
                        TariffName = tariff.TariffName,
                        TariffProperties = tariff.TariffProperties,
                        ValidityPeriodTicks = tariff.ValidityPeriod * 864000000000
                    });
                }
                _servService.UpdateService(service);
                return RedirectToAction("ServiceIndex");
            }
            else return View(model);
        }



    }
}