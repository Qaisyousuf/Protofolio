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
    public class CodePageController : Controller
    {
        private readonly IUnitOfWork uow;

        public CodePageController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        private void CodeDropDownData()
        {
            ViewBag.Banner = uow.CodeBannerRepository.GetAll();
            ViewBag.ProgrammingTools = uow.WebProgrammingToolsRepository.GetAll();
            ViewBag.UIUXTools = uow.UIUXToolsRepository.GetAll();
            ViewBag.DesignCode = uow.DesignCodeSectionRepository.GetAll();
            ViewBag.Subscribtion = uow.SubscribeRepository.GetAll();
        }

        [HttpGet]
        public ActionResult GetCodePageData()
        {
            var codePage = uow.CodePageRepository.GetAll("CodeBanner", "WebProgrammingTools", "UI_UX_Tools", "DesignCodeSection", "Subscribe");

            List<CodePageViewModel> viewmodel = new List<CodePageViewModel>();

            foreach (var item in codePage)
            {
                viewmodel.Add(new CodePageViewModel
                {
                    Id=item.Id,
                    Title=item.Title,
                    Slug=item.Slug,
                    MetaKeywords=item.MetaKeywords,
                    MetaDescription=item.MetaDescription,
                    IsVisibleToSearchEngine=item.IsVisibleToSearchEngine,
                    BannerId=item.BannerId,
                    CodeBanner=item.CodeBanner,
                    ProgrammingId=item.ProgrammingId,
                    WebProgrammingTools=item.WebProgrammingTools,
                    UI_UX_Id=item.UI_UX_Id,
                    UI_UX_Tools=item.UI_UX_Tools,
                    DesignCodeId=item.DesignCodeId,
                    DesignCodeSection=item.DesignCodeSection,
                    SubscriptionId=item.SubscriptionId,
                    Subscribe=item.Subscribe,
                });
            }
            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            CodeDropDownData();
            return View(new CodePageViewModel());
        }

        [HttpPost]
        public ActionResult Create(CodePageViewModel viewmodel)
        {
            if(!ModelState.IsValid)
            {
                CodeDropDownData();
                return View(viewmodel);
            }

            string slug;
            CodePage codePage = new CodePage();

            codePage.Id = viewmodel.Id;
            codePage.Title = viewmodel.Title;

            if (string.IsNullOrEmpty(viewmodel.Slug))
                slug = SlugHelper.Create(true, viewmodel.Title);
            else
                slug = SlugHelper.Create(true, viewmodel.Slug);

            if (uow.CodePageRepository.SlugExists(slug))
            {
                ModelState.AddModelError("", "Title or Slug already exists");

                CodeDropDownData();
                return View(viewmodel);
            }

            codePage.Slug = slug;
            codePage.MetaKeywords = viewmodel.MetaKeywords;
            codePage.MetaDescription = viewmodel.MetaDescription;
            codePage.IsVisibleToSearchEngine = viewmodel.IsVisibleToSearchEngine;
            codePage.BannerId = viewmodel.BannerId;
            codePage.CodeBanner = viewmodel.CodeBanner;
            codePage.ProgrammingId = viewmodel.ProgrammingId;
            codePage.WebProgrammingTools = viewmodel.WebProgrammingTools;
            codePage.UI_UX_Id = viewmodel.UI_UX_Id;
            codePage.UI_UX_Tools = viewmodel.UI_UX_Tools;
            codePage.DesignCodeId = viewmodel.DesignCodeId;
            codePage.DesignCodeSection = viewmodel.DesignCodeSection;
            codePage.SubscriptionId = viewmodel.SubscriptionId;
            codePage.Subscribe = viewmodel.Subscribe;

            uow.CodePageRepository.Add(codePage);
            uow.Commit();

            return Json(new { success = true, message = "Record Saved Successfully" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var codePage = uow.CodePageRepository.GetById(id);

            CodePageViewModel viewmodel = new CodePageViewModel
            {
                Id=codePage.Id,
                Title=codePage.Title,
                Slug=codePage.Slug,
                MetaKeywords=codePage.MetaKeywords,
                MetaDescription=codePage.MetaDescription,
                IsVisibleToSearchEngine=codePage.IsVisibleToSearchEngine,
                BannerId=codePage.BannerId,
                CodeBanner=codePage.CodeBanner,
                ProgrammingId=codePage.ProgrammingId,
                WebProgrammingTools=codePage.WebProgrammingTools,
                UI_UX_Id=codePage.UI_UX_Id,
                UI_UX_Tools=codePage.UI_UX_Tools,
                DesignCodeId=codePage.DesignCodeId,
                DesignCodeSection=codePage.DesignCodeSection,
                SubscriptionId=codePage.SubscriptionId,
                Subscribe=codePage.Subscribe,
            };

            CodeDropDownData();
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(CodePageViewModel viewmodel)
        {
            if(!ModelState.IsValid)
            {
                CodeDropDownData();
                return View(viewmodel);
            }

            string slug;
            CodePage codePage = new CodePage();

            codePage.Id = viewmodel.Id;
            codePage.Title = viewmodel.Title;

            if (string.IsNullOrEmpty(viewmodel.Slug))
                slug = SlugHelper.Create(true, viewmodel.Title);
            else
                slug = SlugHelper.Create(true, viewmodel.Slug);

            if (uow.CodePageRepository.SlugExists(viewmodel.Id, slug))
            {
                ModelState.AddModelError("", "Title or Slug already exists");

                CodeDropDownData();
                return View(viewmodel);
            }

            codePage.Slug = slug;
            codePage.MetaKeywords = viewmodel.MetaKeywords;
            codePage.MetaDescription = viewmodel.MetaDescription;
            codePage.IsVisibleToSearchEngine = viewmodel.IsVisibleToSearchEngine;
            codePage.BannerId = viewmodel.BannerId;
            codePage.CodeBanner = viewmodel.CodeBanner;
            codePage.ProgrammingId = viewmodel.ProgrammingId;
            codePage.WebProgrammingTools = viewmodel.WebProgrammingTools;
            codePage.UI_UX_Id = viewmodel.UI_UX_Id;
            codePage.UI_UX_Tools = viewmodel.UI_UX_Tools;
            codePage.DesignCodeId = viewmodel.DesignCodeId;
            codePage.DesignCodeSection = viewmodel.DesignCodeSection;
            codePage.SubscriptionId = viewmodel.SubscriptionId;
            codePage.Subscribe = viewmodel.Subscribe;

            uow.CodePageRepository.Update(codePage);
            uow.Commit();

            return Json(new { success = true, message = "Record Updated Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var codePage = uow.CodePageRepository.GetById(id);

            CodePageViewModel viewmodel = new CodePageViewModel
            {
                Id=codePage.Id,
                Title=codePage.Title,
                Slug=codePage.Slug,
                MetaKeywords=codePage.MetaKeywords,
                MetaDescription=codePage.MetaDescription,
                IsVisibleToSearchEngine=codePage.IsVisibleToSearchEngine,
                BannerId=codePage.BannerId,
                CodeBanner=codePage.CodeBanner,
                ProgrammingId=codePage.ProgrammingId,
                WebProgrammingTools=codePage.WebProgrammingTools,
                UI_UX_Id=codePage.UI_UX_Id,
                UI_UX_Tools=codePage.UI_UX_Tools,
                DesignCodeId=codePage.DesignCodeId,
                DesignCodeSection=codePage.DesignCodeSection,
                SubscriptionId=codePage.SubscriptionId,
                Subscribe=codePage.Subscribe,
            };

            uow.CodePageRepository.Remove(codePage);
            uow.Commit();

            return Json(new { success = true, message = "Record Deleted Successfuly" }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var codePage = uow.CodePageRepository.GetById(id);

            CodePageViewModel viewmodel = new CodePageViewModel
            {
                Id = codePage.Id,
                Title = codePage.Title,
                Slug = codePage.Slug,
                MetaKeywords = codePage.MetaKeywords,
                MetaDescription = codePage.MetaDescription,
                IsVisibleToSearchEngine = codePage.IsVisibleToSearchEngine,
                BannerId = codePage.BannerId,
                CodeBanner = codePage.CodeBanner,
                ProgrammingId = codePage.ProgrammingId,
                WebProgrammingTools = codePage.WebProgrammingTools,
                UI_UX_Id = codePage.UI_UX_Id,
                UI_UX_Tools = codePage.UI_UX_Tools,
                DesignCodeId = codePage.DesignCodeId,
                DesignCodeSection = codePage.DesignCodeSection,
                SubscriptionId = codePage.SubscriptionId,
                Subscribe = codePage.Subscribe,
            };
            return View(viewmodel);
        }
    }
}