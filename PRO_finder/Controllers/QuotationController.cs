﻿using PRO_finder.Models.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PRO_finder.Controllers
{
    
    public class QuotationController : Controller
    {
        private ProFinderContext context = new ProFinderContext();
        // GET: Quotation
        public ActionResult Index()
        {
            return View();
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