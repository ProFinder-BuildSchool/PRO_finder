using Microsoft.AspNet.Identity;
using PRO_finder.Models.DBModel;
using PRO_finder.Models.ViewModels;
using PRO_finder.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace PRO_finder.Controllers
{
    public class FindQuotationController : MyControllerBase
    
    {
        private readonly CategoryService _categoryService;
        private readonly CaseService _caseService;
        private readonly MemberinfoService _memberinfoService;
        private readonly CartService _cartService;

        public FindQuotationController()
        {
            _caseService = new CaseService();
            _categoryService = new CategoryService();
            _memberinfoService = new MemberinfoService();
            _cartService = new CartService();
        }

        [HttpGet]
        // GET: FindQuotation
        public ActionResult Index(string id = "0", string searchStr = null)
        {

            ViewBag.CateId = id;
            List<CaseViewModel> result = new List<CaseViewModel>();
            if (string.IsNullOrEmpty(id))
            {
                result = _caseService.GetCasesList().ToList();

            }
            else if (string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(searchStr))
            {
                result = _caseService.GetCasesList().Where(x => x.Description.Contains(searchStr)).ToList();

            }
            else if (!string.IsNullOrEmpty(id) && string.IsNullOrEmpty(searchStr))
            {
                result = _caseService.GetCasesList().Where(x => x.CategoryID == Int32.Parse(id)).ToList();
            }
            else if (!string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(searchStr))
            {
                result = _caseService.GetCasesList().Where(x => x.CategoryID == Int32.Parse(id) && x.Description.Contains(searchStr)).ToList();
            }


            return View(result);
        }





        [Authorize]
        public ActionResult Detail(int id = 1 )
        {
            string user = HttpContext.User.Identity.GetUserId();
            int memberID = _memberinfoService.GetMemberID(user);

            ViewBag.CateId = id;
            var result = _caseService.GetCaseDetail(id, memberID);
            return View(result);

        }

        public ActionResult Othercase(string Cateid)
        {
            var result = _caseService.GetOtherCase().Where(x => x.CategoryID == Int32.Parse(Cateid)).ToList
                ();

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        

        public ActionResult FindCategory(string categoryName)
        {
            ViewBag.CateId = "0";
            List<CaseViewModel> result = new List<CaseViewModel>();
            int id = _categoryService.GetCategoryID(categoryName);
            if (id == -1)
            {
                result = _caseService.GetCasesList().Where(x => x.CategoryID == id).ToList();
            }

            result = _caseService.GetCasesList().Where(x => x.CategoryID == id).ToList();
            return View("Index", result);
        }
        public ActionResult CaseSearch(string content)
        {
            ViewBag.CateId = "0";
            List<CaseViewModel> result = new List<CaseViewModel>();
            result = _caseService.GetCasesList().Where(x => x.Description.Contains(content)).ToList();
            return View("Index", result);
        }
      

    }
}