using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QaisYousuf.ViewModels;
using QaisYousuf.Models;
using QaisYousuf.Data.Interfaces;
using QaisYousuf.Services;

namespace QaisYousuf.Web.Areas.UIToCode.Controllers
{
    [Authorize(Roles = "Supper Admin")]
    public class PortfolioController : Controller
    {
        private readonly IUnitOfWork uow;

        public PortfolioController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetPortfolioData()
        {
            var portfolio = uow.PortfolioRepository.GetAll("PortfolioBanner", "PortfolioAbout", "WorkExperience", "Education", "OnlineCertification", "PortfolioProject", "Interest");

            List<PortfolioViewModel> viewmodel = new List<PortfolioViewModel>();

            foreach (var item in portfolio)
            {
                viewmodel.Add(new PortfolioViewModel
                {
                    Id=item.Id,
                    Title=item.Title,
                    Slug=item.Slug,
                    MetaKeywords=item.MetaKeywords,
                    MetaDescription=item.MetaDescription,
                    IsVisibleToSearchEngine=item.IsVisibleToSearchEngine,
                    BannerId=item.BannerId,
                    PortfolioBanner=item.PortfolioBanner,
                    PortfolioAboutId=item.PortfolioAboutId,
                    PortfolioAbout=item.PortfolioAbout,
                    WorkExperienceId=item.WorkExperienceId,
                    WorkExperience=item.WorkExperience,
                    EducationId=item.EducationId,
                    Education=item.Education,
                    OnlineCertificationId=item.OnlineCertificationId,
                    OnlineCertification=item.OnlineCertification,
                    PortfolioProjectId=item.PortfolioProjectId,
                    PortfolioProject=item.PortfolioProject,
                    InterestId=item.InterestId,
                    Interest=item.Interest,
                });


            }
            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        public void GetPortfoloioRelatedData()
        {
            ViewBag.Banner = uow.PortfolioBannerRepository.GetAll();
            ViewBag.About = uow.PortfolioAboutRepository.GetAll();
            ViewBag.WorkExperience = uow.WorkExperienceRepository.GetAll();
            ViewBag.Education = uow.EducationRepository.GetAll();
            ViewBag.OnlineCertification = uow.OnlineCertificationRepository.GetAll();
            ViewBag.Project = uow.PortfolioProjectRepository.GetAll();
            ViewBag.Insterest = uow.IntresetRepository.GetAll();
        }

        [HttpGet]
        public ActionResult Create()
        {
            GetPortfoloioRelatedData();
            return View(new PortfolioViewModel());
        }

        [HttpPost]
        public ActionResult Create(PortfolioViewModel viewmodel)
        {
            if(!ModelState.IsValid)
            {
                GetPortfoloioRelatedData();
                return View(viewmodel);
            }

            string slug;

            Portfolio portfolio = new Portfolio();
            portfolio.Id = viewmodel.Id;
            portfolio.Title = viewmodel.Title;

            if (string.IsNullOrEmpty(viewmodel.Slug))
                slug = SlugHelper.Create(true, viewmodel.Title);
            else
                slug = SlugHelper.Create(true, viewmodel.Slug);

            if (uow.PortfolioRepository.SlugExists(slug))
            {
                ModelState.AddModelError("", "Title or Slug already exists");

                GetPortfoloioRelatedData();
                return View(viewmodel);
            }

            portfolio.Slug = slug;
            portfolio.MetaKeywords = viewmodel.MetaKeywords;
            portfolio.MetaDescription = viewmodel.MetaDescription;
            portfolio.IsVisibleToSearchEngine = viewmodel.IsVisibleToSearchEngine;
            portfolio.BannerId = viewmodel.BannerId;
            portfolio.PortfolioBanner = viewmodel.PortfolioBanner;
            portfolio.PortfolioAboutId = viewmodel.PortfolioAboutId;
            portfolio.PortfolioAbout = viewmodel.PortfolioAbout;
            portfolio.WorkExperienceId = viewmodel.WorkExperienceId;
            portfolio.WorkExperience = viewmodel.WorkExperience;
            portfolio.EducationId = viewmodel.EducationId;
            portfolio.Education = viewmodel.Education;
            portfolio.OnlineCertificationId = viewmodel.OnlineCertificationId;
            portfolio.OnlineCertification = viewmodel.OnlineCertification;
            portfolio.PortfolioProjectId = viewmodel.PortfolioProjectId;
            portfolio.PortfolioProject = viewmodel.PortfolioProject;
            portfolio.InterestId = viewmodel.InterestId;
            portfolio.Interest = viewmodel.Interest;

            uow.PortfolioRepository.Add(portfolio);
            uow.Commit();

            return Json(new { success = true, message = "Record Saved Successfully" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var portfolio = uow.PortfolioRepository.GetById(id);

            PortfolioViewModel viewmodel = new PortfolioViewModel
            {
                Id=portfolio.Id,
                Title=portfolio.Title,
                Slug=portfolio.Slug,
                MetaKeywords=portfolio.MetaKeywords,
                MetaDescription=portfolio.MetaDescription,
                IsVisibleToSearchEngine=portfolio.IsVisibleToSearchEngine,
                BannerId=portfolio.BannerId,
                PortfolioBanner=portfolio.PortfolioBanner,
                PortfolioAboutId=portfolio.PortfolioAboutId,
                PortfolioAbout=portfolio.PortfolioAbout,
                WorkExperienceId=portfolio.WorkExperienceId,
                WorkExperience=portfolio.WorkExperience,
                EducationId=portfolio.EducationId,
                Education=portfolio.Education,
                OnlineCertificationId=portfolio.OnlineCertificationId,
                OnlineCertification=portfolio.OnlineCertification,
                PortfolioProjectId=portfolio.PortfolioProjectId,
                PortfolioProject=portfolio.PortfolioProject,
                InterestId=portfolio.InterestId,
                Interest=portfolio.Interest,
            };

            GetPortfoloioRelatedData();
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(PortfolioViewModel viewmodel)
        {
            if(!ModelState.IsValid)
            {
                GetPortfoloioRelatedData();
                return View(viewmodel);
            }

            string slug;

            Portfolio portfolio = new Portfolio();

            portfolio.Id = viewmodel.Id;
            portfolio.Title = viewmodel.Title;

            if (string.IsNullOrEmpty(viewmodel.Slug))
                slug = SlugHelper.Create(true, viewmodel.Title);
            else
                slug = SlugHelper.Create(true, viewmodel.Slug);

            if (uow.PortfolioRepository.SlugExists(viewmodel.Id, slug))
            {
                ModelState.AddModelError("", "Title or Slug already exists");

                GetPortfoloioRelatedData();
                return View(viewmodel);
            }

            portfolio.Slug = slug;
            portfolio.MetaKeywords = viewmodel.MetaKeywords;
            portfolio.MetaDescription = viewmodel.MetaDescription;
            portfolio.IsVisibleToSearchEngine = viewmodel.IsVisibleToSearchEngine;
            portfolio.BannerId = viewmodel.BannerId;
            portfolio.PortfolioBanner = viewmodel.PortfolioBanner;
            portfolio.PortfolioAboutId = viewmodel.PortfolioAboutId;
            portfolio.PortfolioAbout = viewmodel.PortfolioAbout;
            portfolio.WorkExperienceId = viewmodel.WorkExperienceId;
            portfolio.WorkExperience = viewmodel.WorkExperience;
            portfolio.EducationId = viewmodel.EducationId;
            portfolio.Education = viewmodel.Education;
            portfolio.OnlineCertificationId = viewmodel.OnlineCertificationId;
            portfolio.OnlineCertification = viewmodel.OnlineCertification;
            portfolio.PortfolioProjectId = viewmodel.PortfolioProjectId;
            portfolio.PortfolioProject = viewmodel.PortfolioProject;
            portfolio.InterestId = viewmodel.InterestId;
            portfolio.Interest = viewmodel.Interest;

            uow.PortfolioRepository.Update(portfolio);
            uow.Commit();

            return Json(new { success = true, message = "Record Updated Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var portfolio = uow.PortfolioRepository.GetById(id);

            PortfolioViewModel viewmodel = new PortfolioViewModel
            {
                Id = portfolio.Id,
                Title = portfolio.Title,
                Slug = portfolio.Slug,
                MetaKeywords = portfolio.MetaKeywords,
                MetaDescription = portfolio.MetaDescription,
                IsVisibleToSearchEngine = portfolio.IsVisibleToSearchEngine,
                BannerId = portfolio.BannerId,
                PortfolioBanner = portfolio.PortfolioBanner,
                PortfolioAboutId = portfolio.PortfolioAboutId,
                PortfolioAbout = portfolio.PortfolioAbout,
                WorkExperienceId = portfolio.WorkExperienceId,
                WorkExperience = portfolio.WorkExperience,
                EducationId = portfolio.EducationId,
                Education = portfolio.Education,
                OnlineCertificationId = portfolio.OnlineCertificationId,
                OnlineCertification = portfolio.OnlineCertification,
                PortfolioProjectId = portfolio.PortfolioProjectId,
                PortfolioProject = portfolio.PortfolioProject,
                InterestId = portfolio.InterestId,
                Interest = portfolio.Interest,
            };

            uow.PortfolioRepository.Remove(portfolio);
            uow.Commit();

            return Json(new { success = true, message = "Record Deleted Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var portfolio = uow.PortfolioRepository.GetById(id);

            PortfolioViewModel viewmodel = new PortfolioViewModel
            {
                Id = portfolio.Id,
                Title = portfolio.Title,
                Slug = portfolio.Slug,
                MetaKeywords = portfolio.MetaKeywords,
                MetaDescription = portfolio.MetaDescription,
                IsVisibleToSearchEngine = portfolio.IsVisibleToSearchEngine,
                BannerId = portfolio.BannerId,
                PortfolioBanner = portfolio.PortfolioBanner,
                PortfolioAboutId = portfolio.PortfolioAboutId,
                PortfolioAbout = portfolio.PortfolioAbout,
                WorkExperienceId = portfolio.WorkExperienceId,
                WorkExperience = portfolio.WorkExperience,
                EducationId = portfolio.EducationId,
                Education = portfolio.Education,
                OnlineCertificationId = portfolio.OnlineCertificationId,
                OnlineCertification = portfolio.OnlineCertification,
                PortfolioProjectId = portfolio.PortfolioProjectId,
                PortfolioProject = portfolio.PortfolioProject,
                InterestId = portfolio.InterestId,
                Interest = portfolio.Interest,
            };
            return View(viewmodel);
        }
    }
}