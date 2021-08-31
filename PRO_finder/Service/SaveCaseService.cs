using Microsoft.AspNetCore.Http;
using PRO_finder.Models.DBModel;
using PRO_finder.Models.ViewModels;
using PRO_finder.Repositories;
using System;
using System.Collections.Generic;
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
                    CaseID = item.CaseID,
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
        public void AddItemToSaveCase(int? CaseID, int MemberID)
        {

            DateTime now = DateTime.UtcNow;
            SaveCase entity = new SaveCase()
            {
                CaseID = (int)CaseID,
                SavedDate = now,
                MemberID = MemberID

            };
            _ctx.Create(entity);
            _ctx.SaveChanges();
        }

        public void DeleItemFromSaveCase(int CaseID, int MemberID)
        {

            DateTime now = DateTime.UtcNow;
            SaveCase entity = new SaveCase()
            {
                CaseID = CaseID,
                SavedDate = now,
                MemberID = MemberID

            };
            _ctx.Delete(entity);
            _ctx.SaveChanges();
        }






        //public void AlertWhenSecondPressbtn(int? CaseID, int MemberID)
        //{
        //    SaveCase entity = new SaveCase()
        //    {
        //        CaseID = (int)CaseID,
        //        MemberID = MemberID
        //    };

        //    HttpContext.Current.Response.Write
        //        ("< script  language = 'JavaScript' > alert('已收藏此案件！') </ script >");
        //}

        //public void ClearSaveCase(int CaseID, int MemberID)
        //{
        //    var saved = _ctx.GetAll<SaveCase>().Where(x => x.MemberID == MemberID).Count();
        //    GetSaveCaseData(MemberID).Clear();
        //    _ctx.SaveChanges();

        //}
        //RemoveRange(0,saved)
    }

}


        
    
