using QaisYousuf.Data.Interfaces;
using QaisYousuf.Models;
using QaisYousuf.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QaisYousuf.Web.Controllers
{
    public class ConnectionController : BaseController
    {
        private readonly IUnitOfWork uow;

        public ConnectionController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("ConnectUs")]
        public ActionResult Coneection()
        {
            return View(new ContactFormViewModel());
        }

        [HttpPost]
        [Route("ConnectUs")]
        public ActionResult Coneection(ContactFormViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {
                ContactForm contactForm = new ContactForm
                {
                    Id = viewmodel.Id,
                    FullName = viewmodel.FullName,
                    Email = viewmodel.Email,
                    Moible = viewmodel.Moible,
                    Message = viewmodel.Message,
                    IpAddress = GetIpAddres(HttpContext.Request),

                };

                Uow.ContactFormRepository.Add(contactForm);
                Uow.Commit();
                TempData["Success"] = $"{"Thanks" + contactForm.FullName + "for contacting us"}";

                return RedirectToAction(nameof(Coneection));


            }
            return View(viewmodel);
        }

      
        [NonAction]
        private string GetIpAddres(HttpRequestBase request)
        {
            string ipaddres;
            ipaddres = request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (ipaddres == "" || ipaddres == null)
            {
                ipaddres = request.ServerVariables["REMOTE_ADDR"];
            }
            return ipaddres;
        }


    }
}