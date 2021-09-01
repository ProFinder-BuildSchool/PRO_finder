using PRO_finder.Models;
using PRO_finder.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PRO_finder.Models.DBModel;
using PRO_finder.Repositories;
using PRO_finder.Service;


namespace PRO_finder.Controllers
{
    public class HomeController : Controller
    {

        private readonly ProFinderContext _ctx;
        private CategoryService _CategoryService;
        private Home_IndexService _Home_IndexService;
        private QuotationService _quotationService;
        private WorksService _worksService;
        private CaseService _caseService;

        public HomeController()
        {
            _ctx = new ProFinderContext();
            _CategoryService = new CategoryService();
            _Home_IndexService = new Home_IndexService();
            _quotationService = new QuotationService();
            _worksService = new WorksService();
            _caseService = new CaseService();
        }
        public ActionResult Index()                       
        {

            var list = _CategoryService.Home_Index_GetCategoryItem();

            var QuotationList = _quotationService.GetAllCardDataGroupByIndex();

            var workList = _worksService.GetWorks_HomeIndex();

            var caseList = _caseService.GetFinishCases();


            ViewBag.QuotationList = QuotationList;
            ViewBag.workList = workList;
            ViewBag.caseList = caseList;




            return View(list);                                
        }

        public ActionResult Index2()
        {

            var list = _worksService.GetWorks_HomeIndex();

            return Json(list,JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Index(string type ,string contain)
        {
            var Type = type;
            var Contain = contain;
            this.TempData["Contain"] = contain;
            if (Type == "找報價")
            {
                return RedirectToAction("Index", "Quotation");
            }
            else if(Type == "找案子")
            {
                return RedirectToAction("Index", "FindQuotation");
            }
            ViewBag.keyWord = contain;

            return View();
        }



        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        
    }
}