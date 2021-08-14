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

namespace PRO_finder.Controllers
{
    
    public class QuotationController : Controller
    {
        private readonly QuotationRepository _quotRepo;
        private readonly QuotationService _quotService;

        public QuotationController()
        {
            _quotRepo = new QuotationRepository();
            _quotService = new QuotationService();
        }

        //ProFinderModels ctx = new ProFinderModels();
        // GET: Quotation
        public ActionResult Index(int CategoryId)
        {
            List<QuotationViewModel> pageData = _quotService.GetCategoryPageData(CategoryId);
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

        [HttpPost]
        public ActionResult JSON()
        {
            return JSON();
        }
    }
}