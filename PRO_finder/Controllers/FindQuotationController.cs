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

        private readonly CaseService _caseService;

        public FindQuotationController()
        {
           _caseService = new CaseService();

        }

        // GET: FindQuotation
        public ActionResult Index()
        {
            List<CaseViewModel> result = _caseService.Getcase();
            ViewBag.caseList = result;
            List<SelectListItem> locationlist = _caseService.getLocationList();
            ViewBag.locationList = locationlist;
            return View();
        }


        public ActionResult IndexJson()
        {
            List<CaseViewModel> result = _caseService.GetCasesList();
            return Json(result,JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public ActionResult getLocationID(int locationID)
        {
            List<CaseViewModel> result = _caseService.Getcase().Where(x => x.LocationID == locationID).ToList() ;
            //if (result == null)
            //{
            //    result = _caseService.Getcase().Where(x => x.LocationID == 1).ToList();
            //}
            ViewBag.caseList = result;
            List<SelectListItem> locationlist = _caseService.getLocationList();
            ViewBag.locationList = locationlist;

            return View("getLocationID", ViewBag.caseList);
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