using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PRO_finder.Models;

namespace PRO_finder.Controllers
{
    
    public class QuotationController : Controller
    {
        ProFinderModels ctx = new ProFinderModels();
        // GET: Quotation
        public ActionResult Index()
        {
            var test = from p in ctx.Tests
                           select p;
            return View(test.ToList());
        }
        public ActionResult Detail()
        {
            return View();
        }

        public ActionResult StudioHome()
        {
            return View();
        }

        public ActionResult WorksPage()
        {
            return View();
        }

    }
}