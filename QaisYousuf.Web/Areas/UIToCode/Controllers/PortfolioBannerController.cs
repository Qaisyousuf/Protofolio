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
    public class PortfolioBannerController : Controller
    {
        private readonly IUnitOfWork uow;

        public PortfolioBannerController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetPortfolioBannerData()
        {
            var portBanner = uow.PortfolioBannerRepository.GetAll();

            List<PortfolioBannerViewModel> viewmodel = new List<PortfolioBannerViewModel>();

            foreach (var item in portBanner)
            {
                viewmodel.Add(new PortfolioBannerViewModel
                {
                    Id=item.Id,
                    Title=item.Title,
                    SubTitle=item.SubTitle,
                    BackgroundImage=item.BackgroundImage,
                    SliderImagesUrl=item.SliderImagesUrl,
                    ButtonUrl=item.ButtonUrl,
                    ButtonText=item.ButtonText
                });
            }
            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new PortfolioBannerViewModel());
        }

        [HttpPost]
        public ActionResult Create(PortfolioBannerViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                PortfolioBanner portfolioBanner = new PortfolioBanner
                {
                    Id=viewmodel.Id,
                    Title=viewmodel.Title,
                    SubTitle=viewmodel.SubTitle,
                    BackgroundImage=viewmodel.BackgroundImage,
                    SliderImagesUrl=viewmodel.SliderImagesUrl,
                    ButtonUrl=viewmodel.ButtonUrl,
                    ButtonText=viewmodel.ButtonText,
                };

                uow.PortfolioBannerRepository.Add(portfolioBanner);
                uow.Commit();
            }
            return Json(new { success = true, message = "Record Saved Successfully" }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var portfolioBanner = uow.PortfolioBannerRepository.GetById(id);

            PortfolioBannerViewModel viewmodel = new PortfolioBannerViewModel
            {
                Id=portfolioBanner.Id,
                Title=portfolioBanner.Title,
                SubTitle=portfolioBanner.SubTitle,
                BackgroundImage=portfolioBanner.BackgroundImage,
                SliderImagesUrl=portfolioBanner.SliderImagesUrl,
                ButtonUrl=portfolioBanner.ButtonUrl,
                ButtonText=portfolioBanner.ButtonText,
            };
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(PortfolioBannerViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var portfolioBanner = uow.PortfolioBannerRepository.GetById(viewmodel.Id);

                portfolioBanner.Id = viewmodel.Id;
                portfolioBanner.Title = viewmodel.Title;
                portfolioBanner.SubTitle = viewmodel.SubTitle;
                portfolioBanner.BackgroundImage = viewmodel.BackgroundImage;
                portfolioBanner.SliderImagesUrl = viewmodel.SliderImagesUrl;
                portfolioBanner.ButtonText = viewmodel.ButtonText;
                portfolioBanner.ButtonUrl = viewmodel.ButtonUrl;

                uow.PortfolioBannerRepository.Update(portfolioBanner);
                uow.Commit();
            }
            return Json(new { success = true, message = "Record Updated Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult delete(int id)
        {
            var portfolioBanner = uow.PortfolioBannerRepository.GetById(id);

            PortfolioBannerViewModel viewmodel = new PortfolioBannerViewModel
            {
                Id=portfolioBanner.Id,
                Title=portfolioBanner.Title,
                SubTitle=portfolioBanner.SubTitle,
                BackgroundImage=portfolioBanner.BackgroundImage,
                SliderImagesUrl=portfolioBanner.SliderImagesUrl,
                ButtonUrl=portfolioBanner.ButtonUrl,
                ButtonText=portfolioBanner.ButtonText,
            };

            uow.PortfolioBannerRepository.Remove(portfolioBanner);
            uow.Commit();
            return Json(new { success = true, message = "Record Deleted Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var portfolioBanner = uow.PortfolioBannerRepository.GetById(id);

            PortfolioBannerViewModel viewmodel = new PortfolioBannerViewModel
            {
                Id = portfolioBanner.Id,
                Title = portfolioBanner.Title,
                SubTitle = portfolioBanner.SubTitle,
                BackgroundImage = portfolioBanner.BackgroundImage,
                SliderImagesUrl = portfolioBanner.SliderImagesUrl,
                ButtonUrl = portfolioBanner.ButtonUrl,
                ButtonText = portfolioBanner.ButtonText,
            };
            return View(viewmodel);
        }
    }
}