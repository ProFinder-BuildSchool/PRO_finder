using PRO_finder.Models.DBModel;
using PRO_finder.Repositories;
using PRO_finder.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PRO_finder.Controllers
{
    public class SaveCaseController : Controller
    {
        private readonly GeneralRepository _repo;
        private readonly CaseService _caseService;

        public SaveCaseController()
        {
            _repo = new GeneralRepository(new ProFinderContext());
            _caseService = new CaseService();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddSaveCase()
        {
            return View();
        }
    }
    
}