using System;
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
                name: "FindCaseCategory",
                url: "Case/Category/{categoryName}",
                defaults: new { controller = "FindQuotation", action = "FindCategory" }
            );
            routes.MapRoute(
                name: "SearchCase",
                url: "Case/Search/{content}",
                defaults: new { controller = "FindQuotation", action = "CaseSearch" }
            );

            routes.MapRoute(
            name: "FindQuotationCategory",
            url: "Quotation/Category/{categoryName}",
            defaults: new { controller = "Quotation", action = "FindQuotationCategory" }
        );
            routes.MapRoute(
               name: "SearchQuotation",
               url: "Quotation/Search/{content}",
               defaults: new { controller = "Quotation", action = "SearchQuotation" }
           );

            routes.MapRoute(
                          name: "Default",
                          url: "{controller}/{action}",
                          defaults: new { controller = "Home", action = "Index" }
                      );

            routes.MapRoute(
                name: "CaseSearch",
                url: "Case/Search/{id}/{searchStr}",
                defaults: new { controller = "FindQuotation", action = "Index", id = UrlParameter.Optional, searchStr = UrlParameter.Optional }
                );

            //routes.MapRoute(
            //    name: "Index",
            //    url: "{controller}/{action}/{CategoryId}",
            //    defaults: new { controller = "Quotation", action = "Index", CategoryId = UrlParameter.Optional }
            //);
            

            routes.MapRoute(
                name: "Origin",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );




            routes.MapRoute(
                name: "Detail",
                url: "Quotation/Detail/{Memberid}/{Quotationid}",
                defaults: new { controller = "Quotation", action = "Detail" }
            );

            //routes.MapRoute(
            //    name: "StudioHome",
            //    url: "{controller}/{action}/{Memberid}",
            //    defaults: new { controller = "Quotation", action = "StudioHome" }
            //);



            //routes.MapRoute(
            //     name: "Case",
            //     url: "Case/{cate}/{subcate}",
            //     defaults: new { controller = "Find", action = "Find", subcate = UrlParameter.Optional }
            // );
        }
    }
}
