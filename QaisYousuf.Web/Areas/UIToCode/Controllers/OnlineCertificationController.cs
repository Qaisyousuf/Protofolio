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
    public class OnlineCertificationController : Controller
    {
        private readonly IUnitOfWork uow;

        public OnlineCertificationController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetOnlineCertificationData()
        {
            var onlineCertification = uow.OnlineCertificationRepository.GetAll();

            List<OnlineCertificateViewModel> viewmodel = new List<OnlineCertificateViewModel>();

            foreach (var item in onlineCertification)
            {
                viewmodel.Add(new OnlineCertificateViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    ProgramName=item.ProgramName,
                    CourseLocation=item.CourseLocation,
                    IconUrl=item.IconUrl,
                    CourseDescription=item.CourseDescription,
                    ButtonText=item.ButtonText,
                    ButtonUrl=item.ButtonUrl,
                    FinishDate=item.FinishDate,
                });
               
            }
            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new OnlineCertificateViewModel());
        }

        [HttpPost]
        public ActionResult Create(OnlineCertificateViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                OnlineCertification onlineCertification = new OnlineCertification
                {
                    Id=viewmodel.Id,
                    MainTitle=viewmodel.MainTitle,
                    ProgramName=viewmodel.ProgramName,
                    CourseLocation=viewmodel.CourseLocation,
                    IconUrl=viewmodel.IconUrl,
                    CourseDescription=viewmodel.CourseDescription,
                    ButtonText=viewmodel.ButtonText,
                    ButtonUrl=viewmodel.ButtonUrl,
                    FinishDate=viewmodel.FinishDate,
                };

                uow.OnlineCertificationRepository.Add(onlineCertification);
                uow.Commit();
            }
            return Json(new { success = true, message = "Record Saved Successfully" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var onlineCertification = uow.OnlineCertificationRepository.GetById(id);

            OnlineCertificateViewModel viewmodel = new OnlineCertificateViewModel
            {
                Id=onlineCertification.Id,
                MainTitle=onlineCertification.MainTitle,
                ProgramName=onlineCertification.ProgramName,
                CourseLocation=onlineCertification.CourseLocation,
                IconUrl=onlineCertification.IconUrl,
                CourseDescription=onlineCertification.CourseDescription,
                ButtonText=onlineCertification.ButtonText,
                ButtonUrl=onlineCertification.ButtonUrl,
                FinishDate=onlineCertification.FinishDate,
                
            };
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(OnlineCertificateViewModel viewmodel)
        {
           if(ModelState.IsValid)
            {
                var onlineCertification = uow.OnlineCertificationRepository.GetById(viewmodel.Id);

                onlineCertification.Id = viewmodel.Id;
                onlineCertification.MainTitle = viewmodel.MainTitle;
                onlineCertification.ProgramName = viewmodel.ProgramName;
                onlineCertification.CourseLocation = viewmodel.CourseLocation;
                onlineCertification.IconUrl = viewmodel.IconUrl;
                onlineCertification.CourseDescription = viewmodel.CourseDescription;
                onlineCertification.ButtonText = viewmodel.ButtonText;
                onlineCertification.ButtonUrl = viewmodel.ButtonUrl;
                onlineCertification.FinishDate = viewmodel.FinishDate;

                uow.OnlineCertificationRepository.Update(onlineCertification);
                uow.Commit();
            }
            return Json(new { success = true, message = "Record Updated Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var onlineCertification = uow.OnlineCertificationRepository.GetById(id);

            OnlineCertificateViewModel viewmodel = new OnlineCertificateViewModel
            {
                Id=onlineCertification.Id,
                MainTitle=onlineCertification.MainTitle,
                ProgramName=onlineCertification.ProgramName,
                CourseLocation=onlineCertification.CourseLocation,
                IconUrl=onlineCertification.IconUrl,
                CourseDescription=onlineCertification.CourseDescription,
                ButtonText=onlineCertification.ButtonText,
                ButtonUrl=onlineCertification.ButtonUrl,
                FinishDate=onlineCertification.FinishDate,
            };

            uow.OnlineCertificationRepository.Remove(onlineCertification);
            uow.Commit();
            return Json(new { success = true, message = "Record Deleted Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var onlineCertification = uow.OnlineCertificationRepository.GetById(id);

            OnlineCertificateViewModel viewmodel = new OnlineCertificateViewModel
            {
                Id = onlineCertification.Id,
                MainTitle = onlineCertification.MainTitle,
                ProgramName = onlineCertification.ProgramName,
                CourseLocation = onlineCertification.CourseLocation,
                IconUrl = onlineCertification.IconUrl,
                CourseDescription = onlineCertification.CourseDescription,
                ButtonText = onlineCertification.ButtonText,
                ButtonUrl = onlineCertification.ButtonUrl,
                FinishDate = onlineCertification.FinishDate,
            };
            return View(viewmodel);
        }
    }
}