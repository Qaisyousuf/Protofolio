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
            var contactBanner = Uow.ContactBannerRepository.GetAll();

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

           

            ListOfContact AllListofContact = new ListOfContact
            {
                ListContactBannerViewmodel=viewmodel,
                
            };
            return PartialView(AllListofContact);
        }

        [HttpGet]
        [ChildActionOnly]
        
        public ActionResult GetContactDetails(string slug)
        {
            var contactDetails = Uow.ContactDetialsRepository.GetAll();

            List<ContactDetailsViewModel> detailsViewModel = new List<ContactDetailsViewModel>();

            foreach (var ContactItem in contactDetails)
            {
                var datatime = ContactItem.WorkingTime;
                var dateTimeOfWeek = ContactItem.WorkingDateTimeOfWeek;

                var TimeOfWeek = Convert.ToDateTime(dateTimeOfWeek.ToShortTimeString());
                var DateOfWeek = Convert.ToDateTime(dateTimeOfWeek.ToShortDateString());
                var time = Convert.ToDateTime(datatime.ToShortTimeString());
                var date = Convert.ToDateTime(datatime.ToShortDateString());
                detailsViewModel.Add(new ContactDetailsViewModel
                {
                    Id = ContactItem.Id,
                    Title = ContactItem.Title,
                    HomeAddress = ContactItem.HomeAddress,
                    CountryName=ContactItem.CountryName,
                    SaleEamil=ContactItem.SaleEamil,
                    Moible = ContactItem.Moible,
                    Email = ContactItem.Email,
                    WorkingTime = time,
                    WorkingData = date,
                    WorkingTimeofWeek=TimeOfWeek,
                    WrokingDateOfWeek=dateTimeOfWeek,

                });
            }

            ListOfContact ContactDetailslist = new ListOfContact
            {
                ListContactDetiailsViewModel=detailsViewModel
            };
            return PartialView(ContactDetailslist);
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetContactMatter()
        {
            var contactMatter = Uow.ContactMatterRepository.GetAll();

            List<ContactMattersViewModel> viewmodel = new List<ContactMattersViewModel>();

            foreach (var item in contactMatter)
            {
                viewmodel.Add(new ContactMattersViewModel
                {
                    Id=item.Id,
                    Title=item.Title,
                    Content=item.Content,
                    MapApi=item.MapApi,
                    ButtonText=item.ButtonText,
                    ImageUrl=item.ImageUrl,
                });
            }

            ListOfContact ContacMatterList = new ListOfContact
            {
                ListContactMatterViewModel=viewmodel
            };

            return PartialView(ContacMatterList);
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

                Uow.ContactFormRepository.Add(contactForm);
                Uow.Commit();
                TempData["Message"] = $"{contactForm.FullName}";
                return RedirectToAction(nameof(ThankYou));
                

               
            }
            return View(viewmodel);
        }

        [Route("ThankYou")]
        public ActionResult ThankYou()
        {
            return View(new ContactFormViewModel());
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