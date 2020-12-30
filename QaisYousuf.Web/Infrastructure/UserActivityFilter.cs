using QaisYousuf.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QaisYousuf.Models;

namespace QaisYousuf.Web.Infrastructure
{
    public class UserActivityFilter : FilterAttribute, IActionFilter
    {
        private readonly UIContext _Context;
        public UserActivityFilter()
        {
            _Context = new UIContext();
        }
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
           
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
                string actionName = filterContext.ActionDescriptor.ActionName;
                string userAgint = filterContext.HttpContext.Request.UserAgent;
                string userName = filterContext.HttpContext.User.Identity.Name;
                DateTime dateTime = filterContext.HttpContext.Timestamp;
                string userBrowser = filterContext.HttpContext.Request.Browser.Browser;
                string authenticationActivity = filterContext.ActionDescriptor.ActionName.Replace("Index", "Login");
                string Ip = filterContext.HttpContext.Request.UserHostAddress;

                var userActivity = new UserActivity
                {
                    Ip = Ip,
                    ControllerName = controllerName,
                    ActionName = actionName,
                    UserAgint = userAgint,
                    LoginUser = userName,
                    DateTime = dateTime,
                    UserBrowser = userBrowser,
                    AuthenticationActivity = authenticationActivity,
                };

                _Context.UserActivities.Add(userActivity);
                _Context.SaveChanges();
            }
        }
    }
}