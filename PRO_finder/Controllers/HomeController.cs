using PRO_finder.Models;
using PRO_finder.Models.Enum;
using PRO_finder.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PRO_finder.Settings;

namespace PRO_finder.Controllers
{
    public class HomeController : Controller
    {
            
                                                          
        public ActionResult Index()                       
        {
            var category = new CategoryViewModel() {
                Categories = Setting.Titles
            };

            return View(category);                                
        }                                                 
                                                          
        //public ActionResult FindQuotation()              
        //{                                                 
                                                         
           // return View();
        //}

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}