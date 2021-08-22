using PRO_finder.Models.ViewModels;
using PRO_finder.Service;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Data.Entity;
using PRO_finder.Models;
using PRO_finder.Repositories;
using PRO_finder.Model.ViewModels;

namespace PRO_finder.Controllers
{

    public class QuotationController : Controller
    {
        private readonly QuotationService _quotService;
        private readonly StudioService _studioService;
        private readonly MemInfoService _memInfoService;

        public QuotationController()
        {

            _quotService = new QuotationService();
            _studioService = new StudioService();
            //_memInfoService = new MemInfoService();
        }

        //ProFinderModels ctx = new ProFinderModels();
        // GET: Quotation
        public ActionResult Index(int? CategoryId, string keyword)
        {
            //string Contain = this.TempData["Contain"] as string;

            if (string.IsNullOrEmpty(keyword) && !CategoryId.HasValue)
            {
                ViewBag.pageData = _quotService.GetCategoryPageData(0);
                ViewBag.cateNameList = _quotService.GetsubcatrgotyName(0);
            }


            if (!string.IsNullOrEmpty(keyword))
            {
                ViewBag.pageData = _quotService.GetKeyWordCardData(keyword);
                ViewBag.cateNameList = _quotService.GetsubcatrgotyName(0);
            }

            if (CategoryId.HasValue)
            {
                ViewBag.pageData = _quotService.GetCategoryPageData(CategoryId.Value);
                ViewBag.cateNameList = _quotService.GetsubcatrgotyName(CategoryId.Value);
            }

            return View();

        }
        public ActionResult Detail(int Memberid)
        {
            QuotationViewModel MemInfoVM = new QuotationViewModel()
            {
                MemInfo = _memInfoService.GetMemInfoData(Memberid)
            };
            //ViewBag.QuoDetailTitle = _quotService.GetQuoDetailData(id);
            return View(MemInfoVM);
        }

        public ActionResult StudioHome()
        {
            return View();
        }

        public ActionResult WorksPage(int WorkID = 1)
        {
            List<WorkPageViewModel> pageData = _studioService.GetWorkPageData(WorkID);
            return View(pageData);
        }


        public ActionResult AllcardData()
        {
            List<QuotationViewModel> allCardData = _quotService.GetAllCardData();
            return Json(allCardData, JsonRequestBehavior.AllowGet);
        }


    }
}