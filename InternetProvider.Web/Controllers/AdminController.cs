using Castle.Core.Logging;
using InternetProvider.Data.EntityModels;
using InternetProvider.Data.Repositories;
using InternetProvider.Logic.Interfaces;
using InternetProvider.Logic.Services;
using InternetProvider.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace InternetProvider.Web.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private readonly IAccountService _accountService;
        private readonly IUserService _userService;

        public ILogger Logger { get; set; }
        //public AdminController()
        //{
            
        //}

        public AdminController(IAccountService accountService, IUserService userService)
        {
            //UserManager = userManager;
            //SignInManager = signInManager;
            _accountService = accountService;
            _userService = userService;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        /// <summary>
        /// Gets list of all registered users
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var users = _userService.GetRegisteredUsers();
            if (users != null)
            {
                var model = new List<UserViewModel>();
                foreach (var user in users)
                {
                    model.Add(new UserViewModel()
                    {
                        AccountNumber = user.AccountNumber,
                        Email = user.Email,
                        Id = user.Id,
                        IsBlocked = user.LockoutEndDateUtc > DateTime.Now ? true : false,
                        Tariffs = string.Join(", ", _accountService.GetUserAccount(user.Id).Tariffs.Select(x => x.Tariff.TariffName))
                    });
                }
                return View(model);
            }
            else return View();
        }
        /// <summary>
        /// Gets all unregistered users
        /// </summary>
        /// <returns></returns>
        public ActionResult UserIndex()
        {
            var users = _userService.GetUnregistratedUsers();
            if (users != null)
            {
                List<UserListViewModel> model = new List<UserListViewModel>();

                foreach (var item in users)
                {
                    model.Add(new UserListViewModel() { Id = item.Item1, Email = item.Item2 });
                }
                return View(model);
            }
            else return View();
        }

        public async Task<ActionResult> BlockUser(string userId)
        {
            var user = await UserManager.FindByIdAsync(userId).ConfigureAwait(false);
            if (user != null)
            {
                user.LockoutEndDateUtc = DateTime.Now.AddYears(1);
                await UserManager.UpdateAsync(user).ConfigureAwait(false);
                Logger.Info($"User {userId} was blocked.");
                return RedirectToAction("Index");
            }
            else return View("Error");
        }

        public async Task<ActionResult> UnblockUser(string userId)
        {
            var user = await UserManager.FindByIdAsync(userId).ConfigureAwait(false);
            if (user != null)
            {
                user.LockoutEndDateUtc = DateTime.Now.AddDays(-1);
                await UserManager.UpdateAsync(user).ConfigureAwait(false);
                Logger.Info($"User {userId} was unblocked.");
                return RedirectToAction("Index");
            }
            else return View("Error");
        }

        /// <summary>
        /// Fills user's account and sends him activation mail
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> CreateUser(string userId)
        {
            var rand = new Random();
            var user = await UserManager.FindByIdAsync(userId);
            var accNumber = (rand.Next() % 10000000).ToString("000-00-00");
            var users = _userService.GetAllUsers();
            while(users.Any(x=>x.AccountNumber == accNumber))
            {
                accNumber = (rand.Next() % 10000000).ToString("000-00-00");
            }
            user.AccountNumber = accNumber;
            user.LockoutEnabled = true;
            var password = Membership.GeneratePassword(8, 0);
            var res = await UserManager.UpdateAsync(user);
            var result = await UserManager.AddPasswordAsync(user.Id, password);
            if (result.Succeeded)
            {
                _accountService.RegisterAccount(user.Id);
                await SendActivationMail(user.Id);
                Logger.Info($"User {userId} was registered successfully.");
                return RedirectToAction("UserIndex");
            }
            return View("Error");
        }

        #region Helpers
        private async Task SendActivationMail(string userId)
        {
            string code = await UserManager.GeneratePasswordResetTokenAsync(userId);

            // Using protocol param will force creation of an absolut url. We
            // don't want to send a relative URL by e-mail.
            var callbackUrl = Url.Action(
              "ResetPassword",
              "Account",
              new { userId = userId, code = code },
              protocol: Request.Url.Scheme);

            string body = @"<h4>Добро пожаловать в систему!</h4>
                                <p>Чтобы получить доступ к услугам, <a href=""" + callbackUrl + @""">активируйте</a> Ваш аккаунт.</p>
                                <p>Аккаунт должен быть активирован в течение 24 часов с момента получения письма.</p>";

            await UserManager.SendEmailAsync(userId, "Активация аккаунта", body);
        }
        #endregion
    }
}
