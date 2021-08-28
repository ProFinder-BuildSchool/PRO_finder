﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

namespace PRO_finder.Controllers
{
    //[Authorize]
    public class TalentController : Controller
    {
        // GET: AccountCenter
        private readonly GeneralRepository _repo;
        private readonly CategoryService _cateService;
        private readonly WorksService _worksService;
        private readonly QuotationService _quotaService;
        //private readonly CaseService _caseService;
        private readonly MemberinfoService _memberInfoService;

        public TalentController()
        {
            _repo = new GeneralRepository(new ProFinderContext());
            _cateService = new CategoryService();
            _worksService = new WorksService();
            _quotaService = new QuotationService();
            //_caseService = new CaseService();
            _memberInfoService = new MemberinfoService();
        }

        public ActionResult Index()
        {
            return View();
        }

        //[HttpGet]
        public ActionResult CreateQuotation()
        {
            //var currentUserId = User.Identity.GetUserId();
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
                //string user = HttpContext.User.Identity.GetUserId();
                string user = "64547da8-0789-42f7-a193-e001cec76873";
                quotation.MemberID = _repo.GetAll<MemberInfo>().FirstOrDefault(x => x.UserId == user).MemberID;

                var newQ = _quotaService.CreateQuotation(quotation);
                int quotationID = newQ.QuotationID;

                if (quotation.OtherPictureList != null)
                {
                    _quotaService.CreateOtherPics(quotationID, quotation.OtherPictureList);
                }

                return RedirectToAction("Index");
            }
            return View(quotation);
        }



        [HttpGet]
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
            //string userId = HttpContext.User.Identity.GetUserId();
            string userId = "64547da8-0789-42f7-a193-e001cec76873";
            newWorks.MemberID = _repo.GetAll<MemberInfo>().FirstOrDefault(x => x.UserId == userId).MemberID;


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
        //[HttpPost] 
        //public ActionResult UploadMyWorks(IEnumerable<HttpPostedFileBase> WorkAttachmentLink)
        //{
        //    foreach(var file in WorkAttachmentLink)
        //    {
        //        if(file != null && file.ContentLength > 0)
        //        {
        //            var fileName = Path.GetFileName(file.FileName);
        //            var path = Path.Combine(Server.MapPath("~/WorkAttachments"), fileName);
        //            file.SaveAs(path);
        //        }
        //    }
        //    return Content("ok");
        //}

        public ActionResult CaseSetting()
        {

            
            string userId = "64547da8-0789-42f7-a193-e001cec76873";
            var memInfo = _repo.GetAll<MemberInfo>().FirstOrDefault(x => x.UserId == userId);
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

            if (memInfo.LocationID != null)
            {
                var locaList = _quotaService.GetLocationSelectList();
                var loca = (int)memInfo.LocationID;
                locaList.FirstOrDefault(x => Int32.Parse(x.Value) == loca).Selected = true;
                ViewBag.LocationDropdownList = locaList;
            }
            else
            {
                ViewBag.LocationDropdownList = _quotaService.GetLocationSelectList();
            }

            if(memInfo.SubCategoryID != null)
            {
                var cateList = _cateService.GetCategorySelectList();
                var cateID = _repo.GetAll<SubCategory>().FirstOrDefault(x => x.SubCategoryID == memInfo.SubCategoryID).CategoryID;
                cateList.FirstOrDefault(x => Int32.Parse(x.Value) == cateID).Selected = true;
                ViewBag.IdealCaseCategoryList = cateList;
                ViewBag.IdealSubCategoryID = memInfo.SubCategoryID;
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
        public ActionResult CaseSetting([Bind(Include = "Status, NickName, Identity, LiveCity, Cellphone, Email, JsonToolList, LocationID, SubCategoryID, AllPieceworkExp, JsonExDList, Description")] MemberInfoViewModel caseSettings)
        {
            //view 畫面資料
            ViewBag.CategoryList = _cateService.GetCategorySelectList();
            ViewBag.ToolList = _memberInfoService.GetToolSelectList();
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
            //
            if (caseSettings.LocationID != null)
            {
                var locaList = _quotaService.GetLocationSelectList();
                var loca = (int)caseSettings.LocationID;
                locaList.FirstOrDefault(x => Int32.Parse(x.Value) == loca).Selected = true;
                ViewBag.LocationDropdownList = locaList;
            }
            else
            {
                ViewBag.LocationDropdownList = _quotaService.GetLocationSelectList();
            }
            //
            if (caseSettings.SubCategoryID != null)
            {
                var cateList = _cateService.GetCategorySelectList();
                var cateID = _repo.GetAll<SubCategory>().FirstOrDefault(x => x.SubCategoryID == caseSettings.SubCategoryID).CategoryID;
                cateList.FirstOrDefault(x => Int32.Parse(x.Value) == cateID).Selected = true;
                ViewBag.IdealCaseCategoryList = cateList;
                ViewBag.IdealSubCategoryID = caseSettings.SubCategoryID;
            }
            else
            {
                ViewBag.IdealCaseCategoryList = _cateService.GetCategorySelectList();
            }


            //取得memberID,並加至newWorks
            //string userId = HttpContext.User.Identity.GetUserId();
            string userID = "64547da8-0789-42f7-a193-e001cec76873";
            int memberID = _repo.GetAll<MemberInfo>().FirstOrDefault(x => x.UserId == userID).MemberID;


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


        //Api 
        public JsonResult GetAllCategoryAndSubCategoryList()
        {
            var subcategoryList = _cateService.GetAllCatAndSubCat();
            return Json(subcategoryList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSubTool()
        {
            var alltool = _memberInfoService.GetJsonSubTool();
            return Json(alltool, JsonRequestBehavior.AllowGet);
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
    }
}