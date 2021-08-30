using PRO_finder.Models.ViewModels;
using PRO_finder.Service;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Data.Entity;
using PRO_finder.Models;
using PRO_finder.Repositories;
using Newtonsoft.Json;
using System.Linq;
using System.Configuration;
using System;
using System.Data.SqlClient;
using Dapper;
using PRO_finder.Models.DBModel;
using Microsoft.AspNet.Identity;

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
            //ViewBag.QID = Quotationid;
            return View(QuoDetailVM);
        }

        public ActionResult StudioHome(int TalentID=20)//, int MemberID= 1)
        {
            int currentUserId=20;
            //var result = int.TryParse(System.Web.HttpContext.Current.User.Identity.GetUserId(),out currentUserId);
            StudioDetailViewModel StudioDetailVM = _studioService.GetStudioDetailData (TalentID);
            //IEnumerable<SaveStaffViewModel> favorlist = _studioService.GetFavorite(currentUserId, TalentID);
            ViewBag.TalentID = TalentID;
            ViewBag.UserID = currentUserId;
            //ViewBag.FavorExist = favorlist.Count()!=0; //判斷talent是否存在member的list中
            return View(StudioDetailVM);
        

        }

        public ActionResult WorksPage(int WorkID = 1)
        {

                WorkDetailViewModel WorkDetailVM = _studioService.GetWorkDetailData(WorkID);

                return View(WorkDetailVM);
            
        }


        //public ActionResult AllcardData()
        //{
        //    List<QuotationViewModel> allCardData = _quotService.GetAllCardData();
        //    return Json(allCardData, JsonRequestBehavior.AllowGet);
        //}

        //static string connString = ConfigurationManager.ConnectionStrings["ProFinderContext"].ConnectionString;
        //public ActionResult FavorInsertorDelete(int MemberID, int TalentID, DateTime time, int StaffID, bool AddorRemove)
        //{
        //    int affectedRow = 0; //

        //    using (SqlConnection conn = new SqlConnection(connString))
        //    {
        //        if (AddorRemove)
        //        {
        //            string sql = "Insert into SaveStaff(MemberID, SavedTalentID, SavedDate, SaveStaffID)values( @MemberID, @TalentID, @time, @StaffID)";
        //            affectedRow = conn.Execute(sql, new { MemberID, TalentID, time, StaffID });
        //        }
        //        else
        //        {
        //            string sql = "DELETE FROM SaveStaff WHERE MemberID = @MemberID and SavedTalentID = @SavedTalentID and SaveStaffID=@SaveStaffID";
        //            affectedRow = conn.Execute(sql, new { MemberID = MemberID, SavedTalentID = TalentID, SaveStaffID = StaffID });

        //            //remove from DB
        //        }
        //    }
        //    return  RedirectToAction("StudioHome"); //new EmptyResult();
        //}
    }
}