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

        public HomeController()
        {
            _ctx = new ProFinderContext();
            _CategoryService = new CategoryService();
        }
        public ActionResult Index()                       
        {

            List<CategoryViewModel> categories = _CategoryService.Home_Index_GetCategoryItem();

            return View(categories);                                
        }                                                 
                                                          
     

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}