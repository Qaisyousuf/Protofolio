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
    public class ProjectCountingController : Controller
    {
        private readonly IUnitOfWork uow;

        public ProjectCountingController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetProjectCountingData()
        {
            var projectCounting = uow.ProjectCountingRepository.GetAll();

            List<ProjectCountingViewModel> viewmodel = new List<ProjectCountingViewModel>();

            foreach (var item in projectCounting)
            {
                viewmodel.Add(new ProjectCountingViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    SubTitle=item.SubTitle,
                    ImageUrl=item.ImageUrl,
                    Title=item.Title,
                    CountingNumber=item.CountingNumber
                });
            }
            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new ProjectCountingViewModel());
        }

        [HttpPost]
        public JsonResult Create(ProjectCountingViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                ProjectCounting projectCounting = new ProjectCounting
                {
                    Id=viewmodel.Id,
                    MainTitle=viewmodel.MainTitle,
                    SubTitle=viewmodel.SubTitle,
                    ImageUrl=viewmodel.ImageUrl,
                    Title=viewmodel.Title,
                    CountingNumber=viewmodel.CountingNumber
                };

                uow.ProjectCountingRepository.Add(projectCounting);
                uow.Commit();
            }
            return Json(new { success = true, message = "Record Saved Successfully" }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var projectCounting = uow.ProjectCountingRepository.GetById(id);

            ProjectCountingViewModel viewmodel = new ProjectCountingViewModel
            {
                Id=projectCounting.Id,
                MainTitle=projectCounting.MainTitle,
                SubTitle=projectCounting.SubTitle,
                ImageUrl=projectCounting.ImageUrl,
                Title=projectCounting.Title,
                CountingNumber=projectCounting.CountingNumber
            };
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(ProjectCountingViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var projectCounting = uow.ProjectCountingRepository.GetById(viewmodel.Id);

                projectCounting.Id = viewmodel.Id;
                projectCounting.MainTitle = viewmodel.MainTitle;
                projectCounting.SubTitle = viewmodel.SubTitle;
                projectCounting.ImageUrl = viewmodel.ImageUrl;
                projectCounting.Title = viewmodel.Title;
                projectCounting.CountingNumber = viewmodel.CountingNumber;

                uow.ProjectCountingRepository.Update(projectCounting);
                uow.Commit();
            }
            return Json(new { success = true, message = "Record Updated Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var countingPorject = uow.ProjectCountingRepository.GetById(id);

            ProjectCountingViewModel viewmodel = new ProjectCountingViewModel
            {
                Id=countingPorject.Id,
                MainTitle=countingPorject.MainTitle,
                SubTitle=countingPorject.SubTitle,
                ImageUrl=countingPorject.ImageUrl,
                Title=countingPorject.Title,
                CountingNumber=countingPorject.CountingNumber,
            };
            uow.ProjectCountingRepository.Remove(countingPorject);
            uow.Commit();
            return Json(new { success = true, message = "Record Deleted Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var projectCouting = uow.ProjectCountingRepository.GetById(id);

            ProjectCountingViewModel viewmodel = new ProjectCountingViewModel
            {
                Id=projectCouting.Id,
                MainTitle=projectCouting.MainTitle,
                SubTitle=projectCouting.SubTitle,
                ImageUrl=projectCouting.ImageUrl,
                Title=projectCouting.Title,
                CountingNumber=projectCouting.CountingNumber
            };
            return View(viewmodel);
        }
    }
}