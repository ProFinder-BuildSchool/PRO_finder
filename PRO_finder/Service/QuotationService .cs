using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PRO_finder.Models.DBModel;
using PRO_finder.Repository;
using PRO_finder.Models.ViewModels;

namespace PRO_finder.Service
{
    public class QuotationService
    {
        private readonly QuotationRepository _QuotationRepo;

        public QuotationService()
        {
            _QuotationRepo = new QuotationRepository();
        }
        //public QuotationViewModel GetQuotationData(int Memid)
        //{

        //    List<Quotation> QuotationList = _QuotationRepo.ReadQuotationData();
        //    if (QuotationList.Count == 0)
        //    {
        //        return null;
        //    }
        //    MemberInfoViewModel QuotationVM = QuotationList.Where(x => x.MemberID == Memid)
        //        .Select(x => new QuotationViewModel
        //        {
        //            MemberID = x.MemberID,
                   

        //        }).FirstOrDefault();
            

        //    return QuotationVM;
        //}

    }
}