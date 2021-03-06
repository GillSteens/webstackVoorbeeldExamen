﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using VoorbeeldExamen.Models;

namespace VoorbeeldExamen
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Application["Sessions"] = -1;

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Database.SetInitializer<VBEXDBContext>(new Seeder());
        }

        void Session_Start(object sender, EventArgs e)
        {
            Application["Sessions"] = (int)Application["Sessions"] + 1;
        }

        void Session_End(object sender, EventArgs e)
        {
            Application["Sessions"] = (int)Application["Sessions"] - 1;
        }
    }
}
