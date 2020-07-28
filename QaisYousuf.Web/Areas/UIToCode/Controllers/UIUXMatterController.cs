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
    public class UIUXMatterController : Controller
    {
        private readonly IUnitOfWork uow;

        public UIUXMatterController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetUIUXMatterData()
        {
            var UiUXMatter = uow.UIUXMatterSectionRepository.GetAll();

            List<UIUXMatterViewModel> viewmodel = new List<UIUXMatterViewModel>();

            foreach (var item in UiUXMatter)
            {
                viewmodel.Add(new UIUXMatterViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    Content=item.Content,
                    ImageUrl=item.ImageUrl,
                });
            }
            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new UIUXMatterViewModel());
        }

        [HttpPost]
        public ActionResult Create(UIUXMatterViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                UIUXMatterSection UIMatter = new UIUXMatterSection
                {
                    
                    Id=viewmodel.Id,
                    MainTitle=viewmodel.MainTitle,
                    Content=viewmodel.Content,
                    ImageUrl=viewmodel.ImageUrl,
                };

                uow.UIUXMatterSectionRepository.Add(UIMatter);
                uow.Commit();
            }
            return Json(new { success = true, message = "Record Saved Successfully" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var Uimatter = uow.UIUXMatterSectionRepository.GetById(id);

            UIUXMatterViewModel viewmodel = new UIUXMatterViewModel
            {
                Id=Uimatter.Id,
                MainTitle=Uimatter.MainTitle,
                Content=Uimatter.Content,
                ImageUrl=Uimatter.ImageUrl,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(UIUXMatterViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var Uimatter = uow.UIUXMatterSectionRepository.GetById(viewmodel.Id);


                Uimatter.Id = viewmodel.Id;
                Uimatter.MainTitle = viewmodel.MainTitle;
                Uimatter.Content = viewmodel.Content;
                Uimatter.ImageUrl = viewmodel.ImageUrl;

                uow.UIUXMatterSectionRepository.Update(Uimatter);
                uow.Commit();
            }

            return Json(new { success = true, message = "Record Updated Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var Uimatter = uow.UIUXMatterSectionRepository.GetById(id);

            UIUXMatterViewModel viewmodel = new UIUXMatterViewModel
            {
                Id=Uimatter.Id,
                MainTitle=Uimatter.MainTitle,
                Content=Uimatter.Content,
                ImageUrl=Uimatter.ImageUrl,
            };

            uow.UIUXMatterSectionRepository.Remove(Uimatter);
            uow.Commit();

            return Json(new { success = true, message = "Record Deleted Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var Uimatter = uow.UIUXMatterSectionRepository.GetById(id);

            UIUXMatterViewModel viewmodel = new UIUXMatterViewModel
            {
                Id = Uimatter.Id,
                MainTitle = Uimatter.MainTitle,
                Content = Uimatter.Content,
                ImageUrl = Uimatter.ImageUrl,
            };
            return View(viewmodel);
        }
    }
}