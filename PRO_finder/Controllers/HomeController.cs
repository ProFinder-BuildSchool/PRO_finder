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

        public HomeController()
        {
            _ctx = new ProFinderContext();
            _CategoryService = new CategoryService();
            _Home_IndexService = new Home_IndexService();
        }
        public ActionResult Index()                       
        {

            var list = _CategoryService.Home_Index_GetCategoryItem();

            return View(list);                                
        }

        public ActionResult Index2()
        {

            var list = _CategoryService.Home_Index_GetCategoryItem();

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