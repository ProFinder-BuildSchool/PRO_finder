using PRO_finder.Models.ViewModels;
using PRO_finder.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace PRO_finder.Controllers
{
    public class FindQuotationController : Controller
    {

        private readonly CaseService _caseService;

        public FindQuotationController()
        {
           _caseService = new CaseService();

        }



        [HttpGet]
        // GET: FindQuotation
        public ActionResult Index(string id =null, string searchStr = null)
        {

            ViewBag.CateId = id;
            List<CaseViewModel> result = new List<CaseViewModel>();
            if (string.IsNullOrEmpty(id))
            {
                result = _caseService.GetCasesList().ToList();
                ViewBag.CateId = 13;
            }
            else if (string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(searchStr))
            {
                result = _caseService.GetCasesList().Where(x => x.Description.Contains(searchStr)).ToList();
                ViewBag.CateId = 13;
            }
            else if(!string.IsNullOrEmpty(id) && string.IsNullOrEmpty(searchStr))
            {
                result = _caseService.GetCasesList().Where(x => x.CategoryID == Int32.Parse(id)).ToList();
            }
            else if (!string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(searchStr))
            {
                result = _caseService.GetCasesList().Where(x => x.CategoryID == Int32.Parse(id) && x.Description.Contains(searchStr)).ToList();
            }
         

            return View(result);
        }





        [Authorize]
        public ActionResult Detail(int id = 1)
        {
            
            ViewBag.CateId = id;
            var result = _caseService.GetCaseDetail().FirstOrDefault(x => x.CaseId == id);
            return View(result);

        }

        public ActionResult Othercase(string Cateid) 
        {
            var result = _caseService.GetCaseDetail().Where(x => x.CategoryID == Int32.Parse(Cateid)).ToList
                ();

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}