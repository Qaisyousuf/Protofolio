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
    public class SiteSettingsController : Controller
    {
        private readonly IUnitOfWork uow;

        public SiteSettingsController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetSiteSettingData()
        {
            var settings = uow.SiteSettingRepository.GetAll();

            List<SiteSettingViewMdoel> viewmodel = new List<SiteSettingViewMdoel>();

            foreach (var item in settings)
            {
                viewmodel.Add(new SiteSettingViewMdoel
                {
                    Id=item.Id,
                    SiteName=item.SiteName,
                    SiteOwner=item.SiteOwner,
                    GoogleSiteVerfication=item.GoogleSiteVerfication,
                    GoogleAds=item.GoogleAds,
                    SiteLastUpdate=item.SiteLastUpdate,
                    UpdatedBy=item.UpdatedBy,
                    Title=item.Title,
                    Contact=item.Contact,
                    Home=item.Home,
                    HomeUrl=item.HomeUrl,
                    AboutUrl=item.AboutUrl,
                    About=item.About,
                    UIUX=item.UIUX,
                    UIUXURl=item.UIUXURl,
                    Code=item.Code,
                    CodeUrl=item.CodeUrl,
                    ContactUrl=item.ContactUrl,
                    Content=item.Content,
                    Support=item.Support,
                    SupportUrl=item.SupportUrl,
                    Profile=item.Profile,
                    ProfileUrl=item.ProfileUrl,
                    CopyrightFooter=item.CopyrightFooter,
                    DesignBy=item.DesignBy,
                });
            }
            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new SiteSettingViewMdoel());
        }

        [HttpPost]
        public ActionResult Create(SiteSettingViewMdoel viewmodel)
        {
            if(ModelState.IsValid)
            {
                Settings settings = new Settings
                {
                    Id=viewmodel.Id,
                    SiteName=viewmodel.SiteName,
                    SiteOwner=viewmodel.SiteOwner,
                    GoogleSiteVerfication=viewmodel.GoogleSiteVerfication,
                    GoogleAds=viewmodel.GoogleAds,
                    SiteLastUpdate=DateTime.Now,
                    UpdatedBy=viewmodel.UpdatedBy,
                    Title=viewmodel.Title,
                    Content=viewmodel.Content,
                    Home=viewmodel.Home,
                    HomeUrl=viewmodel.HomeUrl,
                    About=viewmodel.About,
                    AboutUrl=viewmodel.AboutUrl,
                    UIUX=viewmodel.UIUX,
                    UIUXURl=viewmodel.UIUXURl,
                    Code=viewmodel.Code,
                    CodeUrl=viewmodel.CodeUrl,
                    ContactUrl=viewmodel.ContactUrl,
                    Contact=viewmodel.Contact,
                    Support=viewmodel.Support,
                    SupportUrl=viewmodel.SupportUrl,
                    Profile=viewmodel.Profile,
                    ProfileUrl=viewmodel.ProfileUrl,
                    CopyrightFooter=viewmodel.CopyrightFooter,
                    DesignBy=viewmodel.DesignBy,
                    
                };

                uow.SiteSettingRepository.Add(settings);
                uow.Commit();
            }

            return Json(new { success = true, message = "Record Saved Successfully" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var settings = uow.SiteSettingRepository.GetById(id);

            SiteSettingViewMdoel viewmodel = new SiteSettingViewMdoel
            {
                Id=settings.Id,
                SiteName=settings.SiteName,
                SiteOwner=settings.SiteOwner,
                GoogleSiteVerfication=settings.GoogleSiteVerfication,
                GoogleAds=settings.GoogleAds,
                SiteLastUpdate=settings.SiteLastUpdate,
                UpdatedBy=settings.UpdatedBy,
                Title=settings.Title,
                Content=settings.Content,
                Home=settings.Home,
                HomeUrl=settings.HomeUrl,
                About=settings.About,
                AboutUrl=settings.AboutUrl,
                UIUX=settings.UIUX,
                UIUXURl=settings.UIUXURl,
                Code=settings.Code,
                CodeUrl=settings.CodeUrl,
                ContactUrl=settings.ContactUrl,
                Contact=settings.Contact,
                Support=settings.Support,
                SupportUrl=settings.SupportUrl,
                Profile=settings.Profile,
                ProfileUrl=settings.ProfileUrl,
                CopyrightFooter=settings.CopyrightFooter,
                DesignBy=settings.DesignBy,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(SiteSettingViewMdoel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var settings = uow.SiteSettingRepository.GetById(viewmodel.Id);

                settings.Id = viewmodel.Id;
                settings.SiteName = viewmodel.SiteName;
                settings.SiteOwner = viewmodel.SiteOwner;
                settings.GoogleSiteVerfication = viewmodel.GoogleSiteVerfication;
                settings.GoogleAds = viewmodel.GoogleAds;
                settings.SiteLastUpdate = DateTime.Now;
                settings.UpdatedBy = viewmodel.UpdatedBy;
                settings.Title = viewmodel.Title;
                settings.Content = viewmodel.Content;
                settings.Home = viewmodel.Home;
                settings.HomeUrl = viewmodel.HomeUrl;
                settings.About = viewmodel.About;
                settings.AboutUrl = viewmodel.AboutUrl;
                settings.UIUX = viewmodel.UIUX;
                settings.UIUXURl = viewmodel.UIUXURl;
                settings.Code = viewmodel.Code;
                settings.CodeUrl = viewmodel.CodeUrl;
                settings.Contact = viewmodel.Contact;
                settings.ContactUrl = viewmodel.ContactUrl;
                settings.Support = viewmodel.Support;
                settings.SupportUrl = viewmodel.SupportUrl;
                settings.Profile = viewmodel.Profile;
                settings.ProfileUrl = viewmodel.ProfileUrl;
                settings.CopyrightFooter = viewmodel.CopyrightFooter;
                settings.DesignBy = viewmodel.DesignBy;

                uow.SiteSettingRepository.Update(settings);
                uow.Commit();
            }
            return Json(new { success = true, message = "Record Updated Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var settings = uow.SiteSettingRepository.GetById(id);

            SiteSettingViewMdoel viewmodel = new SiteSettingViewMdoel
            {
                Id = settings.Id,
                SiteName = settings.SiteName,
                SiteOwner = settings.SiteOwner,
                GoogleSiteVerfication = settings.GoogleSiteVerfication,
                GoogleAds = settings.GoogleAds,
                SiteLastUpdate = settings.SiteLastUpdate,
                UpdatedBy = settings.UpdatedBy,
                Title = settings.Title,
                Content = settings.Content,
                Home = settings.Home,
                HomeUrl = settings.HomeUrl,
                About = settings.About,
                AboutUrl = settings.AboutUrl,
                UIUX = settings.UIUX,
                UIUXURl = settings.UIUXURl,
                Code = settings.Code,
                CodeUrl = settings.CodeUrl,
                ContactUrl = settings.ContactUrl,
                Contact = settings.Contact,
                Support = settings.Support,
                SupportUrl = settings.SupportUrl,
                Profile = settings.Profile,
                ProfileUrl = settings.ProfileUrl,
                CopyrightFooter = settings.CopyrightFooter,
                DesignBy = settings.DesignBy,
            };

            uow.SiteSettingRepository.Remove(settings);
            uow.Commit();

            return Json(new { success = true, message = "Record Deleted Successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var settings = uow.SiteSettingRepository.GetById(id);

            SiteSettingViewMdoel viewmodel = new SiteSettingViewMdoel
            {
                Id = settings.Id,
                SiteName = settings.SiteName,
                SiteOwner = settings.SiteOwner,
                GoogleSiteVerfication = settings.GoogleSiteVerfication,
                GoogleAds = settings.GoogleAds,
                SiteLastUpdate = settings.SiteLastUpdate,
                UpdatedBy = settings.UpdatedBy,
                Title = settings.Title,
                Content = settings.Content,
                Home = settings.Home,
                HomeUrl = settings.HomeUrl,
                About = settings.About,
                AboutUrl = settings.AboutUrl,
                UIUX = settings.UIUX,
                UIUXURl = settings.UIUXURl,
                Code = settings.Code,
                CodeUrl = settings.CodeUrl,
                ContactUrl = settings.ContactUrl,
                Contact = settings.Contact,
                Support = settings.Support,
                SupportUrl = settings.SupportUrl,
                Profile = settings.Profile,
                ProfileUrl = settings.ProfileUrl,
                CopyrightFooter = settings.CopyrightFooter,
                DesignBy = settings.DesignBy,
            };

            return View(viewmodel);
        }
    }
}