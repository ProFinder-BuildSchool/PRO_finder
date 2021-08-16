using PRO_finder.Models.DBModel;
using PRO_finder.Models.ViewModels;
using PRO_finder.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PRO_finder.Controllers
{
    public class QuotationController : Controller
    {
        private readonly MemInfoService  _MemInfoService;
        public QuotationController()
        {
            _MemInfoService = new MemInfoService();
        }
        // GET: Quotation
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Detail(int Memberid)
        {
            MemberInfoViewModel MemInfoVM = _MemInfoService.GetMemInfoData(Memberid);
            return View(MemInfoVM);
        }

        public ActionResult StudioHome()
        {
            return View();
        }

        public ActionResult WorksPage()
        {
            return View();
        }

    }
}