using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QaisYousuf.ViewModels;
using QaisYousuf.Models;
using QaisYousuf.Data.Interfaces;
using QaisYousuf.Web.Infrastructure;

namespace QaisYousuf.Web.Areas.UIToCode.Controllers
{
    [Authorize(Roles ="admin")]
    public class AboutBannerController : Controller
    {
        private readonly IUnitOfWork uow;

        public AboutBannerController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAboutBanner()
        {
            var aboutBanner = uow.AboutPageBannerRepository.GetAll();

            List<AboutBannerViewModel> viewmodel = new List<AboutBannerViewModel>();

            foreach (var item in aboutBanner)
            {
                viewmodel.Add(new AboutBannerViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    SubTitle=item.SubTitle,
                    ButtonUrl=item.ButtonUrl,
                    ButtonText=item.ButtonText,
                    ImageUrl=item.ImageUrl,
                });
            }
            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            int value = int.Parse("hello");
            return View(new AboutBannerViewModel());
        }

        [HttpPost]
        public ActionResult Create(AboutBannerViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                AboutPageBanner aboutBanner = new AboutPageBanner
                {
                    Id=viewmodel.Id,
                    MainTitle=viewmodel.MainTitle,
                    SubTitle=viewmodel.SubTitle,
                    ButtonUrl=viewmodel.ButtonUrl,
                    ButtonText=viewmodel.ButtonText,
                    ImageUrl=viewmodel.ImageUrl,
                };

                uow.AboutPageBannerRepository.Add(aboutBanner);
                uow.Commit();
            }
            return Json(new { success = true, message = "Record Saved Successfully" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var aboutBanner = uow.AboutPageBannerRepository.GetById(id);

            AboutBannerViewModel viewmodel = new AboutBannerViewModel
            {
                Id=aboutBanner.Id,
                MainTitle=aboutBanner.MainTitle,
                SubTitle=aboutBanner.SubTitle,
                ButtonUrl=aboutBanner.ButtonUrl,
                ButtonText=aboutBanner.ButtonText,
                ImageUrl=aboutBanner.ImageUrl
            };
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(AboutBannerViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var aboutBanner = uow.AboutPageBannerRepository.GetById(viewmodel.Id);

                aboutBanner.Id = viewmodel.Id;
                aboutBanner.MainTitle = viewmodel.MainTitle;
                aboutBanner.SubTitle = viewmodel.SubTitle;
                aboutBanner.ButtonUrl = viewmodel.ButtonUrl;
                aboutBanner.ButtonText = viewmodel.ButtonText;
                aboutBanner.ImageUrl = viewmodel.ImageUrl;

                uow.AboutPageBannerRepository.Update(aboutBanner);
                uow.Commit();
            }

            return Json(new { success = true, message = "Record Updated Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var aboutBanner = uow.AboutPageBannerRepository.GetById(id);

            AboutBannerViewModel viewmodel = new AboutBannerViewModel
            {
                Id=aboutBanner.Id,
                MainTitle=aboutBanner.MainTitle,
                SubTitle=aboutBanner.SubTitle,
                ButtonUrl=aboutBanner.ButtonUrl,
                ButtonText=aboutBanner.ButtonText,
                ImageUrl=aboutBanner.ImageUrl,
            };

            uow.AboutPageBannerRepository.Remove(aboutBanner);
            uow.Commit();

            return Json(new { success = true, message = "Record Deleted Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var aboutBanner = uow.AboutPageBannerRepository.GetById(id);
            AboutBannerViewModel viewmodel = new AboutBannerViewModel
            {
                Id=aboutBanner.Id,
                MainTitle=aboutBanner.MainTitle,
                SubTitle=aboutBanner.SubTitle,
                ButtonUrl=aboutBanner.ButtonUrl,
                ButtonText=aboutBanner.ButtonText,
                ImageUrl=aboutBanner.ImageUrl,
            };

            return View(viewmodel);
        }
    }
}