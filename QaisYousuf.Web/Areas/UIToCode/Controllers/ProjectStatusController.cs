using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QaisYousuf.Data.Interfaces;
using QaisYousuf.Models;
using QaisYousuf.ViewModels;

namespace QaisYousuf.Web.Areas.UIToCode.Controllers
{
    [Authorize(Roles = "Supper Admin")]
    public class ProjectStatusController : Controller
    {
        private readonly IUnitOfWork uow;

        public ProjectStatusController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetProjectStatusData()
        {
            var projectStatus = uow.ProjectStatusRepository.GetAll();

            List<ProjectStatusViewModel> viewmodel = new List<ProjectStatusViewModel>();

            foreach (var item in projectStatus)
            {
                viewmodel.Add(new ProjectStatusViewModel
                {
                    Id=item.Id,
                    ProjectStatusProcess=item.ProjectStatusProcess,
                  

                });
            }
            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View(new ProjectStatusViewModel());
        }

        [HttpPost]
        public ActionResult Create(ProjectStatusViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                ProjectStatus projectStatus = new ProjectStatus
                {
                    Id=viewmodel.Id,
                    ProjectStatusProcess=viewmodel.ProjectStatusProcess,
                };

                uow.ProjectStatusRepository.Add(projectStatus);
                uow.Commit();
            }
            return Json(new { success = true, message = "Record Saved Successfully" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var projectStatus = uow.ProjectStatusRepository.GetById(id);

            ProjectStatusViewModel viewmodel = new ProjectStatusViewModel
            {
                Id=projectStatus.Id,
                ProjectStatusProcess=projectStatus.ProjectStatusProcess,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(ProjectStatusViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var projectStatus = uow.ProjectStatusRepository.GetById(viewmodel.Id);

                projectStatus.Id = viewmodel.Id;
                projectStatus.ProjectStatusProcess = viewmodel.ProjectStatusProcess;

                uow.ProjectStatusRepository.Update(projectStatus);
                uow.Commit();
            }

            return Json(new { success = true, message = "Record Updated Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var projectStatus = uow.ProjectStatusRepository.GetById(id);

            ProjectStatusViewModel viewmodel = new ProjectStatusViewModel
            {
                Id=projectStatus.Id,
                ProjectStatusProcess=projectStatus.ProjectStatusProcess,
            };

            uow.ProjectStatusRepository.Remove(projectStatus);
            uow.Commit();
            return Json(new { success = true, message = "Record Deleted Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var projectStatus = uow.ProjectStatusRepository.GetById(id);

            ProjectStatusViewModel viewmodel = new ProjectStatusViewModel
            {
                Id = projectStatus.Id,
                ProjectStatusProcess = projectStatus.ProjectStatusProcess,
            };

            return View(viewmodel);
        }

    }
}