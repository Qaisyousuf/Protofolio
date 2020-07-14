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
    public class PagesController : Controller
    {
        private readonly IUnitOfWork uow;

        public PagesController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        // GET: UIToCode/Pages
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetPagesData()
        {
 
            var homePage = uow.HomePageRepository.GetAll("HomeBanner", "DataCollection", "WorkQualitySection", "ProjectCountiing", "PlatformDesign", "DesignSteps");

            List<PageViewModel> pageviewmodel = new List<PageViewModel>();

            foreach (var item in homePage)
            {
                pageviewmodel.Add(new PageViewModel
                {
                    Id=item.Id,
                    Title=item.Title,
                    Slug=item.Slug,
                    Content=item.Content,
                    MetaKeywords=item.MetaKeywords,
                    MetaDescription=item.MetaDescription,
                    IsVisibleToSearchEngine=item.IsVisibleToSearchEngine,
                    BannerId=item.BannerId,
                    IsPageMetaDataOn=item.IsPageMetaDataOn,
                    HomeBanner=item.HomeBanner,
                    DataCollectionId=item.DataCollectionId,
                    DataCollection=item.DataCollection,
                    WorkQualityId=item.WorkQualityId,
                    WorkQualitySection=item.WorkQualitySection,
                    ProjectCountingId=item.ProjectCountingId,
                    ProjectCountiing=item.ProjectCountiing,
                    PlatformDesignId=item.PlatformDesignId,
                    PlatformDesign=item.PlatformDesign,
                    DesignStepsId=item.DesignStepsId,
                    DesignSteps=item.DesignSteps,
                });
            }

            return Json(new { data = pageviewmodel }, JsonRequestBehavior.AllowGet);
        }


        public void GetPageRelatedData()
        {

            ViewBag.homeBanner = uow.HomeBannerRepository.GetAll();
            ViewBag.dataCollection = uow.DataCollectionRepository.GetAll();
            ViewBag.workQuality = uow.WorkQualitySectionRepository.GetAll();
            ViewBag.projectCounting = uow.ProjectCountingRepository.GetAll();
            ViewBag.platformDesign = uow.PlatformDesignRepository.GetAll();
            ViewBag.designSteps = uow.DesignStepsRepository.GetAll();

        }

        [HttpGet]
        public ActionResult Create()
        {
            GetPageRelatedData();
            return View();
        }

        [HttpPost]
        public ActionResult Create(PageViewModel viewmodel)
        {
            if(!ModelState.IsValid)
            {
                GetPageRelatedData();
                return View(viewmodel);
            }

            string slug;

            HomePage page = new HomePage();
            page.Title = viewmodel.Title;

            if (string.IsNullOrEmpty(viewmodel.Slug))
                slug = SlugHelper.Create(true, viewmodel.Title);
            else
                slug = SlugHelper.Create(true, viewmodel.Slug);

            if(uow.HomePageRepository.SlugExists(slug))
            {
                ModelState.AddModelError("", "Title or Slug already exists");

                GetPageRelatedData();
                return View(viewmodel);
            }

            page.Slug = slug;
            page.Content = viewmodel.Content;
            page.IsPageMetaDataOn = viewmodel.IsPageMetaDataOn;
            page.MetaKeywords = viewmodel.MetaKeywords;
            page.MetaDescription = viewmodel.MetaDescription;
            page.IsVisibleToSearchEngine = viewmodel.IsVisibleToSearchEngine;
            page.BannerId = viewmodel.BannerId;
            page.HomeBanner = viewmodel.HomeBanner;
            page.DataCollectionId = viewmodel.DataCollectionId;
            page.DataCollection = viewmodel.DataCollection;
            page.WorkQualityId = viewmodel.WorkQualityId;
            page.WorkQualitySection = viewmodel.WorkQualitySection;
            page.ProjectCountingId = viewmodel.ProjectCountingId;
            page.ProjectCountiing = viewmodel.ProjectCountiing;
            page.PlatformDesignId = viewmodel.PlatformDesignId;
            page.PlatformDesign = viewmodel.PlatformDesign;
            page.DesignStepsId = viewmodel.DesignStepsId;
            page.DesignSteps = viewmodel.DesignSteps;

            uow.HomePageRepository.Add(page);
            uow.Commit();

            return Json(new { success = true, message = "Record Saved Successfully" }, JsonRequestBehavior.AllowGet);


        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var page = uow.HomePageRepository.GetById(id);

            PageViewModel viewmodel = new PageViewModel
            {
                Id=page.Id,
                Title=page.Title,
                Slug=page.Slug,
                Content=page.Content,
                IsPageMetaDataOn=page.IsPageMetaDataOn,
                MetaKeywords=page.MetaKeywords,
                MetaDescription=page.MetaDescription,
                IsVisibleToSearchEngine=page.IsVisibleToSearchEngine,
                BannerId=page.BannerId,
                HomeBanner=page.HomeBanner,
                DataCollectionId=page.DataCollectionId,
                DataCollection=page.DataCollection,
                WorkQualityId=page.WorkQualityId,
                WorkQualitySection=page.WorkQualitySection,
                ProjectCountingId=page.ProjectCountingId,
                ProjectCountiing=page.ProjectCountiing,
                PlatformDesignId=page.PlatformDesignId,
                PlatformDesign=page.PlatformDesign,
                DesignStepsId=page.DesignStepsId,
                DesignSteps=page.DesignSteps,

            };
            GetPageRelatedData();
            return View(viewmodel);
        }
        [HttpPost]
        public ActionResult Edit(PageViewModel viewmodel)
        {
            if(!ModelState.IsValid)
            {
                GetPageRelatedData();
                return View(viewmodel);
            }

            string slug;

            var page = uow.HomePageRepository.GetById(viewmodel.Id);

            page.Title = viewmodel.Title;

            if (string.IsNullOrEmpty(viewmodel.Slug))
                slug = SlugHelper.Create(true, viewmodel.Title);
            else
                slug = SlugHelper.Create(true, viewmodel.Slug);

            if(uow.HomePageRepository.SlugExists(viewmodel.Id,slug))
            {
                ModelState.AddModelError("", "Title or Slug already exists");
                GetPageRelatedData();

                return View(viewmodel);
            }

            page.Slug = slug;
            page.Content = viewmodel.Content;
            page.IsPageMetaDataOn = viewmodel.IsPageMetaDataOn;
            page.MetaKeywords = viewmodel.MetaKeywords;
            page.MetaDescription = viewmodel.MetaDescription;
            page.IsVisibleToSearchEngine = viewmodel.IsVisibleToSearchEngine;
            page.BannerId = viewmodel.BannerId;
            page.HomeBanner = viewmodel.HomeBanner;
            page.DataCollectionId = viewmodel.DataCollectionId;
            page.DataCollection = viewmodel.DataCollection;
            page.WorkQualityId = viewmodel.WorkQualityId;
            page.WorkQualitySection = viewmodel.WorkQualitySection;
            page.ProjectCountingId = viewmodel.ProjectCountingId;
            page.ProjectCountiing = viewmodel.ProjectCountiing;
            page.PlatformDesignId = viewmodel.PlatformDesignId;
            page.PlatformDesignId = viewmodel.PlatformDesignId;
            page.DesignStepsId = viewmodel.DesignStepsId;
            page.DesignSteps = viewmodel.DesignSteps;


            uow.HomePageRepository.Update(page);
            uow.Commit();
            return Json(new { success = true, message = "Record Updated Successfuly" }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult Delete(int id)
        {
            var page = uow.HomePageRepository.GetById(id);

            PageViewModel viewmodel = new PageViewModel
            {
                Id=page.Id,
                Title=page.Title,
                Slug=page.Slug,
                Content=page.Content,
                IsPageMetaDataOn=page.IsPageMetaDataOn,
                MetaKeywords=page.MetaKeywords,
                MetaDescription=page.MetaDescription,
                IsVisibleToSearchEngine=page.IsVisibleToSearchEngine,
                BannerId=page.BannerId,
                HomeBanner=page.HomeBanner,
                DataCollectionId=page.DataCollectionId,
                DataCollection=page.DataCollection,
                WorkQualityId=page.WorkQualityId,
                WorkQualitySection=page.WorkQualitySection,
                ProjectCountingId=page.ProjectCountingId,
                ProjectCountiing=page.ProjectCountiing,
                PlatformDesignId=page.PlatformDesignId,
                PlatformDesign=page.PlatformDesign,
                DesignStepsId=page.DesignStepsId,
                DesignSteps=page.DesignSteps,

            };
            uow.HomePageRepository.Remove(page);
            uow.Commit();
            return Json(new { success = true, message = "Record Deleted Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var page = uow.HomePageRepository.GetById(id);

            PageViewModel viewmodel = new PageViewModel
            {
                Id = page.Id,
                Title = page.Title,
                Slug = page.Slug,
                Content = page.Content,
                IsPageMetaDataOn = page.IsPageMetaDataOn,
                MetaKeywords = page.MetaKeywords,
                MetaDescription = page.MetaDescription,
                IsVisibleToSearchEngine = page.IsVisibleToSearchEngine,
                BannerId = page.BannerId,
                HomeBanner = page.HomeBanner,
                DataCollectionId = page.DataCollectionId,
                DataCollection = page.DataCollection,
                WorkQualityId = page.WorkQualityId,
                WorkQualitySection = page.WorkQualitySection,
                ProjectCountingId = page.ProjectCountingId,
                ProjectCountiing = page.ProjectCountiing,
                PlatformDesignId = page.PlatformDesignId,
                PlatformDesign = page.PlatformDesign,
                DesignStepsId = page.DesignStepsId,
                DesignSteps = page.DesignSteps,

            };

            GetPageRelatedData();
            return View(viewmodel);
        }
    }
}