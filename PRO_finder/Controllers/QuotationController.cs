using PRO_finder.Models.ViewModels;
using PRO_finder.Service;
using PRO_finder.Models.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PRO_finder.Models;
using PRO_finder.Repositories;
using Newtonsoft.Json;
using PRO_finder.Model.ViewModels;

namespace PRO_finder.Controllers
{

    public class QuotationController : Controller
    {
        private readonly QuotationService _quotService;
        private readonly StudioService _studioService;

        public QuotationController()
        {
            _quotService = new QuotationService();
            _studioService = new StudioService();
        }
        // GET: Quotation
        public ActionResult Index(int CategoryId = 0)
        {
            string Contain = this.TempData["Contain"] as string;

            List<QuotationViewModel> pageData = _quotService.GetCategoryPageData(CategoryId);
            ViewBag.cateNameList = _quotService.GetsubcatrgotyName(CategoryId);


            return View(pageData);
        }
        public ActionResult Detail(int Memberid,int Quotationid)
        {
            QuotationViewModel QuoDetailVM = _quotService.GetQuoDetailData(Memberid, Quotationid);
            ViewBag.QID = Quotationid;
            return View(QuoDetailVM);
        }

        public ActionResult StudioHome()
        {
            return View();
        }

        public ActionResult WorksPage(int WorkID = 1)
        {
            List<WorkPageViewModel> pageData = _studioService.GetWorkPageData (WorkID);
            return View(pageData);
        }

        
        public ActionResult AllcardData()
        {
            List<QuotationViewModel> allCardData = _quotService.GetAllCardData();
            return Json(allCardData, JsonRequestBehavior.AllowGet);
        }
    }
}