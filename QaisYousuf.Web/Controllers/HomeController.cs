using QaisYousuf.Data.Interfaces;
using QaisYousuf.Models;
using QaisYousuf.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace QaisYousuf.Web.Controllers
{
    public class HomeController : BaseController
    {
      
        
        public ActionResult Index(string slug)
        {

            if (string.IsNullOrEmpty(slug))
                slug = "home";
            if(!uow.HomePageRepository.SlugExists(slug))
            {
                TempData["PageNotFound"] = "Page Not Found";
                return RedirectToAction(nameof(Index), new { slug = "" });

            }
            PageViewModel viewmodel;
            HomePage page;

            page = uow.HomePageRepository.GetHomePageBySlug(slug);


            ViewBag.PageTitle = page.Title;

            TempData["PageBanner"] = page.BannerId;
            TempData["DataCollection"] = page.DataCollectionId;
            TempData["WorkQuality"] = page.WorkQualityId;
            TempData["ProjectCounting"] = page.ProjectCountingId;
            TempData["PlatformeDesign"] = page.PlatformDesignId;
            TempData["DesignSteps"] = page.DesignStepsId;




            viewmodel = new PageViewModel
            {
                Id=page.Id,
                Title=page.Title,
                Content=page.Content,
                IsPageMetaDataOn=page.IsPageMetaDataOn,
                MetaKeywords=page.MetaKeywords,
                MetaDescription=page.MetaDescription,
                IsVisibleToSearchEngine=page.IsVisibleToSearchEngine,

            };

            return View(viewmodel);
        }

        [ChildActionOnly]
        public ActionResult PartialMenu()
        {
            var context = uow.Context;
            var menus = context.Menus;

            foreach (var menu in menus)
            {
                context.Entry(menu).Collection(s => s.SubMenu).Query().Where(x => x.ParentId == menu.Id);
            }

            var menuSubmenus = menus.AsNoTracking().ToList();

            context.Dispose();

            return PartialView(menuSubmenus);
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult HomeBanner()
        {
            int id = (int)TempData["PageBanner"];

            var homeBanner = uow.HomeBannerRepository.GetById(id);

            HomeBannerViewModel viewmodel = new HomeBannerViewModel
            {
                Id=homeBanner.Id,
                Title=homeBanner.Title,
                SubTitle=homeBanner.SubTitle,
                BackgroundImage=homeBanner.BackgroundImage,
                ButtonUrl=homeBanner.ButtonUrl,
                ButtonText=homeBanner.ButtonText,
            };

            return PartialView(viewmodel);
        }

    }
}