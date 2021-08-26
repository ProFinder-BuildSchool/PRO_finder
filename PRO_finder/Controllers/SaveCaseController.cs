using PRO_finder.Models.DBModel;
using PRO_finder.Models.ViewModels;
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
        private readonly CaseService _caseService;
        private readonly SaveCaseService _savecaseService;



        public SaveCaseController()
        {
            _caseService = new CaseService();
            _savecaseService = new SaveCaseService();
            
        }

        public ViewResult Index()
        {
            //List<SaveCaseItemViewModel> SaveCaseItems = (List<SaveCaseItemViewModel>)_savecaseService.GetSaveItemCaseData();
            var SaveCaseViewModel = new SaveCaseViewModel();
            return View(SaveCaseViewModel);
        }

        public ActionResult AddToSaveCase(int CaseID)
        {
            var selectedCase = _caseService.GetCaseDetail().FirstOrDefault(c => c.CaseId == CaseID);

            if (selectedCase != null)
            {
                _savecaseService.AddItemToSaveCase();
            }
            return RedirectToAction("Index");
        }
    }
    
}