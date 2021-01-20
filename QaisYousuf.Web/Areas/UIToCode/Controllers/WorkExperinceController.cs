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
    public class WorkExperinceController : Controller
    {
        private readonly IUnitOfWork uow;

        public WorkExperinceController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetWorkExperienceData()
        {
            var workExp = uow.WorkExperienceRepository.GetAll();

            List<WorkExperienceViewModel> viewmodel = new List<WorkExperienceViewModel>();

            foreach (var item in workExp)
            {
                viewmodel.Add(new WorkExperienceViewModel
                {
                    Id=item.Id,
                    MainTitle=item.Maintitle,
                    JobTitle=item.JobTitle,
                    CompanyName=item.CompanyName,
                    CompanyLocation=item.CompanyLocation,
                    StartDate=item.StartDate,
                    EndDate=item.EndDate,
                    JobDesicription=item.JobDesicription,
                    LogoUrl=item.LogoUrl,
                    JobSubDescription=item.JobSubDescription,
                });
            }
            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new WorkExperienceViewModel());
        }

        [HttpPost]
        public ActionResult Create(WorkExperienceViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                WorkExperience workExperience = new WorkExperience
                {
                    Id=viewmodel.Id,
                    Maintitle=viewmodel.MainTitle,
                    JobTitle=viewmodel.JobTitle,
                    CompanyName=viewmodel.CompanyName,
                    CompanyLocation=viewmodel.CompanyLocation,
                    StartDate=viewmodel.StartDate,
                    EndDate=viewmodel.EndDate,
                    JobDesicription=viewmodel.JobDesicription,
                    JobSubDescription=viewmodel.JobSubDescription,
                    LogoUrl=viewmodel.LogoUrl,
                };

                uow.WorkExperienceRepository.Add(workExperience);
                uow.Commit();
            }
            return Json(new { success = true, message = "Record Saved Successfully" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var workExperience = uow.WorkExperienceRepository.GetById(id);

            WorkExperienceViewModel viewmodel = new WorkExperienceViewModel
            {
                Id=workExperience.Id,
                MainTitle=workExperience.Maintitle,
                JobTitle=workExperience.JobTitle,
                CompanyName=workExperience.CompanyName,
                CompanyLocation=workExperience.CompanyLocation,
                StartDate=workExperience.StartDate,
                EndDate=workExperience.EndDate,
                JobDesicription=workExperience.JobDesicription,
                JobSubDescription=workExperience.JobSubDescription,
                LogoUrl=workExperience.LogoUrl,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(WorkExperienceViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var workExperience = uow.WorkExperienceRepository.GetById(viewmodel.Id);
                workExperience.Id = viewmodel.Id;
                workExperience.Maintitle = viewmodel.MainTitle;
                workExperience.JobTitle = viewmodel.JobTitle;
                workExperience.CompanyName = viewmodel.CompanyName;
                workExperience.CompanyLocation = viewmodel.CompanyLocation;
                workExperience.StartDate = viewmodel.StartDate;
                workExperience.EndDate = viewmodel.EndDate;
                workExperience.JobDesicription = viewmodel.JobDesicription;
                workExperience.JobSubDescription = viewmodel.JobSubDescription;
                workExperience.LogoUrl = viewmodel.LogoUrl;
                uow.WorkExperienceRepository.Update(workExperience);
                uow.Commit();
            }
            return Json(new { success = true, message = "Record Updated Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var workExperience = uow.WorkExperienceRepository.GetById(id);

            WorkExperienceViewModel viewmodel = new WorkExperienceViewModel
            {
                Id=workExperience.Id,
                MainTitle=workExperience.Maintitle,
                JobTitle=workExperience.JobTitle,
                CompanyName=workExperience.CompanyName,
                CompanyLocation=workExperience.CompanyLocation,
                StartDate=workExperience.StartDate,
                EndDate=workExperience.EndDate,
                JobDesicription=workExperience.JobDesicription,
                JobSubDescription=workExperience.JobSubDescription,
                LogoUrl=workExperience.LogoUrl,
            };

            uow.WorkExperienceRepository.Remove(workExperience);
            uow.Commit();

            return Json(new { success = true, message = "Record Deleted Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var workExperience = uow.WorkExperienceRepository.GetById(id);

            WorkExperienceViewModel viewmodel = new WorkExperienceViewModel
            {
                Id = workExperience.Id,
                MainTitle = workExperience.Maintitle,
                JobTitle = workExperience.JobTitle,
                CompanyName = workExperience.CompanyName,
                CompanyLocation = workExperience.CompanyLocation,
                StartDate = workExperience.StartDate,
                EndDate = workExperience.EndDate,
                JobDesicription = workExperience.JobDesicription,
                JobSubDescription = workExperience.JobSubDescription,
                LogoUrl = workExperience.LogoUrl,
            };

            return View(viewmodel);
        }
    }
}