using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QaisYousuf.ViewModels;
using QaisYousuf.Models;
using QaisYousuf.Data.Interfaces;

namespace QaisYousuf.Web.Areas.UIToCode.Controllers
{
    public class UIUXToolsController : Controller
    {
        private readonly IUnitOfWork uow;

        public UIUXToolsController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetUIUXData()
        {
            var UIUX = uow.UIUXToolsRepository.GetAll();

            List<UIUXToolsViewModel> viewmodel = new List<UIUXToolsViewModel>();

            foreach (var item in UIUX)
            {
                viewmodel.Add(new UIUXToolsViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    IconUrl=item.IconUrl,
                    ProgramTitle=item.ProgramTitle,
                    ImageUrl=item.ImageUrl
                });
            }
            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new UIUXToolsViewModel());
        }
        [HttpPost]
        public ActionResult Create(UIUXToolsViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                UI_UX_Tools uiuxTool = new UI_UX_Tools
                {
                    Id=viewmodel.Id,
                    MainTitle=viewmodel.MainTitle,
                    IconUrl=viewmodel.IconUrl,
                    ImageUrl=viewmodel.ImageUrl,
                    ProgramTitle=viewmodel.ProgramTitle,
                };

                uow.UIUXToolsRepository.Add(uiuxTool);
                uow.Commit();

            }
            return Json(new { success = true, message = "Record Saved Successfully" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var uiUxTools = uow.UIUXToolsRepository.GetById(id);

            UIUXToolsViewModel viewmodel = new UIUXToolsViewModel
            {
                Id=uiUxTools.Id,
                MainTitle=uiUxTools.MainTitle,
                IconUrl=uiUxTools.IconUrl,
                ImageUrl=uiUxTools.ImageUrl,
                ProgramTitle=uiUxTools.ProgramTitle,
            };

            return View(viewmodel);

        }

        [HttpPost]
        public ActionResult Edit(UIUXToolsViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var uiUxTools = uow.UIUXToolsRepository.GetById(viewmodel.Id);

                uiUxTools.Id = viewmodel.Id;
                uiUxTools.MainTitle = viewmodel.MainTitle;
                uiUxTools.IconUrl = viewmodel.IconUrl;
                uiUxTools.ImageUrl = viewmodel.ImageUrl;
                uiUxTools.ProgramTitle = viewmodel.ProgramTitle;

                uow.UIUXToolsRepository.Update(uiUxTools);
                uow.Commit();
            }
            return Json(new { success = true, message = "Record Updated Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var UiUxtools = uow.UIUXToolsRepository.GetById(id);

            UIUXToolsViewModel viewmodel = new UIUXToolsViewModel
            {
                Id=UiUxtools.Id,
                MainTitle=UiUxtools.MainTitle,
                IconUrl=UiUxtools.IconUrl,
                ImageUrl=UiUxtools.ImageUrl,
                ProgramTitle=UiUxtools.ProgramTitle,
            };

            uow.UIUXToolsRepository.Remove(UiUxtools);
            uow.Commit();

            return Json(new { success = true, message = "Record Deleted Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var uiUx = uow.UIUXToolsRepository.GetById(id);

            UIUXToolsViewModel viewmodel = new UIUXToolsViewModel
            {
                Id=uiUx.Id,
                MainTitle=uiUx.MainTitle,
                IconUrl=uiUx.IconUrl,
                ImageUrl=uiUx.ImageUrl,
                ProgramTitle=uiUx.ProgramTitle,
            };

            return View(viewmodel);
        }
    }
}