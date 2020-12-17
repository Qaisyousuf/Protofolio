using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QaisYousuf.Data.Interfaces;
using QaisYousuf.Services;
using Unity;
using QaisYousuf.ViewModels;

namespace QaisYousuf.Web.Controllers
{
    public class BaseController : Controller
    {
        [Dependency]
        public IUnitOfWork Uow { get; set; }

        [Dependency]
        public IAuthenticationServices Authservices { get; set; }

        protected override void OnResultExecuting(ResultExecutingContext filterContext)
        {

            if (filterContext.Result is ViewResult result)
            {
                BaseViewModel baseViewModel = ViewData.Model as BaseViewModel;

                if (baseViewModel != null)
                {
                    var site = Uow.Context.Settings.FirstOrDefault();

                    var siteSetting = Uow.Context.Settings.FirstOrDefault(x => x.Id == site.Id);

                    baseViewModel.SiteName = siteSetting.SiteName;
                    baseViewModel.SiteOwner = siteSetting.SiteOwner;
                    baseViewModel.GoogleSiteVerfication = siteSetting.GoogleSiteVerfication;
                    baseViewModel.GoogleAds = siteSetting.GoogleAds;
                    baseViewModel.SiteLastUpdate = siteSetting.SiteLastUpdate;
                    baseViewModel.UpdatedBy = siteSetting.UpdatedBy;
                    baseViewModel.BaseTitle = siteSetting.UpdatedBy;
                    baseViewModel.BaseContent = siteSetting.Content;
                    baseViewModel.Home = siteSetting.Home;
                    baseViewModel.HomeUrl = siteSetting.HomeUrl;
                    baseViewModel.About = siteSetting.About;
                    baseViewModel.AboutUrl = siteSetting.AboutUrl;
                    baseViewModel.UIUX = siteSetting.UIUX;
                    baseViewModel.UIUXURl = siteSetting.UIUXURl;
                    baseViewModel.Code = siteSetting.Code;
                    baseViewModel.CodeUrl = siteSetting.CodeUrl;
                    baseViewModel.Contact = siteSetting.Contact;
                    baseViewModel.ContactUrl = siteSetting.ContactUrl;
                    baseViewModel.Support = siteSetting.Support;
                    baseViewModel.SupportUrl = siteSetting.SupportUrl;
                    baseViewModel.Profile = siteSetting.Profile;
                    baseViewModel.ProfileUrl = siteSetting.ProfileUrl;
                    baseViewModel.CopyrightFooter = siteSetting.CopyrightFooter;
                    baseViewModel.DesignBy = siteSetting.DesignBy;

                }
            }
        }
    }
}