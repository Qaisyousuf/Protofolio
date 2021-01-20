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
    public class WorkQualitySectionController : Controller
    {
        private readonly IUnitOfWork uow;

        public WorkQualitySectionController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetWorkQualitySection()
        {
            var workQuality = uow.WorkQualitySectionRepository.GetAll();

            List<WorkQualitySectionViewModel> viewmodel = new List<WorkQualitySectionViewModel>();

            foreach (var item in workQuality)
            {
                viewmodel.Add(new WorkQualitySectionViewModel
                {
                    Id=item.Id,
                    Title=item.Title,
                    Content=item.Content,
                    ImageUrl=item.ImageUrl,
                    ButtonText=item.ButtonText,
                    ModalTitle=item.ModalTitle,
                    ModalsContent=item.ModalsContent

                });
            }
            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {

            return View(new WorkQualitySectionViewModel());
        }

        [HttpPost]
        public JsonResult Create(WorkQualitySectionViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {
                WorkQualitySection workQuality = new WorkQualitySection
                {
                    Id = viewmodel.Id,
                    Title = viewmodel.Title,
                    Content = viewmodel.Content,
                    ImageUrl = viewmodel.ImageUrl,
                    ButtonText = viewmodel.ButtonText,
                    ModalTitle = viewmodel.ModalTitle,
                    ModalsContent = viewmodel.ModalsContent,


                };
                uow.WorkQualitySectionRepository.Add(workQuality);
                uow.Commit();
            }
            
            return Json(new { success = true, message = "Record Saved Successfully" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var workQuality = uow.WorkQualitySectionRepository.GetById(id);

            WorkQualitySectionViewModel viewmodel = new WorkQualitySectionViewModel
            {
                Id=workQuality.Id,
                Title=workQuality.Title,
                Content=workQuality.Content,
                ImageUrl=workQuality.ImageUrl,
                ButtonText=workQuality.ButtonText,
                ModalTitle=workQuality.ModalTitle,
                ModalsContent=workQuality.ModalsContent

            };
            return View(viewmodel);
        }
        [HttpPost]
        public ActionResult Edit(WorkQualitySectionViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var workQuality = uow.WorkQualitySectionRepository.GetById(viewmodel.Id);

                workQuality.Id = viewmodel.Id;
                workQuality.Title = viewmodel.Title;
                workQuality.Content = viewmodel.Content;
                workQuality.ImageUrl = viewmodel.ImageUrl;
                workQuality.ButtonText = viewmodel.ButtonText;
                workQuality.ModalTitle = viewmodel.ModalTitle;
                workQuality.ModalsContent = viewmodel.ModalsContent;


                uow.WorkQualitySectionRepository.Update(workQuality);
                uow.Commit();
                
            }
            return Json(new { success = true, message = "Record Updated Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var workQuality = uow.WorkQualitySectionRepository.GetById(id);

            WorkQualitySectionViewModel viewmodel = new WorkQualitySectionViewModel
            {
                Id=workQuality.Id,
                Title=workQuality.Title,
                Content=workQuality.Content,
                ImageUrl=workQuality.ImageUrl,
                ButtonText=workQuality.ButtonText,
                ModalTitle=workQuality.ModalTitle,
                ModalsContent=workQuality.ModalsContent,
            };

            uow.WorkQualitySectionRepository.Remove(workQuality);
            uow.Commit();

            return Json(new { success = true, message = "Record Deleted Successfuly" }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var workQuality = uow.WorkQualitySectionRepository.GetById(id);

            WorkQualitySectionViewModel viewmodel = new WorkQualitySectionViewModel
            {
                Id=workQuality.Id,
                Title=workQuality.Title,
                Content=workQuality.Content,
                ImageUrl=workQuality.ImageUrl,
                ButtonText=workQuality.ButtonText,
                ModalTitle=workQuality.ModalTitle,
                ModalsContent=workQuality.ModalsContent,
            };
            return View(viewmodel);
        }
    }
}