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
    public class ProjectPortfolioController : Controller
    {
        private readonly IUnitOfWork uow;

        public ProjectPortfolioController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetProjectPortfolioData()
        {
            var projectPortfolio = uow.PortfolioProjectRepository.GetAll("ProjectStatus");

            List<PortfolioProjectViewModel> viewmodel = new List<PortfolioProjectViewModel>();

            foreach (var item in projectPortfolio)
            {
                viewmodel.Add(new PortfolioProjectViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    Content=item.Content,
                    SubContent=item.SubContent,
                    ProjectName=item.ProjectName,
                    ProjectType=item.ProjectType,
                    ProjectImageUrl=item.ProjectImageUrl,
                    ProjectPublishDate=item.ProjectPublishDate,
                    ProjectDetails=item.ProjectDetails,
                    ProjectWebSiteUrl=item.ProjectWebSiteUrl,
                    ButtonText=item.ButtonText,
                    ProjectStatusId=item.ProjectStatusId,
                    ProjectStatus=item.ProjectStatus,
                });

            }
            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.ProjectStatus = uow.ProjectStatusRepository.GetAll();

            return View(new PortfolioProjectViewModel());
        }

        [HttpPost]
        public ActionResult Create(PortfolioProjectViewModel viewmodel)
        {
           if(ModelState.IsValid)
            {
                PortfolioProject project = new PortfolioProject
                {
                    Id = viewmodel.Id,
                    MainTitle=viewmodel.MainTitle,
                    Content=viewmodel.Content,
                    SubContent=viewmodel.SubContent,
                    ProjectName=viewmodel.ProjectName,
                    ProjectType=viewmodel.ProjectType,
                    ProjectImageUrl=viewmodel.ProjectImageUrl,
                    ProjectPublishDate=viewmodel.ProjectPublishDate,
                    ProjectDetails=viewmodel.ProjectDetails,
                    ProjectWebSiteUrl=viewmodel.ProjectWebSiteUrl,
                    ButtonText=viewmodel.ButtonText,
                    ProjectStatusId=viewmodel.ProjectStatusId,
                    ProjectStatus=viewmodel.ProjectStatus,
                
                };

                uow.PortfolioProjectRepository.Add(project);
                uow.Commit();
            }
            return Json(new { success = true, message = "`" +
                0}, JsonRequestBehavior.AllowGet);

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var project = uow.PortfolioProjectRepository.GetById(id);

            PortfolioProjectViewModel viewmodel = new PortfolioProjectViewModel
            {
                Id=project.Id,
                MainTitle=project.MainTitle,
                Content=project.Content,
                SubContent=project.SubContent,
                ProjectName=project.ProjectName,
                ProjectType=project.ProjectType,
                ProjectImageUrl=project.ProjectImageUrl,
                ProjectPublishDate=project.ProjectPublishDate,
                ProjectDetails=project.ProjectDetails,
                ProjectWebSiteUrl=project.ProjectWebSiteUrl,
                ButtonText=project.ButtonText,
                ProjectStatusId=project.ProjectStatusId,
                ProjectStatus=project.ProjectStatus,
            };

            ViewBag.ProjectStatus = uow.ProjectStatusRepository.GetAll();
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(PortfolioProjectViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var project = uow.PortfolioProjectRepository.GetById(viewmodel.Id);

                project.Id = viewmodel.Id;
                project.MainTitle = viewmodel.MainTitle;
                project.Content = viewmodel.Content;
                project.SubContent = viewmodel.SubContent;
                project.ProjectName = viewmodel.ProjectName;
                project.ProjectType = viewmodel.ProjectType;
                project.ProjectImageUrl = viewmodel.ProjectImageUrl;
                project.ProjectPublishDate = viewmodel.ProjectPublishDate;
                project.ProjectDetails = viewmodel.ProjectDetails;
                project.ProjectWebSiteUrl = viewmodel.ProjectWebSiteUrl;
                project.ButtonText = viewmodel.ButtonText;
                project.ProjectStatusId = viewmodel.ProjectStatusId;
                project.ProjectStatus = viewmodel.ProjectStatus;

                uow.PortfolioProjectRepository.Update(project);
                uow.Commit();
            }
            return Json(new { success = true, message = "Record Updated Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var project = uow.PortfolioProjectRepository.GetById(id);

            PortfolioProjectViewModel viewmodel = new PortfolioProjectViewModel
            {
                Id = project.Id,
                MainTitle = project.MainTitle,
                Content = project.Content,
                SubContent = project.SubContent,
                ProjectName = project.ProjectName,
                ProjectType = project.ProjectType,
                ProjectImageUrl = project.ProjectImageUrl,
                ProjectPublishDate = project.ProjectPublishDate,
                ProjectDetails = project.ProjectDetails,
                ProjectWebSiteUrl = project.ProjectWebSiteUrl,
                ButtonText = project.ButtonText,
                ProjectStatusId = project.ProjectStatusId,
                ProjectStatus = project.ProjectStatus,
            };

            uow.PortfolioProjectRepository.Remove(project);
            uow.Commit();

            return Json(new { success = true, message = "Record Deleted Successfuly" }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var project = uow.PortfolioProjectRepository.GetById(id);

            PortfolioProjectViewModel viewmodel = new PortfolioProjectViewModel
            {
                Id = project.Id,
                MainTitle = project.MainTitle,
                Content = project.Content,
                SubContent = project.SubContent,
                ProjectName = project.ProjectName,
                ProjectType = project.ProjectType,
                ProjectImageUrl = project.ProjectImageUrl,
                ProjectPublishDate = project.ProjectPublishDate,
                ProjectDetails = project.ProjectDetails,
                ProjectWebSiteUrl = project.ProjectWebSiteUrl,
                ButtonText = project.ButtonText,
                ProjectStatusId = project.ProjectStatusId,
                ProjectStatus = project.ProjectStatus,
            };
            return View(viewmodel);
        }
    }
}