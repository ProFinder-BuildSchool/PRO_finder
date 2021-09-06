using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using PRO_finder.Models.DBModel;
using PRO_finder.Models.ViewModels;
using PRO_finder.Repositories;
using PRO_finder.Service;
using PRO_finder.ViewModels;
using Newtonsoft.Json;
using PRO_finder.Helper;

namespace PRO_finder.Controllers
{
    [Authorize]
    public class TalentController : MyControllerBase
    {
        // GET: AccountCenter
        private readonly GeneralRepository _repo;
        private readonly CategoryService _cateService;
        private readonly WorksService _worksService;
        private readonly QuotationService _quotaService;
        private readonly MemberinfoService _memberInfoService;
        private readonly CloudinaryHelper _cloudinaryHelper;

        public TalentController()
        {
            _repo = new GeneralRepository(new ProFinderContext());
            _cateService = new CategoryService();
            _worksService = new WorksService();
            _quotaService = new QuotationService();
            _memberInfoService = new MemberinfoService();
            _cloudinaryHelper = new CloudinaryHelper();
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CreateQuotation()
        {
            ViewBag.CategoryList = _cateService.GetCategorySelectList();
            return View();
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult CreateQuotation([Bind(Include = "QuotationTitle,Price,QuotationUnit,ExecuteDate,Description,SubCategoryID,MainPicture,OtherPictureList")] CreateQuotationViewModel quotation)
        {
            ViewBag.CategoryList = _cateService.GetCategorySelectList();
            if (ModelState.IsValid)
            {
                string userID = HttpContext.User.Identity.GetUserId();
                quotation.MemberID = _memberInfoService.GetMemberID(userID);

                var newQ = _quotaService.CreateQuotation(quotation);
                int quotationID = newQ.QuotationID;
                //Response.Write(quotationID);
                if (quotation.OtherPictureList != null)
                {
                    _quotaService.CreateOtherPics(quotationID, quotation.OtherPictureList);
                }

                return RedirectToAction("Index");
            }
            return View(quotation);
        }
        
        
        public ActionResult UploadMyWorks()
        {
            ViewBag.CategoryList = _cateService.GetCategorySelectList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadMyWorks([Bind(Include = "WorkName, SubCategoryID, Client, Role, YearStarted, WebsiteURL, WorkDescription, WorkAttachmentList, WorkPictureList, WorkAttachmentName, WorkAttachmentLink, Attachments, ")] UploadMyWorksViewModel newWorks)
        {
            //頁面顯示
            ViewBag.CategoryList = _cateService.GetCategorySelectList();

            //取得memberID,並加至newWorks
            string userID = HttpContext.User.Identity.GetUserId();
            newWorks.MemberID = _memberInfoService.GetMemberID(userID);


            if (ModelState.IsValid)
            {
                //存入Works資料庫
                var newEntity = _worksService.CreateWorks(newWorks);
                int workID = newEntity.WorkID;

                //存入WorkAttachment資料庫
                if (newWorks.WorkAttachmentList != null)
                {
                    _worksService.CreateWorkAttachment(workID, newWorks.WorkAttachmentList);
                }

                //存入WorkPictures資料庫
                if (newWorks.WorkPictureList != null)
                {
                    _worksService.CreateWorkPictures(workID, newWorks.WorkPictureList);
                }

                return RedirectToAction("Index");
            }

            return View(newWorks);
        }

        public ActionResult CaseSetting()
        {
            string userID = HttpContext.User.Identity.GetUserId();
            int memberID = _memberInfoService.GetMemberID(userID);
            var memInfo = _memberInfoService.GetMemberInfo(memberID);
            //居住地
            if (memInfo.LiveCity != null)
            {
                var liveCityList = _quotaService.GetLocationSelectList();
                var city = (int)memInfo.LiveCity;
                liveCityList.FirstOrDefault(x => Int32.Parse(x.Value) == city).Selected = true;
                ViewBag.LocationDropdownListForLiveCity = liveCityList;
            }
            else
            {
                ViewBag.LocationDropdownListForLiveCity = _quotaService.GetLocationSelectList();
            }
            //理想接案城市
            if (memInfo.LocationIDInt != null)
            {
                var locaList = _quotaService.GetLocationSelectList();
                var loca = (int)memInfo.LocationIDInt;
                locaList.FirstOrDefault(x => Int32.Parse(x.Value) == loca).Selected = true;
                ViewBag.LocationDropdownList = locaList;
            }
            else
            {
                ViewBag.LocationDropdownList = _quotaService.GetLocationSelectList();
            }
            //理想接案類別
            if(memInfo.SubCategoryID != null)
            {
                var cateList = _cateService.GetCategorySelectList();
                var cateID = _repo.GetAll<SubCategory>().FirstOrDefault(x => x.SubCategoryID == memInfo.SubCategoryID).CategoryID;
                cateList.FirstOrDefault(x => Int32.Parse(x.Value) == cateID).Selected = true;
                ViewBag.IdealCaseCategoryList = cateList;
                ViewBag.IdealSubCategoryID = memInfo.SubCategoryID;
                ViewBag.IdealCategoryID = cateID;
            }
            else
            {
                ViewBag.IdealCaseCategoryList = _cateService.GetCategorySelectList();
            }

            ViewBag.CategoryList = _cateService.GetCategorySelectList();
            ViewBag.ToolList = _memberInfoService.GetToolSelectList();
            return View(memInfo);
        }
        [HttpPost]
        public ActionResult CaseSetting([Bind(Include = "Status, NickName, Identity, LiveCity, Cellphone, Email, JsonToolList, LocationIDInt, SubCategoryID, AllPieceworkExp, JsonExDList, Description")] MemberInfoViewModel caseSettings)
        {
            //view 畫面資料
            //大類別CategoryDropDown
            ViewBag.CategoryList = _cateService.GetCategorySelectList();
            ViewBag.ToolList = _memberInfoService.GetToolSelectList();
            //居住地
            if (caseSettings.LiveCity != null)
            {
                var liveCityList = _quotaService.GetLocationSelectList();
                var city = (int)caseSettings.LiveCity;
                liveCityList.FirstOrDefault(x => Int32.Parse(x.Value) == city).Selected = true;
                ViewBag.LocationDropdownListForLiveCity = liveCityList;
            }
            else
            {
                ViewBag.LocationDropdownListForLiveCity = _quotaService.GetLocationSelectList();
            }
            //理想接案城市
            if (caseSettings.LocationIDInt != null)
            {
                var locaList = _quotaService.GetLocationSelectList();
                var loca = (int)caseSettings.LocationIDInt;
                locaList.FirstOrDefault(x => Int32.Parse(x.Value) == loca).Selected = true;
                ViewBag.LocationDropdownList = locaList;
            }
            else
            {
                ViewBag.LocationDropdownList = _quotaService.GetLocationSelectList();
            }
            //理想接案類別
            if (caseSettings.SubCategoryID != null)
            {
                var cateList = _cateService.GetCategorySelectList();
                var cateID = _repo.GetAll<SubCategory>().FirstOrDefault(x => x.SubCategoryID == caseSettings.SubCategoryID).CategoryID;
                cateList.FirstOrDefault(x => Int32.Parse(x.Value) == cateID).Selected = true;
                ViewBag.IdealCaseCategoryList = cateList;
                ViewBag.IdealSubCategoryID = caseSettings.SubCategoryID;
                ViewBag.IdealCategoryID = cateID;
            }
            else
            {
                ViewBag.IdealCaseCategoryList = _cateService.GetCategorySelectList();
            }


            //取得memberID,並加至newWorks
            string userID = HttpContext.User.Identity.GetUserId();
            int memberID = _memberInfoService.GetMemberID(userID);

            if (ModelState.IsValid)
            {
                //更新MemberInfo資料庫
                _memberInfoService.UpdateMemberInfo(memberID, caseSettings);
                if (caseSettings.JsonExDList != null)
                {
                    //更新Experience資料庫
                    _memberInfoService.UpdateExD(memberID, caseSettings.JsonExDList);
                }

                if (caseSettings.JsonToolList != null)
                {
                    //更新擅長軟體資料庫
                    _memberInfoService.UpdateToolList(memberID, caseSettings.JsonToolList);
                }
                return RedirectToAction("Index");
            }
            return View(caseSettings);
        }
        public ActionResult MyQuotationIndex()
        {
            
            string userID = HttpContext.User.Identity.GetUserId();
            int memberID = _memberInfoService.GetMemberID(userID);
            var myQuotation = _quotaService.GetMyQuotations(memberID).ToList();
            return View(myQuotation);
        }

        public ActionResult UpdateMyQuotation(int? id)
        {
            if (id == null)
            {
                string userID = HttpContext.User.Identity.GetUserId();
                int memberID = _memberInfoService.GetMemberID(userID);
                var myQuotation = _quotaService.GetMyQuotations(memberID).ToList();
                return View("MyQuotationIndex", myQuotation);
            }
            var theQuotation = _quotaService.GetQuotation(id);
            var cateList= _cateService.GetCategorySelectList();
            cateList.FirstOrDefault(x => x.Value == theQuotation.CategoryID.ToString()).Selected = true;
            ViewBag.CategoryList = cateList;
            return View(theQuotation);
        }
        [HttpPost]
        public ActionResult UpdateMyQuotation([Bind(Include = "QuotationID, QuotationTitle,Price,QuotationUnit,ExecuteDate,Description,SubCategoryID,MainPicture,OtherPictureList")] CreateQuotationViewModel quotation)
        {
            if (ModelState.IsValid)
            {
                //更新資料庫
                _quotaService.UpdateQuotation(quotation);

                //重新導向
                string userID = HttpContext.User.Identity.GetUserId();
                int memberID = _memberInfoService.GetMemberID(userID);
                var myQuotation = _quotaService.GetMyQuotations(memberID).ToList();
                return RedirectToAction("MyQuotationIndex", myQuotation);
            }
            return View("Index");
        }

        public ActionResult DeleteQuotation(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            _quotaService.DeleteQ(id);

            string userID = HttpContext.User.Identity.GetUserId();
            int memberID = _memberInfoService.GetMemberID(userID);
            var remainQ = _quotaService.GetMyQuotations(memberID).ToList();
            return View("MyQuotationIndex", remainQ);
        }
        
        public ActionResult ApiTest()
        {
            return View();
        }

        [HttpPost]
        public void UploadFile(HttpPostedFile file)
        {

            HttpPostedFileBase uploadFile = Request.Files["file"] as HttpPostedFileBase;
            if (uploadFile != null && uploadFile.ContentLength > 0)
            {
                string fileSavePath = WebConfigurationManager.AppSettings["UploadPath"];
                string newFileName = string.Concat(Path.GetRandomFileName().Replace(".", ""), Path.GetExtension(uploadFile.FileName).ToLower());
                string fullFilePath = Path.Combine(Server.MapPath(fileSavePath), newFileName);
                uploadFile.SaveAs(fullFilePath);
                Response.Write(fullFilePath);
                return;
            }
            else
            {
                Response.Write("Oops");
            }

        }
        [HttpPost]
        public void UploadCloudinary()
        {
            HttpPostedFileBase file = Request.Files["picture"];
            string url = _cloudinaryHelper.UploadCloudinary(file);
            Response.Write(url);
        }
    }
}