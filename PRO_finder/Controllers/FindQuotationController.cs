﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PRO_finder.Controllers
{
    public class FindQuotationController : Controller
    {
        // GET: FindQuotation
        public ActionResult Index()
        {
            string Contain = this.TempData["Contain"] as string;
            return View();
        }

        public ActionResult Detail()
        {
            return View();
        }public ActionResult Test()
        {
            return View();
        }
    }
}