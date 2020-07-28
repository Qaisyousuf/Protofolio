using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QaisYousuf.ViewModels;
using QaisYousuf.Data.Interfaces;
using QaisYousuf.Models;
using QaisYousuf.Services;

namespace QaisYousuf.Web.Areas.UIToCode.Controllers
{
    public class UIPageController : Controller
    {
        private readonly IUnitOfWork uow;

        public UIPageController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        public void UIPageRelatedData()
        {
            ViewBag.UIBanner = uow.UIBannerRepository.GetAll();
            ViewBag.UIProcess = uow.UIProcessRepository.GetAll();
            ViewBag.UISteps = uow.UIUXStepsRepository.GetAll();
            ViewBag.UIMatter = uow.UIUXMatterSectionRepository.GetAll();
        }

        [HttpGet]
        public ActionResult GetUIPageData()
        {
            var UiPage = uow.UIPageRepository.GetAll("UIBanner", "UIProcess", "UIUXSteps", "UIUXMatter");

            List<UIUXPageViewModel> viewmodel = new List<UIUXPageViewModel>();

            foreach (var item in UiPage)
            {
                viewmodel.Add(new UIUXPageViewModel
                {
                    Id=item.Id,
                    Title=item.Title,
                    Slug=item.Slug,
                    MetaKeywords=item.MetaKeywords,
                    MetaDescription=item.MetaDescription,
                    IsVisibleToSearchEngine=item.IsVisibleToSearchEngine,
                    UIBannerId=item.UIBannerId,
                    UIBanner=item.UIBanner,
                    UIProcessId=item.UIProcessId,
                    UIProcess=item.UIProcess,
                    UISetpsId=item.UISetpsId,
                    UIUXSteps=item.UIUXSteps,
                    UIUxMatterId=item.UIUxMatterId,
                    UIUXMatter=item.UIUXMatter,
                    
                });
            }
            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            UIPageRelatedData();
            return View(new UIUXPageViewModel());
        }

