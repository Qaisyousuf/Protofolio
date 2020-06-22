﻿using QaisYousuf.Web.App_Start;
using QaisYousuf.Web.Filters;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace QaisYousuf.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            GlobalFilters.Filters.Add(new CustomAuthenticationFilter());
            
            
        }
    }
}
