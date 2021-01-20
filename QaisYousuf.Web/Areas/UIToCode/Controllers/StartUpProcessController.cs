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
    [Authorize(Roles = "Supper Admin")]
    public class StartUpProcessController : Controller
    {
        private readonly IUnitOfWork uow;

        public StartUpProcessController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetStartUpProcess()
        {
            var starUpProcess = uow.StartUpProcessRepository.GetAll();

            List<StartUpProcessViewModel> viewmodel = new List<StartUpProcessViewModel>();

            foreach (var item in starUpProcess)
            {
                viewmodel.Add(new StartUpProcessViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    SubTitle=item.SubTitle,
                    ImageUrl=item.ImageUrl
                });
            }
            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new StartUpProcessViewModel());
        }

        [HttpPost]
        public ActionResult Create(StartUpProcessViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                StartUpProcess startUpProcess = new StartUpProcess
                {
                    Id=viewmodel.Id,
                    MainTitle=viewmodel.MainTitle,
                    SubTitle=viewmodel.SubTitle,
                    ImageUrl=viewmodel.ImageUrl
                };

                uow.StartUpProcessRepository.Add(startUpProcess);
                uow.Commit();
            }
            return Json(new { success = true, message = "Record Saved Successfully" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var startUpProcess = uow.StartUpProcessRepository.GetById(id);

            StartUpProcessViewModel viewmodel = new StartUpProcessViewModel
            {
                Id=startUpProcess.Id,
                MainTitle=startUpProcess.MainTitle,
                SubTitle=startUpProcess.SubTitle,
                ImageUrl=startUpProcess.ImageUrl,
            };
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(StartUpProcessViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var startUpProcess = uow.StartUpProcessRepository.GetById(viewmodel.Id);

                startUpProcess.Id = viewmodel.Id;
                startUpProcess.MainTitle = viewmodel.MainTitle;
                startUpProcess.SubTitle = viewmodel.SubTitle;
                startUpProcess.ImageUrl = viewmodel.ImageUrl;

                uow.StartUpProcessRepository.Update(startUpProcess);
                uow.Commit();

            }
            return Json(new { success = true, message = "Record Updated Successfuly" }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult Delete(int id)
        {
            var startUpProcess = uow.StartUpProcessRepository.GetById(id);

            StartUpProcessViewModel viewmodel = new StartUpProcessViewModel
            {
                Id=startUpProcess.Id,
                MainTitle=startUpProcess.MainTitle,
                SubTitle=startUpProcess.SubTitle,
                ImageUrl=startUpProcess.ImageUrl,
            };
            uow.StartUpProcessRepository.Remove(startUpProcess);
            uow.Commit();

            return Json(new { success = true, message = "Record Deleted Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var startUpProcess = uow.StartUpProcessRepository.GetById(id);

            StartUpProcessViewModel viewmodel = new StartUpProcessViewModel
            {
                Id=startUpProcess.Id,
                MainTitle=startUpProcess.MainTitle,
                SubTitle=startUpProcess.SubTitle,
                ImageUrl=startUpProcess.ImageUrl,
            };

            return View(viewmodel);
        }
    }
}