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
    public class UIBannerController : Controller
    {
        private readonly IUnitOfWork uow;

        public UIBannerController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetUIBannerData()
        {
            var UiBanner = uow.UIBannerRepository.GetAll();

            List<UIBannerViewModel> viewmodel = new List<UIBannerViewModel>();

            foreach (var item in UiBanner)
            {
                viewmodel.Add(new UIBannerViewModel
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
            return View(new UIBannerViewModel());
        }

        [HttpPost]
        public ActionResult Create(UIBannerViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                UIBanner UiBanner = new UIBanner
                {
                    Id=viewmodel.Id,
                    MainTitle=viewmodel.MainTitle,
                    SubTitle=viewmodel.SubTitle,
                    ButtonUrl=viewmodel.ButtonUrl,
                    ButtonText=viewmodel.ButtonText,
                    ImageUrl=viewmodel.ImageUrl,
                };

                uow.UIBannerRepository.Add(UiBanner);
                uow.Commit();
               }
            return Json(new { success = true, message = "Record Saved Successfully" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var Uibanner = uow.UIBannerRepository.GetById(id);

            UIBannerViewModel viewmodel = new UIBannerViewModel
            {
                Id=Uibanner.Id,
                MainTitle=Uibanner.MainTitle,
                SubTitle=Uibanner.SubTitle,
                ButtonUrl=Uibanner.ButtonUrl,
                ButtonText=Uibanner.ButtonText,
                ImageUrl=Uibanner.ImageUrl,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(UIBannerViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var Uibanner = uow.UIBannerRepository.GetById(viewmodel.Id);

                Uibanner.Id = viewmodel.Id;
                Uibanner.MainTitle = viewmodel.MainTitle;
                Uibanner.SubTitle = viewmodel.SubTitle;
                Uibanner.ButtonUrl = viewmodel.ButtonUrl;
                Uibanner.ButtonText = viewmodel.ButtonText;
                Uibanner.ImageUrl = viewmodel.ImageUrl;

                uow.UIBannerRepository.Update(Uibanner);
                uow.Commit();
            }
            return Json(new { success = true, message = "Record Updated Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var Uibanner = uow.UIBannerRepository.GetById(id);

            UIBannerViewModel viewmodel = new UIBannerViewModel
            {
                Id=Uibanner.Id,
                MainTitle=Uibanner.MainTitle,
                SubTitle=Uibanner.SubTitle,
                ButtonText=Uibanner.ButtonText,
                ButtonUrl=Uibanner.ButtonUrl,
                ImageUrl=Uibanner.ImageUrl,
            };

            uow.UIBannerRepository.Remove(Uibanner);
            uow.Commit();
            return Json(new { success = true, message = "Record Deleted Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var Uibanner = uow.UIBannerRepository.GetById(id);

            UIBannerViewModel viewmodel = new UIBannerViewModel
            {
                Id = Uibanner.Id,
                MainTitle = Uibanner.MainTitle,
                SubTitle = Uibanner.SubTitle,
                ButtonText = Uibanner.ButtonText,
                ButtonUrl = Uibanner.ButtonUrl,
                ImageUrl = Uibanner.ImageUrl,
            };
            return View(viewmodel);
        }
    }
}