using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QaisYousuf.ViewModels;
using QaisYousuf.Data.Interfaces;
using QaisYousuf.Models;

namespace QaisYousuf.Web.Areas.UIToCode.Controllers
{
    [Authorize(Roles = "Supper Admin")]
    public class ContactBannerController : Controller
    {
        private readonly IUnitOfWork uow;

        public ContactBannerController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetContactBannerData()
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
                    ButtonText=item.ButtonText,
                    ButtonUrl=item.ButtonUrl,
                    ImageUrl=item.ImageUrl,
                });

            }
            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {

            return View(new ContactBannerViewModel());
        }

        [HttpPost]
        public ActionResult Create(ContactBannerViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                ContactBanner banner = new ContactBanner
                {
                    Id=viewmodel.Id,
                    MainTitle=viewmodel.MainTitle,
                    SubTitle=viewmodel.SubTitle,
                    ButtonUrl=viewmodel.ButtonUrl,
                    ButtonText=viewmodel.ButtonText,
                    ImageUrl=viewmodel.ImageUrl,
                };

                uow.ContactBannerRepository.Add(banner);
                uow.Commit();
            }
            return Json(new { success = true, message = "Record Saved Successfully" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var banner = uow.ContactBannerRepository.GetById(id);

            ContactBannerViewModel viewmodel = new ContactBannerViewModel
            {
                Id=banner.Id,
                MainTitle=banner.MainTitle,
                SubTitle=banner.SubTitle,
                ButtonUrl=banner.ButtonUrl,
                ButtonText=banner.ButtonText,
                ImageUrl=banner.ImageUrl,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(ContactBannerViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var banner = uow.ContactBannerRepository.GetById(viewmodel.Id);

                banner.Id = viewmodel.Id;
                banner.MainTitle = viewmodel.MainTitle;
                banner.SubTitle = viewmodel.SubTitle;
                banner.ButtonText = viewmodel.ButtonText;
                banner.ButtonUrl = viewmodel.ButtonUrl;
                banner.ImageUrl = viewmodel.ImageUrl;

                uow.ContactBannerRepository.Update(banner);
                uow.Commit();
            }
            return Json(new { success = true, message = "Record Updated Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var banner = uow.ContactBannerRepository.GetById(id);

            ContactBannerViewModel viewmodel = new ContactBannerViewModel
            {
                Id = banner.Id,
                MainTitle = banner.MainTitle,
                SubTitle=banner.SubTitle,
                ButtonText=banner.ButtonText,
                ButtonUrl=banner.ButtonUrl,
                ImageUrl=banner.ImageUrl,
            };
            uow.ContactBannerRepository.Remove(banner);
            uow.Commit();

            return Json(new { success = true, message = "Record Deleted Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var banner = uow.ContactBannerRepository.GetById(id);

            ContactBannerViewModel viewmodel = new ContactBannerViewModel
            {
                Id = banner.Id,
                MainTitle = banner.MainTitle,
                SubTitle = banner.SubTitle,
                ButtonText = banner.ButtonText,
                ButtonUrl = banner.ButtonUrl,
                ImageUrl = banner.ImageUrl,
            };
            return View(viewmodel);
        }
    }
}