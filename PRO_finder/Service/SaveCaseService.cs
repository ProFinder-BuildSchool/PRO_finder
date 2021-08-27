﻿using Microsoft.AspNetCore.Http;
using PRO_finder.Models.DBModel;
using PRO_finder.Models.ViewModels;
using PRO_finder.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
            foreach(var item in saved)
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

        public void AddItemToSaveCase(int CaseID, int MemberID)
        {

            DateTime now = DateTime.UtcNow;
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