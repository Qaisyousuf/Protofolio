using QaisYousuf.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QaisYousuf.Services;
using QaisYousuf.Data.Interfaces;
using QaisYousuf.Services.Security;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace QaisYousuf.Web.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IAuthenticationServices authService;
        private readonly IUnitOfWork uow;

        public AccountsController(IAuthenticationServices authService,IUnitOfWork uow)
        {
            this.authService = authService;
            this.uow = uow;
        }
        // GET: Accounts
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index","Home");
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

            bool registerSuccess = authService.Register(viewmodel.Email, viewmodel
                .UserName, viewmodel.Password, out int? userId);

            if(!registerSuccess)
            {
                ModelState.AddModelError("", "User already exists");
                return View(viewmodel);
            }
            TempData["Success"] = "Registration Successful";
            return RedirectToAction(nameof(Register));
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel viewmodel)
        {
            if(!ModelState.IsValid)
            {
                return View(viewmodel);
            }

            var loginUser = authService.Login(viewmodel.UserName, viewmodel.Password);
            var userExists = uow.UserRepository.UserExists(loginUser.UserName);
            if(!userExists)
            {
                ModelState.AddModelError("", "User Not Exists");
            }

            CustomPricipalSerialize serialize = new CustomPricipalSerialize
            {
                Id=loginUser.Id,
                UserName = loginUser.UserName,
                Email = loginUser.Email,
                Roles = loginUser.Roles.Select(x => x.Name).ToArray()
            };

            JavaScriptSerializer serializer = new JavaScriptSerializer();

            string userData = serializer.Serialize(serialize);

            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(2, loginUser.UserName, DateTime.Now, DateTime.Now.AddMinutes(30), false, userData);

            string encryptTicket = FormsAuthentication.Encrypt(authTicket);

            HttpCookie myCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptTicket)
            {
                HttpOnly = true,
                Secure = false,
                Expires = DateTime.Now.AddMinutes(30)
            };

            Response.Cookies.Add(myCookie);


            return RedirectToAction("Index", "Home");
            
        }
        
        
    }
}