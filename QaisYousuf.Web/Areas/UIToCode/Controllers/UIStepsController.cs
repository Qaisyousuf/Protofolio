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
    public class UIStepsController : Controller
    {
        private readonly IUnitOfWork uow;

        public UIStepsController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetUIStepsData()
        {
            var UiSteps = uow.UIUXStepsRepository.GetAll();

            List<UIStepsViewModel> viewmodel = new List<UIStepsViewModel>();

            foreach (var item in UiSteps)
            {
                viewmodel.Add(new UIStepsViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    Title=item.Title,
                    Content=item.Content,
                    ImageUrl=item.ImageUrl,
                });
            }

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View(new UIStepsViewModel());
        }
        
        [HttpPost]
        public ActionResult Create(UIStepsViewModel viewmodoel)
        {
            if(ModelState.IsValid)
            {
                UIUXSteps UiSteps = new UIUXSteps
                {
                    Id=viewmodoel.Id,
                    Title=viewmodoel.Title,
                    MainTitle=viewmodoel.MainTitle,
                    Content=viewmodoel.Content,
                    ImageUrl=viewmodoel.ImageUrl,
                };
                uow.UIUXStepsRepository.Add(UiSteps);
                uow.Commit();
            }
            return Json(new { success = true, message = "Record Saved Successfully" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var UiStepst = uow.UIUXStepsRepository.GetById(id);

            UIStepsViewModel viewmodel = new UIStepsViewModel
            {
                Id = UiStepst.Id,
                MainTitle = UiStepst.MainTitle,
                Title = UiStepst.Title,
                Content = UiStepst.Content,
                ImageUrl = UiStepst.ImageUrl,
            };
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(UIStepsViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var Uisteps = uow.UIUXStepsRepository.GetById(viewmodel.Id);

                Uisteps.Id = viewmodel.Id;
                Uisteps.MainTitle = viewmodel.MainTitle;
                Uisteps.Title = viewmodel.Title;
                Uisteps.Content = viewmodel.Content;
                Uisteps.ImageUrl = viewmodel.ImageUrl;

                uow.UIUXStepsRepository.Update(Uisteps);
                uow.Commit();
            }
            return Json(new { success = true, message = "Record Updated Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var UiSteps = uow.UIUXStepsRepository.GetById(id);

            UIStepsViewModel viewmodel = new UIStepsViewModel
            {
                Id=UiSteps.Id,
                Title=UiSteps.Title,
                MainTitle=UiSteps.MainTitle,
                Content=UiSteps.Content,
                ImageUrl=UiSteps.ImageUrl,
            };
            uow.UIUXStepsRepository.Remove(UiSteps);
            uow.Commit();
            return Json(new { success = true, message = "Record Deleted Successfuly" }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var UiSteps = uow.UIUXStepsRepository.GetById(id);

            UIStepsViewModel viewmodel = new UIStepsViewModel
            {
                Id = UiSteps.Id,
                Title = UiSteps.Title,
                MainTitle = UiSteps.MainTitle,
                Content = UiSteps.Content,
                ImageUrl = UiSteps.ImageUrl,
            };
            return View(viewmodel);
        }
    }
}