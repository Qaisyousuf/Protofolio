using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QaisYousuf.Models;
using QaisYousuf.ViewModels;

namespace QaisYousuf.Web.Controllers
{
    public class ContactController : BaseController
    {
        [Route("ContactUs")]
        public ActionResult Index(string slug)
        {
            var contactBanner = uow.ContactBannerRepository.GetAll();

            List<ContactBannerViewModel> viewmodel = new List<ContactBannerViewModel>();


            foreach (var item in contactBanner)
            {
                viewmodel.Add(new ContactBannerViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    SubTitle=item.SubTitle,
                    ButtonUrl=item.ButtonUrl,
                    ButtonText=item.ButtonText,
                    ImageUrl=item.ImageUrl,
                });
            }

            var contactDetails = uow.ContactDetialsRepository.GetAll();

            List<ContactDetailsViewModel> detailsViewModel = new List<ContactDetailsViewModel>();

            foreach (var ContactItem in contactDetails)
            {
                detailsViewModel.Add(new ContactDetailsViewModel
                {
                    Id=ContactItem.Id,
                    Title=ContactItem.Title,
                    HomeAddress=ContactItem.HomeAddress,
                    Moible=ContactItem.Moible,
                    Email=ContactItem.Email,
                    WorkingTime=ContactItem.WorkingTime,
                    WorkingData=ContactItem.WorkingTime,

                });
            }

            ListOfContact AllListofContact = new ListOfContact
            {
                ListContactBannerViewmodel=viewmodel,
                ListContactDetiailsViewModel=detailsViewModel,
            };
            return PartialView(AllListofContact);
        }

        [HttpGet]
        [Route("ContactUs")]
        public ActionResult Create()
        {
            return View(new ContactFormViewModel());
        }

        [HttpPost]
        [Route("ContactUs")]
        public ActionResult Create(ContactFormViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                ContactForm contactForm = new ContactForm
                {
                    Id=viewmodel.Id,
                    FullName=viewmodel.FullName,
                    Email=viewmodel.Email,
                    Moible=viewmodel.Moible,
                    Message=viewmodel.Message,
                    IpAddress= GetIpAddres(HttpContext.Request),

                };

                uow.ContactFormRepository.Add(contactForm);
                uow.Commit();
                return View(viewmodel);

               
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