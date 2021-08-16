using PRO_finder.Models;
using PRO_finder.Models.Enum;
using PRO_finder.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace PRO_finder.Controllers
{
    public class HomeController : Controller
    {
            
                                                          
        public ActionResult Index()                       
        {
            

            return View();                                
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