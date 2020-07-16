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
    public class StartUpProgramController : Controller
    {
        private readonly IUnitOfWork uow;

        public StartUpProgramController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetStartUpProgramData()
        {
            var startUp = uow.StartUpProgramRepository.GetAll();

            List<StartUpProgramViewModel> viewmodel = new List<StartUpProgramViewModel>();

            foreach (var item in startUp)
            {
                viewmodel.Add(new StartUpProgramViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    Content=item.Content,
                    ButtonText=item.ButtonText,
                    ButtonUrl=item.ButtonUrl,
                    SubTitle=item.SubTitle,
                    ImageUrl=item.ImageUrl,
                });
            }
            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new StartUpProgramViewModel());
        }

        [HttpPost]
        public ActionResult Create(StartUpProgramViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                StartUpProgram startUp = new StartUpProgram
                {
                    Id=viewmodel.Id,
                    MainTitle=viewmodel.MainTitle,
                    Content=viewmodel.Content,
                    ButtonText=viewmodel.ButtonText,
                    ButtonUrl=viewmodel.ButtonUrl,
                    SubTitle=viewmodel.SubTitle,
                    ImageUrl=viewmodel.ImageUrl,
                };
                uow.StartUpProgramRepository.Add(startUp);
                uow.Commit();
            }
            return Json(new { success = true, message = "Record Saved Successfully" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var startUp = uow.StartUpProgramRepository.GetById(id);

            StartUpProgramViewModel viewmodel = new StartUpProgramViewModel
            {
                Id=startUp.Id,
                MainTitle=startUp.MainTitle,
                Content=startUp.Content,
                ButtonText=startUp.ButtonText,
                ButtonUrl=startUp.ButtonUrl,
                SubTitle=startUp.SubTitle,
                ImageUrl=startUp.ImageUrl
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(StartUpProgramViewModel viewmodel)
        {
           if(ModelState.IsValid)
            {
                var starUp = uow.StartUpProgramRepository.GetById(viewmodel.Id);

                starUp.Id = viewmodel.Id;
                starUp.MainTitle = viewmodel.MainTitle;
                starUp.Content = viewmodel.Content;
                starUp.ButtonText = viewmodel.ButtonText;
                starUp.ButtonUrl = viewmodel.ButtonUrl;
                starUp.SubTitle = viewmodel.SubTitle;
                starUp.ImageUrl = viewmodel.ImageUrl;

                uow.StartUpProgramRepository.Update(starUp);
                uow.Commit();
            }
            return Json(new { success = true, message = "Record Updated Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var startUp = uow.StartUpProgramRepository.GetById(id);

            StartUpProgramViewModel viewmodel = new StartUpProgramViewModel
            {
                Id=startUp.Id,
                MainTitle=startUp.MainTitle,
                Content=startUp.Content,
                ButtonText=startUp.ButtonText,
                ButtonUrl=startUp.ButtonUrl,
                SubTitle=startUp.SubTitle,
                ImageUrl=startUp.ImageUrl,
            };

            uow.StartUpProgramRepository.Remove(startUp);
            uow.Commit();
            return Json(new { success = true, message = "Record Deleted Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var starUp = uow.StartUpProgramRepository.GetById(id);

            StartUpProgramViewModel viewmodel = new StartUpProgramViewModel
            {
                Id=starUp.Id,
                MainTitle=starUp.MainTitle,
                Content=starUp.Content,
                ButtonText=starUp.ButtonText,
                ButtonUrl=starUp.ButtonUrl,
                SubTitle=starUp.SubTitle,
                ImageUrl=starUp.ImageUrl
            };
            return View(viewmodel);
        }

    }
}