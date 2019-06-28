using InternetProvider.Logic.DTO;
using InternetProvider.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InternetProvider.Web.Controllers
{
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
        public ActionResult AddService(ServiceDTO model)
        {
            if (ModelState.IsValid)
                return View();
            else return View(model);
        }

        //GET: Content/AddService
        [HttpGet]
        public ActionResult EditService()
        {
            return View();
        }

        //POST: Content/AddService
        [HttpPost]
        public ActionResult EditService(ServiceDTO model)
        {
            if (ModelState.IsValid)
                return View();
            else return View(model);
        }



    }
}