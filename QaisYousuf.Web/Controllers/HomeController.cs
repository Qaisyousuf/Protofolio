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
    public class HomeController : Controller
    {
        private readonly IUnitOfWork uow;

        public HomeController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        // GET: Home
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
                    Id = item.Id,
                    Title = item.Title,
                    SubTitle = item.SubTitle,
                    BackgroundImage = item.BackgroundImage,
                    SliderImagesUrl = item.SliderImagesUrl,
                    ButtonUrl = item.ButtonUrl,
                    ButtonText = item.ButtonText

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
            if (ModelState.IsValid)
            {
                HomeBanner homebanner = new HomeBanner
                {
                    Id = viewmodel.Id,
                    Title = viewmodel.Title,
                    SubTitle = viewmodel.SubTitle,
                    BackgroundImage = viewmodel.BackgroundImage,
                    SliderImagesUrl = viewmodel.SliderImagesUrl,
                    ButtonUrl = viewmodel.ButtonUrl,
                    ButtonText = viewmodel.ButtonText

                };
                uow.HomeBannerRepository.Add(homebanner);
                uow.Commit();

            }
            return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
        }
    }
}