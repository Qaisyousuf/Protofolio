using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            return View(AllListofContact);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
    }
}