using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QaisYousuf.Services;
using QaisYousuf.ViewModels;

namespace QaisYousuf.Web.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IAuthenticationServices authServices;

        public AccountsController(IAuthenticationServices authServices)
        {
            this.authServices = authServices;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel viewmodel)
        {
            if(!ModelState.IsValid)
            {
                return View(viewmodel);
            }

            bool registerSuccess = authServices.Register(viewmodel.Email, viewmodel.UserName, viewmodel.Password, out int? userId);

            if(!registerSuccess)
            {
                ModelState.AddModelError("", "User already exists");
                return View(viewmodel);
            }

            TempData["Success"] = "Registratin Successful";

            return RedirectToAction(nameof(Register));
        }
    }
}