        [HttpPost]
        public ActionResult Create(UIUXPageViewModel viewmodel)
        {
            if(!ModelState.IsValid)
            {
                UIPageRelatedData();
                return View(viewmodel);
            }

            string slug;

            UIPage Uipage = new UIPage();

            Uipage.Id = viewmodel.Id;
            Uipage.Title = viewmodel.Title;

            if (string.IsNullOrEmpty(viewmodel.Slug))
                slug = SlugHelper.Create(true, viewmodel.Title);
            else
                slug = SlugHelper.Create(true, viewmodel.Slug);

            if (uow.AboutPageRepository.SlugExists(slug))
            {
                ModelState.AddModelError("", "Title or Slug already exists");

                UIPageRelatedData();
                return View(viewmodel);
            }

            Uipage.Slug = slug;
            Uipage.MetaKeywords = viewmodel.MetaKeywords;
            Uipage.MetaDescription = viewmodel.MetaDescription;
            Uipage.IsVisibleToSearchEngine = viewmodel.IsVisibleToSearchEngine;
            Uipage.UIBannerId = viewmodel.UIBannerId;
            Uipage.UIBanner = viewmodel.UIBanner;
            Uipage.UIProcessId = viewmodel.UIProcessId;
            Uipage.UIProcess = viewmodel.UIProcess;
            Uipage.UISetpsId = viewmodel.UISetpsId;
            Uipage.UIUXSteps = viewmodel.UIUXSteps;
            Uipage.UIUxMatterId = viewmodel.UIUxMatterId;
            Uipage.UIUXMatter = viewmodel.UIUXMatter;

            uow.UIPageRepository.Add(Uipage);
            uow.Commit();
            return Json(new { success = true, message = "Record Saved Successfully" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var UiPage = uow.UIPageRepository.GetById(id);

            UIUXPageViewModel viewmodel = new UIUXPageViewModel
            {
                Id=UiPage.Id,
                Title=UiPage.Title,
                Slug=UiPage.Slug,
                MetaKeywords=UiPage.MetaKeywords,
                MetaDescription=UiPage.MetaDescription,
                IsVisibleToSearchEngine=UiPage.IsVisibleToSearchEngine,
                UIBannerId=UiPage.UIBannerId,
                UIBanner=UiPage.UIBanner,
                UIProcessId=UiPage.UIProcessId,
                UIProcess=UiPage.UIProcess,
                UISetpsId=UiPage.UISetpsId,
                UIUXSteps=UiPage.UIUXSteps,
                UIUxMatterId=UiPage.UIUxMatterId,
                UIUXMatter=UiPage.UIUXMatter,

            };

            UIPageRelatedData();
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(UIUXPageViewModel viewmodel)
        {
            if(!ModelState.IsValid)
            {
                UIPageRelatedData();
                return View(viewmodel);
            }

            string slug;

            UIPage Uipage = new UIPage();

            Uipage.Id = viewmodel.Id;
            Uipage.Title = viewmodel.Title;

            if (string.IsNullOrEmpty(viewmodel.Slug))
                slug = SlugHelper.Create(true, viewmodel.Title);
            else
                slug = SlugHelper.Create(true, viewmodel.Slug);

            if (uow.UIPageRepository.SlugExists(viewmodel.Id, slug))
            {
                ModelState.AddModelError("", "Title or Slug already exists");

                UIPageRelatedData();
                return View(viewmodel);
            }


            Uipage.Slug = slug;
            Uipage.MetaKeywords = viewmodel.MetaKeywords;
            Uipage.MetaDescription = viewmodel.MetaDescription;
            Uipage.IsVisibleToSearchEngine = viewmodel.IsVisibleToSearchEngine;
            Uipage.UIBannerId = viewmodel.UIBannerId;
            Uipage.UIBanner = viewmodel.UIBanner;
            Uipage.UIProcessId = viewmodel.UIProcessId;
            Uipage.UIProcess = viewmodel.UIProcess;
            Uipage.UISetpsId = viewmodel.UISetpsId;
            Uipage.UIUXSteps = viewmodel.UIUXSteps;
            Uipage.UIUxMatterId = viewmodel.UIUxMatterId;
            Uipage.UIUXMatter = viewmodel.UIUXMatter;

            uow.UIPageRepository.Update(Uipage);
            uow.Commit();

            return Json(new { success = true, message = "Record Updated Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var Uipage = uow.UIPageRepository.GetById(id);

            UIUXPageViewModel viewmodel = new UIUXPageViewModel
            {
                Id=Uipage.Id,
                Title=Uipage.Title,
                Slug=Uipage.Slug,
                MetaKeywords=Uipage.MetaKeywords,
                MetaDescription=Uipage.MetaDescription,
                IsVisibleToSearchEngine=Uipage.IsVisibleToSearchEngine,
                UIBannerId=Uipage.UIBannerId,
                UIBanner=Uipage.UIBanner,
                UIProcessId=Uipage.UIProcessId,
                UIProcess=Uipage.UIProcess,
                UISetpsId=Uipage.UISetpsId,
                UIUXSteps=Uipage.UIUXSteps,
                UIUxMatterId=Uipage.UIUxMatterId,
                UIUXMatter=Uipage.UIUXMatter,
            };

            uow.UIPageRepository.Remove(Uipage);
            uow.Commit();

            return Json(new { success = true, message = "Record Deleted Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var Uipage = uow.UIPageRepository.GetById(id);

            UIUXPageViewModel viewmodel = new UIUXPageViewModel
            {
                Id = Uipage.Id,
                Title = Uipage.Title,
                Slug = Uipage.Slug,
                MetaKeywords = Uipage.MetaKeywords,
                MetaDescription = Uipage.MetaDescription,
                IsVisibleToSearchEngine = Uipage.IsVisibleToSearchEngine,
                UIBannerId = Uipage.UIBannerId,
                UIBanner = Uipage.UIBanner,
                UIProcessId = Uipage.UIProcessId,
                UIProcess = Uipage.UIProcess,
                UISetpsId = Uipage.UISetpsId,
                UIUXSteps = Uipage.UIUXSteps,
                UIUxMatterId = Uipage.UIUxMatterId,
                UIUXMatter = Uipage.UIUXMatter,
            };
            return View(viewmodel);

        }

    }
}