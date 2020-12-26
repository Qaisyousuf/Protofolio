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

                    baseViewModel.BaseSiteName = siteSetting.SiteName;
                    baseViewModel.BaseSiteOwner = siteSetting.SiteOwner;
                    baseViewModel.BseGoogleSiteVerfication = siteSetting.GoogleSiteVerfication;
                    baseViewModel.BaseGoogleAds = siteSetting.GoogleAds;
                    baseViewModel.BaseSiteLastUpdate = siteSetting.SiteLastUpdate;
                    baseViewModel.BaseUpdatedBy = siteSetting.UpdatedBy;
                    baseViewModel.BaseBaseTitle = siteSetting.UpdatedBy;
                    baseViewModel.BaseBaseContent = siteSetting.Content;
                    baseViewModel.BAseHome = siteSetting.Home;
                    baseViewModel.BaseHomeUrl = siteSetting.HomeUrl;
                    baseViewModel.BaseAbout = siteSetting.About;
                    baseViewModel.BaseAboutUrl = siteSetting.AboutUrl;
                    baseViewModel.BAseUIUX = siteSetting.UIUX;
                    baseViewModel.BaseUIUXURl = siteSetting.UIUXURl;
                    baseViewModel.BaseCode = siteSetting.Code;
                    baseViewModel.BaseCodeUrl = siteSetting.CodeUrl;
                    baseViewModel.BaseContact = siteSetting.Contact;
                    baseViewModel.BaseBaseContactUrl = siteSetting.ContactUrl;
                    baseViewModel.BaseSupport = siteSetting.Support;
                    baseViewModel.BaseSupportUrl = siteSetting.SupportUrl;
                    baseViewModel.BaseProfile = siteSetting.Profile;
                    baseViewModel.BaseProfileUrl = siteSetting.ProfileUrl;
                    baseViewModel.BaseCopyrightFooter = siteSetting.CopyrightFooter;
                    baseViewModel.BaseDesignBy = siteSetting.DesignBy;

                }
            }
        }
    }
}