using Microsoft.AspNet.Identity;
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
    public class SaveCaseController : MyControllerBase
    {
        private readonly CaseService _caseService;
        private readonly SaveCaseService _savecaseService;
        private readonly GeneralRepository _repo;


        public SaveCaseController()
        {
            _caseService = new CaseService();
            _savecaseService = new SaveCaseService();
            _repo = new GeneralRepository(new ProFinderContext());
            
        }

        public ViewResult SaveCase()
        {
            string user = HttpContext.User.Identity.GetUserId();
            int MemberID = _repo.GetAll<MemberInfo>().FirstOrDefault(x => x.UserId == user).MemberID;

            var SaveCaseViewModel = _savecaseService.GetSaveCaseData(MemberID);
            return View(SaveCaseViewModel);
        }
        [HttpPost]
        public void AddOrDeleSaveCase(int? caseid)
        {
            string user = HttpContext.User.Identity.GetUserId();
            int MemberID = _repo.GetAll<MemberInfo>().FirstOrDefault(x => x.UserId == user).MemberID;

            
            if (caseid != null )
            {
                _savecaseService.AddOrDeleOfSaveCase(caseid, MemberID);
            }
            
        }
    }
    
}