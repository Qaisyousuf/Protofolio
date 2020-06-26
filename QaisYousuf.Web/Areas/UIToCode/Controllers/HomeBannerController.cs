using QaisYousuf.Data.Interfaces;
using QaisYousuf.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QaisYousuf.Models;

namespace QaisYousuf.Web.Areas.UIToCode.Controllers
{
    public class HomeBannerController : Controller
    {
        private readonly IUnitOfWork uow;

        public HomeBannerController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetHomeBanner()
        {
            var banner = uow.HomeBannerRepository.GetAll();


            List<HomeBannerViewModel> viewmodel = new List<HomeBannerViewModel>();

            foreach (var item in banner)
            {
                viewmodel.Add(new HomeBannerViewModel
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
            return View(new HomeBannerViewModel());
        }

        [HttpPost]
        public JsonResult Create(HomeBannerViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                HomeBanner homebanner = new HomeBanner
                {
                    Id=viewmodel.Id,
                    Title=viewmodel.Title,
                    SubTitle=viewmodel.SubTitle,
                    BackgroundImage=viewmodel.BackgroundImage,
                    SliderImagesUrl=viewmodel.SliderImagesUrl,
                    ButtonUrl=viewmodel.ButtonUrl,
                    ButtonText=viewmodel.ButtonText

                };
                uow.HomeBannerRepository.Add(homebanner);
                uow.Commit();
                
            }
            return Json(new { success = true, message = "Record Saved Successfully" }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var homebanner = uow.HomeBannerRepository.GetById(id);

            HomeBannerViewModel viewmodel = new HomeBannerViewModel
            {
                Id=homebanner.Id,
                Title=homebanner.Title,
                SubTitle=homebanner.SubTitle,
                BackgroundImage=homebanner.BackgroundImage,
                SliderImagesUrl=homebanner.SliderImagesUrl,
                ButtonUrl=homebanner.ButtonUrl,
                ButtonText=homebanner.ButtonText
            };
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(HomeBannerViewModel viewmodel)
        {
          if(ModelState.IsValid)
            {
                var homebanner = uow.HomeBannerRepository.GetById(viewmodel.Id);

                homebanner.Id = viewmodel.Id;
                homebanner.Title = viewmodel.Title;
                homebanner.SubTitle = viewmodel.SubTitle;
                homebanner.BackgroundImage = viewmodel.BackgroundImage;
                homebanner.SliderImagesUrl = viewmodel.SliderImagesUrl;
                homebanner.ButtonUrl = viewmodel.ButtonUrl;
                homebanner.ButtonText = viewmodel.ButtonText;

                uow.HomeBannerRepository.Update(homebanner);
                uow.Commit();
               
               
          }
            return Json(new { success = true, message = "Record Updated Successfuly" }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var homebanner = uow.HomeBannerRepository.GetById(id);

            HomeBannerViewModel viewmodel = new HomeBannerViewModel
            {
                Id=homebanner.Id,
                Title=homebanner.Title,
                SubTitle=homebanner.SubTitle,
                BackgroundImage=homebanner.BackgroundImage,
                SliderImagesUrl=homebanner.SliderImagesUrl,
                ButtonUrl=homebanner.ButtonUrl,
                ButtonText=homebanner.ButtonText
            };
            uow.HomeBannerRepository.Remove(homebanner);
            uow.Commit();

            return Json(new { success = true, message = "Record Deleted Successfuly" }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var homebanner = uow.HomeBannerRepository.GetById(id);

            HomeBannerViewModel viewmodel = new HomeBannerViewModel
            {
                Id=homebanner.Id,
                Title=homebanner.Title,
                SubTitle=homebanner.SubTitle,
                BackgroundImage=homebanner.BackgroundImage,
                SliderImagesUrl=homebanner.SliderImagesUrl,
                ButtonUrl=homebanner.ButtonUrl,
                ButtonText=homebanner.ButtonText
            };
            return View(viewmodel);
           
        }

    }
}