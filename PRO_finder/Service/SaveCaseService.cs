using Microsoft.AspNetCore.Http;
using PRO_finder.Models.DBModel;
using PRO_finder.Models.ViewModels;
using PRO_finder.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using HttpContext = System.Web.HttpContext;
using HttpResponse = System.Web.HttpResponse;

namespace PRO_finder.Service
{
    public class SaveCaseService
    {
        private readonly GeneralRepository _ctx;
        public SaveCaseService()
        {
            _ctx = new GeneralRepository(new ProFinderContext());
        }

        public List<SaveCaseViewModel> GetSaveCaseData(int MemberID)
        {
            List<SaveCaseViewModel> saveCases = new List<SaveCaseViewModel>();
            var saved = _ctx.GetAll<SaveCase>().Where(x => x.MemberID == MemberID).ToList();
            foreach (var item in saved)
            {
                Case theCase = _ctx.GetAll<Case>().FirstOrDefault(x => x.CaseID == item.CaseID);
                saveCases.Add(new SaveCaseViewModel
                {
                    CaseID = (int)item.CaseID,
                    SavedDate = item.SavedDate,
                    MemberID = MemberID,
                    title = theCase.CaseTitle,
                    CaseStatus = (int)theCase.CaseStatus,
                    Contact = theCase.Contact,
                    Price = (SaveCaseViewModel.PriceEnum)theCase.Price
                });
            }

            return saveCases;
        }
        public void AddOrDeleOfSaveCase(int? CaseID, int MemberID)
        {
            var SaveCase = _ctx.GetAll<SaveCase>()
                .SingleOrDefault(s => s.CaseID == CaseID && s.MemberID == MemberID);
            
            if (SaveCase == null)
            {
                DateTime now = DateTime.UtcNow;
                SaveCase  = new SaveCase()
                {
                CaseID = (int)CaseID,
                SavedDate = now,
                MemberID = MemberID
                };
                _ctx.Create(SaveCase);
                _ctx.SaveChanges();
            }
            else
            {
                _ctx.Delete(SaveCase);
                _ctx.SaveChanges();
            }
        }
    }

}


        
    
