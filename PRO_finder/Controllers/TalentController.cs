using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        private readonly CaseService _caseService;

        public TalentController()
        {
            _repo = new GeneralRepository(new ProFinderContext());
            _cateService = new CategoryService();
            _worksService = new WorksService();
            _quotaService = new QuotationService();
            _caseService = new CaseService();
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
                string user = "9bd0253b-8eb3-4cc8-bda6-56602ee86c28";
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
        //[ValidateAntiForgeryToken]
        public ActionResult UploadMyWorks([Bind(Include = "WorkName, SubCategoryID, Client, Role, YearStarted, WebsiteURL, WorkDescription, WorkAttachmentList, WorkPictureList, WorkAttachmentName, WorkAttachmentLink, Attachments, ")] UploadMyWorksViewModel newWorks)
        {
            //頁面顯示
            ViewBag.CategoryList = _cateService.GetCategorySelectList();

            //取得memberID,並加至newWorks
            //string userId = HttpContext.User.Identity.GetUserId();
            string userId = "9bd0253b-8eb3-4cc8-bda6-56602ee86c28";
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
        public ActionResult CaseSetting()
        {
            ViewBag.LocationDropdownList = _quotaService.GetLocationSelectList();
            ViewBag.CategoryList = _cateService.GetCategorySelectList();
            ViewBag.ToolList = _caseService.GetToolSelectList();
            return View();
        }

        //Api 
        public JsonResult GetAllCategoryAndSubCategoryList()
        {
            var subcategoryList = _cateService.GetAllCatAndSubCat();
            return Json(subcategoryList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSubTool()
        {
            var alltool = _caseService.GetJsonSubTool();
            return Json(alltool, JsonRequestBehavior.AllowGet);
        }
    }
}