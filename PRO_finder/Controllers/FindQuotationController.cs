using PRO_finder.Models.DBModel;
using PRO_finder.Models.ViewModels;
using PRO_finder.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PRO_finder.Controllers
{
    public class FindQuotationController : Controller
    {
        // GET: FindQuotation
        private readonly ProFinderContext _ctx;
        private caseService _caseService;

        public FindQuotationController()
        {
            _ctx = new ProFinderContext();
            _caseService = new caseService();
        }
        public ActionResult Index()
        {
            List<CaseViewModel> result = _caseService.Getcase();
            ViewBag.caseList = result;
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