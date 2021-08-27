using PRO_finder.Models.ViewModels;
using PRO_finder.Service;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Data.Entity;
using PRO_finder.Models;
using PRO_finder.Repositories;
using Newtonsoft.Json;
using PRO_finder.Model.ViewModels;
using System.Linq;

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
        public ActionResult Index(int? CategoryId, string keyword,string[] filter)
        {

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

            ViewBag.LocationList = _quotService.GetLocationName();
            return View();

        }
        public ActionResult Detail(int Memberid=1,int Quotationid=2019)
        {
            QuotationDetailViewModel QuoDetailVM = _quotService.GetQuoDetailData(Memberid, Quotationid);
            ViewBag.QID = Quotationid;
            return View(QuoDetailVM);
        }

        public ActionResult StudioHome(int MemberID=7)
        {
            ViewBag.StudioInfoList = _studioService.GetStudioInfoByMemberID (MemberID);
            ViewBag.StudioWorkList = _studioService.GetStudioworksByMemberID (MemberID);
            ViewBag.StudioQuotationList = _studioService.GetStudioQuotationByMemberID (MemberID);
            return View();
            //ViewBag.MemberID = MemberID;
            //StudioViewModel StudioInfoVM = _studioService.GetStudioInfoByMemberID(MemberID);
            //var result = _studioService.GetStudioInfoByMemberID().FirstOrDefault(x => x.MemberID == MemberID);
            //ViewBag.StudioReviewList = _studioService.GetCaseReviewByMemberID (MemberID);

        }

        public ActionResult WorksPage(int WorkID = 5)
        {
            
            ViewBag.WorkInfoList = _studioService.GetWorkInfoByWorkID(WorkID);
            ViewBag.WorkPictureList = _studioService.GetWorkpicturesByWorkID(WorkID);
            
            return View();

            //List<WorkPageViewModel> pageData = _studioService.GetWorkPageData (WorkID);
            //return View(pageData);
            //WorkPageViewModel WorkPictureVM = new WorkPageViewModel()
            //{  WorkpictureRepository = _studioService.GetWorkpicturesByWorkID(WorkID)};
        }


        //public ActionResult AllcardData()
        //{
        //    List<QuotationViewModel> allCardData = _quotService.GetAllCardData();
        //    return Json(allCardData, JsonRequestBehavior.AllowGet);
        //}


    }
}