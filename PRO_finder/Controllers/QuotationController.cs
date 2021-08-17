using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PRO_finder.Models;
using PRO_finder.Models.ViewModels;
using PRO_finder.Repositories;
using PRO_finder.Service;
using PRO_finder.Models.DBModel;

namespace PRO_finder.Controllers
{

    public class QuotationController : Controller
    {
        private readonly QuotationService _quotService;

        public QuotationController()
        {

            _quotService = new QuotationService();
        }

        //ProFinderModels ctx = new ProFinderModels();
        // GET: Quotation
        public ActionResult Index(int CategoryId = 0)
        {
            //string Contain = this.TempData["Contain"] as string;

            List<QuotationViewModel> pageData = _quotService.GetCategoryPageData(CategoryId);
            ViewBag.cateNameList = _quotService.GetsubcatrgotyName(CategoryId);


            return View(pageData);
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

        
        public ActionResult AllcardData()
        {
            List<QuotationViewModel> allCardData = _quotService.GetAllCardData();
            return Json(allCardData, JsonRequestBehavior.AllowGet);
        }
    }
}