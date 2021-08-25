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
        public IEnumerable<SaveCaseItemViewModel> GetSavedCaseData()
        {
            return from SaveCase in _ctx.GetAll<SaveCase>()
                   join Case in _ctx.GetAll <Case>() on SaveCase.CaseID equals Case.CaseID
                   select new SaveCaseItemViewModel
                   {
                       CaseID = SaveCase.CaseID,
                       title = Case.CaseTitle,
                       Price = (PriceEnum)Case.Price,
                       Contact = Case.Contact,
                       CaseStatus = (int)Case.CaseStatus
                   };
        }
    }
}