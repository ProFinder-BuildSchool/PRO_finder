using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using PRO_finder.Models.DBModel;
using PRO_finder.ViewModels;

namespace PRO_finder.Controllers
{
    //[Authorize]
    public class TalentController : Controller
    {
        // GET: AccountCenter
        private readonly ProFinderContext _context;
        public TalentController()
        {
            _context = new ProFinderContext();
        }
        public ActionResult Index()
        {
            //List<TalentIndexViewModel> clientIndex = new List<TalentIndexViewModel>();
            //MemberInfo memberInfo = context.MemberInfoes.FirstOrDefault();
            //var systemContent = context.SystemContents.ToList();
            //List<string> temp = new List<string>();
            //foreach(var item in systemContent)
            //{
            //    temp.Add(item.Content);
            //}
            //clientIndex.Add(new TalentIndexViewModel { Balance = memberInfo.Balance, ContentList = temp});
            //return View(clientIndex);
            return View();
        }
        [HttpGet]
        public ActionResult CreateQuotation()
        {
            //var currentUserId = User.Identity.GetUserId();
            return View();
        }
        [HttpPost]
        public ActionResult CreateQuotation([Bind(Include = "QuotationID, QuotationTitle, Price, QuotationUnit, ExecuteDate, Description, SubCategoryID")] Quotation quotation, [Bind(Include ="WorkAttachmentLink")] WorkAttachment workAttachment)
        {
            if (ModelState.IsValid)
            {
                _context.Quotation.Add(quotation);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(quotation);
        }
        [HttpPost]
        public JsonResult getSubcategoryList(int categoryID)
        {
            _context.Configuration.ProxyCreationEnabled = false;
            List<SubCategory> subcategoryList = _context.SubCategory.Where(x => x.CategoryID == categoryID).ToList();
            return Json(subcategoryList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UploadMyWorks()
        {

            return View();
        }
    }
}