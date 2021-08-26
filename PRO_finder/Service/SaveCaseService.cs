using Microsoft.AspNetCore.Http;
using PRO_finder.Models.DBModel;
using PRO_finder.Models.ViewModels;
using PRO_finder.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static PRO_finder.Models.ViewModels.SaveCaseItemViewModel;

namespace PRO_finder.Service
{
    public class SaveCaseService
    {
        private readonly GeneralRepository _ctx;
        public SaveCaseService()
        {
            _ctx = new GeneralRepository(new ProFinderContext());
        }

        public SaveCaseViewModel GetSaveCase()
        {
            if (System.Web.HttpContext.Current != null)
            {
                if (System.Web.HttpContext.Current.Session["MemberID"] == null)
                {
                    var save = new SaveCaseViewModel();
                    System.Web.HttpContext.Current.Session["MemberID"] = save;
                }
                return (SaveCaseViewModel)HttpContext.Current.Session["MemberID"];
            }
            else
            {
                throw new InvalidOperationException("System.Web.HttpContext.Current為空,請檢查");
            }


        }

        public IEnumerable<SaveCaseViewModel> GetSaveCaseData()
        {
            return from SaveCase in _ctx.GetAll<SaveCase>()
                   join MemberInfo in _ctx.GetAll<MemberInfo>() on SaveCase.MemberID equals MemberInfo.MemberID
                   join Case in _ctx.GetAll<Case>() on SaveCase.CaseID equals Case.CaseID
                   select new SaveCaseViewModel
                   {
                       CaseID = SaveCase.CaseID,
                       SavedDate = SaveCase.SavedDate,
                       MemberID = SaveCase.MemberID
                   };
        }

        public IEnumerable<SaveCaseItemViewModel> GetSaveItemCaseData()
        {
            //DateTime now = DateTime.Now;

            return from Case in _ctx.GetAll<Case>()
                   join MemberInfo in _ctx.GetAll<MemberInfo>() on Case.SubCategoryID equals MemberInfo.SubCategoryID
                   select new SaveCaseItemViewModel
                   {
                       title = Case.CaseTitle,
                       CaseID = Case.CaseID,
                       MemberID = MemberInfo.MemberID,
                       CaseStatus = (int)Case.CaseStatus,
                       Contact = Case.Contact,
                       Price = (SaveCaseItemViewModel.PriceEnum)Case.Price,
                       //SavedDate = now
                   };
        }

        //我是不是需要再開一個SaveCaseItemDB
        public void AddItemToSaveCase()
        {
            int MemberID = _ctx.GetAll<MemberInfo>().ToList().Last().MemberID;
            int CaseID = _ctx.GetAll<Case>().ToList().Last().CaseID;
            DateTime now = DateTime.Now;

            var saveCaseItem = _ctx.GetAll<SaveCaseItemViewModel>()
                .Where(s => s.CaseID == CaseID && s.MemberID== MemberID)
                .Select(s => s)
                .FirstOrDefault();
            if (saveCaseItem == default(SaveCaseItemViewModel))
            {
                SaveCase entity = new SaveCase()
                {
                    CaseID = CaseID,
                    SavedDate = now,
                    MemberID = MemberID

                };
                _ctx.Create(entity);
                _ctx.SaveChanges();
            }
        }

        
    }

    
}