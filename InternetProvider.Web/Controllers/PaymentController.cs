using InternetProvider.Logic.Interfaces;
using InternetProvider.Web.Infrastructure;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using static InternetProvider.Web.Controllers.AccountController;

namespace InternetProvider.Web.Controllers
{
    [Authorize]
    public class PaymentController : Controller
    {
        private readonly IAccountService _accountService;
        public PaymentController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpGet]
        public ActionResult Payment(int? amount)
        {
            return View(LiqPayHelper.GetLiqPayModel(Guid.NewGuid().ToString(), amount.HasValue?amount.Value:100));
        }

        public ActionResult Pay()
        {
            var request_dictionary = Request.Form.AllKeys.ToDictionary(key => key, key => Request.Form[key]);

            byte[] request_data = Convert.FromBase64String(request_dictionary["data"]);
            string decodedString = Encoding.UTF8.GetString(request_data);
            var request_data_dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(decodedString);
            var mySignature = LiqPayHelper.GetLiqPaySignature(request_dictionary["data"]);

            if (mySignature != request_dictionary["signature"])
                return RedirectToAction("UserPage", "Account", new { Message = ManageMessageId.Error });


            if (request_data_dictionary["status"] == "sandbox" || request_data_dictionary["status"] == "success")
            {
                var account = _accountService.GetUserAccount(User.Identity.GetUserId());
                _accountService.AddToBalance(account.Id.ToString(), double.Parse(request_data_dictionary["amount"]));
                return RedirectToAction("UserPage","Account", new { Message = ManageMessageId.PaymentSuccess });
            }

            return RedirectToAction("UserPage", "Account", new { Message = ManageMessageId.Error});
        }
    }
}