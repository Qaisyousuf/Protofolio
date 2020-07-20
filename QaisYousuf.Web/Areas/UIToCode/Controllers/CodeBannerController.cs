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
    public class CodeBannerController : Controller
    {
        private readonly IUnitOfWork uow;

        public CodeBannerController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetCodeBanner()
        {
            var codeBanner = uow.CodeBannerRepository.GetAll();

            List<CodeBannerViewModel> viewmodel = new List<CodeBannerViewModel>();

            foreach (var item in codeBanner)
            {
                viewmodel.Add(new CodeBannerViewModel
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
            return View(new CodeBannerViewModel());
        }

        [HttpPost]
        public ActionResult Create(CodeBannerViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                CodeBanner codeBanner = new CodeBanner
                {
                    Id=viewmodel.Id,
                    MainTitle=viewmodel.MainTitle,
                    SubTitle=viewmodel.SubTitle,
                    ButtonUrl=viewmodel.ButtonUrl,
                    ButtonText=viewmodel.ButtonText,
                    ImageUrl=viewmodel.ImageUrl,
                };
                uow.CodeBannerRepository.Add(codeBanner);
                uow.Commit();
            }
            return Json(new { success = true, message = "Record Saved Successfully" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var codeBanner = uow.CodeBannerRepository.GetById(id);

            CodeBannerViewModel viewmodel = new CodeBannerViewModel
            {
                Id=codeBanner.Id,
                MainTitle=codeBanner.MainTitle,
                SubTitle=codeBanner.SubTitle,
                ButtonUrl=codeBanner.ButtonUrl,
                ButtonText=codeBanner.ButtonText,
                ImageUrl=codeBanner.ImageUrl,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(CodeBannerViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var codeBanner = uow.CodeBannerRepository.GetById(viewmodel.Id);

                codeBanner.Id = viewmodel.Id;
                codeBanner.MainTitle = viewmodel.MainTitle;
                codeBanner.SubTitle = viewmodel.SubTitle;
                codeBanner.ButtonUrl = viewmodel.ButtonUrl;
                codeBanner.ButtonText = viewmodel.ButtonText;
                codeBanner.ImageUrl = viewmodel.ImageUrl;

                uow.CodeBannerRepository.Update(codeBanner);
                uow.Commit();
            }
            return Json(new { success = true, message = "Record Updated Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var codeBanner = uow.CodeBannerRepository.GetById(id);

            CodeBannerViewModel viewmodel = new CodeBannerViewModel
            {
                Id=codeBanner.Id,
                MainTitle=codeBanner.MainTitle,
                SubTitle=codeBanner.SubTitle,
                ButtonUrl=codeBanner.ButtonUrl,
                ButtonText=codeBanner.ButtonText,
                ImageUrl=codeBanner.ImageUrl,
            };

            uow.CodeBannerRepository.Remove(codeBanner);
            uow.Commit();

            return Json(new { success = true, message = "Record Deleted Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var codeBanner = uow.CodeBannerRepository.GetById(id);

            CodeBannerViewModel viewmodel = new CodeBannerViewModel
            {
                Id=codeBanner.Id,
                MainTitle=codeBanner.MainTitle,
                SubTitle=codeBanner.SubTitle,
                ButtonText=codeBanner.ButtonText,
                ButtonUrl=codeBanner.ButtonUrl,
                ImageUrl=codeBanner.ImageUrl,
            };

            return View(viewmodel);
        }
    }
}