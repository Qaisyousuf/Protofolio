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
    }
}