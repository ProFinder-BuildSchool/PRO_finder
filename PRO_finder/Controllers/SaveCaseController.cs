using PRO_finder.Models.DBModel;
using PRO_finder.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PRO_finder.Controllers
{
    public class SaveCaseController : Controller
    {
        private readonly CaseService _saveCaseService;

        public SaveCaseController()
        {
            _saveCaseService = new CaseService();
        }

        public ActionResult GetSaveCase()
        {
            //ViewBag.SaveCaseList = CaseService.GetSavedCaseData(CaseID);
            return View();
        }
        public ActionResult CreateSaveCase(int CaseID)
        {
            
            return View();
        }
    }
}