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
    public class UIProcessController : Controller
    {
        private readonly IUnitOfWork uow;

        public UIProcessController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetUIPrcessData()
        {
            var UiProcess = uow.UIProcessRepository.GetAll();

            List<UIProcessViewModel> viewmodel = new List<UIProcessViewModel>();

            foreach (var item in UiProcess)
            {
                viewmodel.Add(new UIProcessViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    SubTitle=item.SubTitle,
                    Content=item.Content,
                    ImageUrl=item.ImageUrl,
                });
            }
            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new UIProcessViewModel());
        }

        [HttpPost]
        public ActionResult Create(UIProcessViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                UIProcess Uiprocess = new UIProcess
                {
                    Id=viewmodel.Id,
                    MainTitle=viewmodel.MainTitle,
                    SubTitle=viewmodel.SubTitle,
                    Content=viewmodel.Content,
                    ImageUrl=viewmodel.ImageUrl,
                };

                uow.UIProcessRepository.Add(Uiprocess);
                uow.Commit();
            }
            return Json(new { success = true, message = "Record Saved Successfully" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var UiProcess = uow.UIProcessRepository.GetById(id);

            UIProcessViewModel viewmodel = new UIProcessViewModel
            {
                Id=UiProcess.Id,
                MainTitle=UiProcess.MainTitle,
                SubTitle=UiProcess.SubTitle,
                Content=UiProcess.Content,
                ImageUrl=UiProcess.ImageUrl,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(UIProcessViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var Uiprocess = uow.UIProcessRepository.GetById(viewmodel.Id);

                Uiprocess.Id = viewmodel.Id;
                Uiprocess.MainTitle = viewmodel.MainTitle;
                Uiprocess.SubTitle = viewmodel.SubTitle;
                Uiprocess.Content = viewmodel.Content;
                Uiprocess.ImageUrl = viewmodel.ImageUrl;

                uow.UIProcessRepository.Update(Uiprocess); ;
                uow.Commit();
            }
            return Json(new { success = true, message = "Record Updated Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var Uiprocess = uow.UIProcessRepository.GetById(id);

            UIProcessViewModel viewmodel = new UIProcessViewModel
            {
                Id=Uiprocess.Id,
                MainTitle=Uiprocess.MainTitle,
                SubTitle=Uiprocess.SubTitle,
                Content=Uiprocess.Content,
                ImageUrl=Uiprocess.ImageUrl,

            };

            uow.UIProcessRepository.Remove(Uiprocess);
            uow.Commit();
            return Json(new { success = true, message = "Record Deleted Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var Uiprocess = uow.UIProcessRepository.GetById(id);

            UIProcessViewModel viewmodel = new UIProcessViewModel
            {
                Id = Uiprocess.Id,
                MainTitle = Uiprocess.MainTitle,
                SubTitle = Uiprocess.SubTitle,
                Content = Uiprocess.Content,
                ImageUrl = Uiprocess.ImageUrl,

            };

            return View(viewmodel);
        }
    }
}