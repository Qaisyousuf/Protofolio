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
            if (!uow.HomePageRepository.SlugExists(slug))
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
                Id = page.Id,
                Title = page.Title,
                Content = page.Content,
                IsPageMetaDataOn = page.IsPageMetaDataOn,
                MetaKeywords = page.MetaKeywords,
                MetaDescription = page.MetaDescription,
                IsVisibleToSearchEngine = page.IsVisibleToSearchEngine,

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
                Id = homeBanner.Id,
                Title = homeBanner.Title,
                SubTitle = homeBanner.SubTitle,
                BackgroundImage = homeBanner.BackgroundImage,
                ButtonUrl = homeBanner.ButtonUrl,
                ButtonText = homeBanner.ButtonText,
            };

            return PartialView(viewmodel);
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult WorkQuality()
        {
            int id = (int)TempData["WorkQuality"];

            var workQuality = uow.WorkQualitySectionRepository.GetById(id);

            WorkQualitySectionViewModel viewmodel = new WorkQualitySectionViewModel
            {
                Id = workQuality.Id,
                Title = workQuality.Title,
                Content = workQuality.Content,
                ImageUrl = workQuality.ImageUrl,
                ButtonText = workQuality.ButtonText,
                ModalTitle = workQuality.ModalTitle,
                ModalsContent = workQuality.ModalsContent,

            };

            return PartialView(viewmodel);
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult DataCollection()
        {
            var dataCollection = uow.DataCollectionRepository.GetAll();

            List<DataCollectionViewModel> viewmodel = new List<DataCollectionViewModel>();


            foreach (var item in dataCollection)
            {
                viewmodel.Add(new DataCollectionViewModel
                {
                    Id = item.Id,
                    MainTitle = item.MainTitle,
                    SubTitle = item.SubTitle,
                    Content = item.Content,
                    ImageUrl = item.Image,
                });
            }

            ListOfDataViewModels listofData = new ListOfDataViewModels
            {
                ListOfDataCollectionViewModel = viewmodel
            };
            return PartialView(listofData);
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult PlatformDesign()
        {


            var platformDesign = uow.PlatformDesignRepository.GetAll();

            List<PlatformDesignViewModel> viewmodel = new List<PlatformDesignViewModel>();

            foreach (var item in platformDesign)
            {
                viewmodel.Add(new PlatformDesignViewModel
                {
                    Id = item.Id,
                    MainTitle = item.MainTitle,
                    SubTitle = item.SubTitle,
                    Content = item.Content,
                    ImageUrl = item.ImageUrl,
                    ButtonText = item.ButtonText,
                    ImageContent=item.ImageContent,
                });
            }

            ListOfPlatfomeDesignViewModel ViewModelPlatformDesign = new ListOfPlatfomeDesignViewModel
            {
                ListPlatformDesignViewModel = viewmodel
            };

            return PartialView(ViewModelPlatformDesign);

        }
        [HttpGet]
        [ChildActionOnly]
        public ActionResult ProjectCounting()
        {
            

            var project = uow.ProjectCountingRepository.GetAll();

            List<ProjectCountingViewModel> viewmodel = new List<ProjectCountingViewModel>();

            foreach (var item in project)
            {
                viewmodel.Add(new ProjectCountingViewModel
                {
                    Id = item.Id,
                    MainTitle = item.MainTitle,
                    SubTitle = item.SubTitle,
                    ImageUrl = item.ImageUrl,
                    Title = item.Title,
                    CountingNumber = item.CountingNumber,
                });
            }

            ListOfProjectCounting projectCounting = new ListOfProjectCounting
            {
                CountingViewModel = viewmodel
            };
            

            return PartialView(projectCounting);

        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult DesignSteps()
        {
            var desing = uow.DesignStepsRepository.GetAll();


            List<DesignStepsViewModel> viewmodel = new List<DesignStepsViewModel>();

            foreach (var item in desing)
            {
                viewmodel.Add(new DesignStepsViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    SubTitle=item.SubTitle,
                    StepIcon=item.StepIcon,
                    StepTitle=item.StepTitle,
                    StepContent=item.StepContent,
                    StepImageUrl=item.StepImageUrl,
                });
            }

            ListOfDesignStepsViewModel ListofDesing = new ListOfDesignStepsViewModel
            {
                DesignViewModel = viewmodel
            };

            return PartialView(ListofDesing);
        }

        [HttpPost]
        public ActionResult Subscrite(SubscribeViewModel viewmodel)
        {
            Subscribe subscribe = new Subscribe
            {
                Id=viewmodel.Id,
                Title=viewmodel.Title,

            };
            return View();
        }
    }
}