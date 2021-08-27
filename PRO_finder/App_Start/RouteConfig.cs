﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using PRO_finder.Models.ViewModels;

namespace PRO_finder
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" }
            );
            routes.MapRoute(
                name: "Detail",
                url: "{controller}/{action}/{Memberid}/{Quotationid}",
                defaults: new { controller = "Quotation", action = "Detail"}
            );
          
            //routes.MapRoute(
            //    name: "StudioHome",
            //    url: "{controller}/{action}/{Memberid}",
            //    defaults: new { controller = "Quotation", action = "StudioHome" }
            //);
        }
    }
}
