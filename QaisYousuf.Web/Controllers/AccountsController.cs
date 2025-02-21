﻿using QaisYousuf.Services.Security;
using QaisYousuf.ViewModels;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;
using QaisYousuf.Web.Infrastructure;

namespace QaisYousuf.Web.Controllers
{
   
    public class AccountsController : BaseController
    {
        [AdminActivityFilter]
        [UserActivityFilter]
        [Route("AuthrizationArea")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AdminActivityFilter]
        [UserActivityFilter]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction(nameof(Login));
        }

        [HttpGet]
        
        [Route("Authentication")]
        [AdminActivityFilter]
        [UserActivityFilter]
        public ActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        [Route("Authentication")]
        [AdminActivityFilter]
        [UserActivityFilter]
        public ActionResult Register(RegisterViewModel viewmodel)
        {
            if(!ModelState.IsValid)
            {
                return View(viewmodel);
            }

            bool registerSuccess = Authservices.Register(viewmodel.Email, viewmodel
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
        [Route("Authorization")]
        [AdminActivityFilter]
        [UserActivityFilter]
        public ActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        [AdminActivityFilter]
        [UserActivityFilter]
        [Route("Authorization")]
        public ActionResult Login(LoginViewModel viewmodel)
        {
            if(!ModelState.IsValid)
            {
                return View(viewmodel);
            }

            var loginUser = Authservices.Login(viewmodel.UserName, viewmodel.Password);
           
            if(loginUser==null)
            {
                ModelState.AddModelError("", "User Not Exists");
                return View(viewmodel);
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

            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(2, loginUser.UserName, DateTime.Now, DateTime.Now.AddMinutes(10), false, userData);

            string encryptTicket = FormsAuthentication.Encrypt(authTicket);

            HttpCookie myCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptTicket)
            {
                HttpOnly = true,
                Secure = false,
                Expires = DateTime.Now.AddMinutes(10),
                SameSite=SameSiteMode.Strict,
            };

            Response.Cookies.Add(myCookie);


            return RedirectToAction("Index", "Accounts", "AuthrizationArea");

        }
        
        
    }
}