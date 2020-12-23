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
    public class AboutPageController : Controller
    {
        private readonly IUnitOfWork uow;

        public AboutPageController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        public void GetAboutPageRelatedData()
        {
           
            ViewBag.AboutPageBanner = uow.AboutPageBannerRepository.GetAll();
            ViewBag.StartUpProgram = uow.StartUpProgramRepository.GetAll();
            ViewBag.StartUpProcess = uow.StartUpProcessRepository.GetAll();
            ViewBag.MeetOurTeam = uow.MeetOurTeamRepository.GetAll();

            var name = uow.Context.AboutPages.ToList();

            ViewBag.Name = name.Select(x => x.Title);

        }

        [HttpGet]
        public ActionResult GetAboutPageData()
        {
            var aboutPage = uow.AboutPageRepository.GetAll("AboutPageBanner","StartUpProgram", "StartUpProcess","MeetOurTeam");

            List<AboutPageViewModel> viewmodel = new List<AboutPageViewModel>();

            foreach (var item in aboutPage)
            {
                viewmodel.Add(new AboutPageViewModel
                {
                    Id=item.Id,
                    Title=item.Title,
                    Slug=item.Slug,
                    MetaKeywords=item.MetaKeywords,
                    MetaDescription=item.MetaDescription,
                    IsVisibleToSearchEngine=item.IsVisibleToSearchEngine,
                    Content=item.Content,
                    BannerId=item.BannerId,
                    AboutPageBanner=item.AboutPageBanner,
                    StartUpProgramId=item.StartUpProgramId,
                    StartUpProgram=item.StartUpProgram,
                    StartUpProcessId=item.StartUpProcessId,
                    StartUpProcess=item.StartUpProcess,
                    MeetOurTeamId=item.MeetOurTeamId,
                    MeetOurTeam=item.MeetOurTeam
                });
            }

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            GetAboutPageRelatedData();
            return View(new AboutPageViewModel());
        }

        [HttpPost]
        public ActionResult Create(AboutPageViewModel viewmodel)
        {
            if(!ModelState.IsValid)
            {
                GetAboutPageRelatedData();
                return View(viewmodel);
            }

            string slug;

            AboutPage aboutPage = new AboutPage();
            aboutPage.Id = viewmodel.Id;
            aboutPage.Title = viewmodel.Title;

            if (string.IsNullOrEmpty(viewmodel.Slug))
                slug = SlugHelper.Create(true, viewmodel.Title);
            else
                slug = SlugHelper.Create(true, viewmodel.Slug);

            if (uow.AboutPageRepository.SlugExists(slug))
            {
                ModelState.AddModelError("", "Title or Slug already exists");

                GetAboutPageRelatedData();
                return View(viewmodel);
            }

            aboutPage.Slug = slug;
            aboutPage.MetaKeywords = viewmodel.MetaKeywords;
            aboutPage.MetaDescription = viewmodel.MetaDescription;
            aboutPage.IsVisibleToSearchEngine = viewmodel.IsVisibleToSearchEngine;
            aboutPage.Content = viewmodel.Content;
            aboutPage.BannerId = viewmodel.BannerId;
            aboutPage.AboutPageBanner = viewmodel.AboutPageBanner;
            aboutPage.StartUpProgramId = viewmodel.StartUpProgramId;
            aboutPage.StartUpProgram = viewmodel.StartUpProgram;
            aboutPage.StartUpProcessId = viewmodel.StartUpProcessId;
            aboutPage.StartUpProcess = viewmodel.StartUpProcess;
            aboutPage.MeetOurTeam = viewmodel.MeetOurTeam;
            aboutPage.MeetOurTeamId = viewmodel.MeetOurTeamId;

            uow.AboutPageRepository.Add(aboutPage);
            uow.Commit();

            return Json(new { success = true, message = "Record Saved Successfully" }, JsonRequestBehavior.AllowGet);


        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var aboutPage = uow.AboutPageRepository.GetById(id);

            AboutPageViewModel viewmodel = new AboutPageViewModel
            {
                Id = aboutPage.Id,
                Title = aboutPage.Title,
                Slug = aboutPage.Slug,
                MetaKeywords = aboutPage.MetaKeywords,
                MetaDescription = aboutPage.MetaDescription,
                IsVisibleToSearchEngine = aboutPage.IsVisibleToSearchEngine,
                Content=aboutPage.Content,
                BannerId=aboutPage.BannerId,
                AboutPageBanner=aboutPage.AboutPageBanner,
                StartUpProgramId=aboutPage.StartUpProgramId,
                StartUpProgram=aboutPage.StartUpProgram,
                StartUpProcessId=aboutPage.StartUpProcessId,
                StartUpProcess=aboutPage.StartUpProcess,
                MeetOurTeamId=aboutPage.MeetOurTeamId,
                MeetOurTeam=aboutPage.MeetOurTeam,

            };

            GetAboutPageRelatedData();
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(AboutPageViewModel viewmodel)
        {
            if(!ModelState.IsValid)
            {
                GetAboutPageRelatedData();
                return View(viewmodel);
            }

            var aboutPage = uow.AboutPageRepository.GetById(viewmodel.Id);

            string slug;
            aboutPage.Id = viewmodel.Id;
            aboutPage.Title = viewmodel.Title;

            if (string.IsNullOrEmpty(viewmodel.Slug))
                slug = SlugHelper.Create(true, viewmodel.Title);
            else
                slug = SlugHelper.Create(true, viewmodel.Slug);

            if (uow.AboutPageRepository.SlugExists(viewmodel.Id,slug))
            {
                ModelState.AddModelError("", "Title or Slug already exists");

                GetAboutPageRelatedData();
                return View(viewmodel);
            }

            aboutPage.Slug = slug;

            aboutPage.MetaKeywords = viewmodel.MetaKeywords;
            aboutPage.MetaDescription = viewmodel.MetaDescription;
            aboutPage.IsVisibleToSearchEngine = viewmodel.IsVisibleToSearchEngine;
            aboutPage.Content = viewmodel.Content;
            aboutPage.BannerId = viewmodel.BannerId;
            aboutPage.AboutPageBanner = viewmodel.AboutPageBanner;
            aboutPage.StartUpProgramId = viewmodel.StartUpProgramId;
            aboutPage.StartUpProgram = viewmodel.StartUpProgram;
            aboutPage.StartUpProcessId = viewmodel.StartUpProcessId;
            aboutPage.StartUpProcess = viewmodel.StartUpProcess;
            aboutPage.MeetOurTeamId = viewmodel.MeetOurTeamId;
            aboutPage.MeetOurTeam = viewmodel.MeetOurTeam;


            uow.AboutPageRepository.Update(aboutPage);
            uow.Commit();

            return Json(new { success = true, message = "Record Updated Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var aboutPage = uow.AboutPageRepository.GetById(id);

            AboutPageViewModel viewmodel = new AboutPageViewModel
            {
                Id=aboutPage.Id,
                Title=aboutPage.Title,
                Slug=aboutPage.Slug,
                MetaKeywords=aboutPage.MetaKeywords,
                MetaDescription=aboutPage.MetaDescription,
                IsVisibleToSearchEngine=aboutPage.IsVisibleToSearchEngine,
                Content=aboutPage.Content,
                BannerId=aboutPage.BannerId,
                AboutPageBanner=aboutPage.AboutPageBanner,
                StartUpProgramId=aboutPage.StartUpProgramId,
                StartUpProgram=aboutPage.StartUpProgram,
                StartUpProcessId=aboutPage.StartUpProcessId,
                StartUpProcess=aboutPage.StartUpProcess,
                MeetOurTeamId=aboutPage.MeetOurTeamId,
                MeetOurTeam=aboutPage.MeetOurTeam,
            };

            uow.AboutPageRepository.Remove(aboutPage);
            uow.Commit();
            return Json(new { success = true, message = "Record Deleted Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var about = uow.AboutPageRepository.GetById(id);

            AboutPageViewModel viewmodel = new AboutPageViewModel
            {
                Id=about.Id,
                Title=about.Title,
                Slug=about.Slug,
                MetaKeywords=about.MetaKeywords,
                MetaDescription=about.MetaDescription,
                IsVisibleToSearchEngine=about.IsVisibleToSearchEngine,
                Content=about.Content,
                BannerId=about.BannerId,
                AboutPageBanner=about.AboutPageBanner,
                StartUpProgramId=about.StartUpProgramId,
                StartUpProgram=about.StartUpProgram,
                StartUpProcessId=about.StartUpProcessId,
                StartUpProcess=about.StartUpProcess,
                MeetOurTeamId=about.MeetOurTeamId,
                MeetOurTeam=about.MeetOurTeam,
            };

            return View(viewmodel);
        }
    }
}