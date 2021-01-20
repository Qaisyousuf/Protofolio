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
    public class WebProgrammingToolsController : Controller
    {
        private readonly IUnitOfWork uow;

        public WebProgrammingToolsController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetWebProgrammingData()
        {
            var webPro = uow.WebProgrammingToolsRepository.GetAll();

            List<WebProgrammingToolsViewModel> viewmodel = new List<WebProgrammingToolsViewModel>();

            foreach (var item in webPro)
            {
                viewmodel.Add(new WebProgrammingToolsViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    ImageUrl=item.ImageUrl,
                    IconUrl=item.IconUrl,
                    ProgramTitle=item.ProgramTitle,
                });
            }
            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new WebProgrammingToolsViewModel());
        }

        [HttpPost]
        public ActionResult Create(WebProgrammingToolsViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                WebProgrammingTools webPro = new WebProgrammingTools
                {
                    Id=viewmodel.Id,
                    MainTitle=viewmodel.MainTitle,
                    ImageUrl=viewmodel.ImageUrl,
                    IconUrl=viewmodel.IconUrl,
                    ProgramTitle=viewmodel.ProgramTitle,
                };

                uow.WebProgrammingToolsRepository.Add(webPro);
                uow.Commit();
            }
            return Json(new { success = true, message = "Record Saved Successfully" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var webPro = uow.WebProgrammingToolsRepository.GetById(id);

            WebProgrammingToolsViewModel viewmodel = new WebProgrammingToolsViewModel
            {
                Id=webPro.Id,
                MainTitle=webPro.MainTitle,
                ImageUrl=webPro.ImageUrl,
                IconUrl=webPro.IconUrl,
                ProgramTitle=webPro.ProgramTitle,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(WebProgrammingToolsViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var webPro = uow.WebProgrammingToolsRepository.GetById(viewmodel.Id);

                webPro.Id = viewmodel.Id;
                webPro.MainTitle = viewmodel.MainTitle;
                webPro.IconUrl = viewmodel.IconUrl;
                webPro.ImageUrl = viewmodel.ImageUrl;
                webPro.ProgramTitle = viewmodel.ProgramTitle;

                uow.WebProgrammingToolsRepository.Update(webPro);
                uow.Commit();
            }
            return Json(new { success = true, message = "Record Updated Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var webPro = uow.WebProgrammingToolsRepository.GetById(id);

            WebProgrammingToolsViewModel viewmodel = new WebProgrammingToolsViewModel
            {
                Id=webPro.Id,
                MainTitle=webPro.MainTitle,
                ImageUrl=webPro.ImageUrl,
                IconUrl=webPro.IconUrl,
                ProgramTitle=webPro.ProgramTitle,
            };

            uow.WebProgrammingToolsRepository.Remove(webPro);
            uow.Commit();

            return Json(new { success = true, message = "Record Deleted Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var webPro = uow.WebProgrammingToolsRepository.GetById(id);

            WebProgrammingToolsViewModel viewmodel = new WebProgrammingToolsViewModel
            {
                Id=webPro.Id,
                MainTitle=webPro.MainTitle,
                ImageUrl=webPro.ImageUrl,
                IconUrl=webPro.IconUrl,
                ProgramTitle=webPro.ProgramTitle,
            };

            return View(viewmodel);
        }
    }
}