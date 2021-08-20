using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PRO_finder.Repositories;
using PRO_finder.Models.DBModel;
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

        public List<QuotationViewModel> GetCategoryPageData(int categoryId)
        {
            List<QuotationViewModel> quotationVM = _QuotationRepo.ReadQuotationData().Where(x => x.CategoryId == categoryId).ToList();

            if (quotationVM.Count() == 0)
            {
                return null;
            }

            return quotationVM;
        }

        public List<SubCategory> GetsubcatrgotyName(int categoryId)
        {
            List<SubCategory> quotationVM = _QuotationRepo.ReadSubCateData().Where(x => x.CategoryID == categoryId).ToList();

            if (quotationVM.Count() == 0)
            {
                return null;
            }

            return quotationVM;
        }

        public List<QuotationViewModel> GetAllCardData()
        {
            List<QuotationViewModel> quotationVM = _QuotationRepo.ReadQuotationData().ToList();

            if (quotationVM.Count() == 0)
            {
                return null;
            }

            return quotationVM;
        }

        //報價細節
        public QuotationViewModel GetQuoDetailData(int MemId,int QuotationId)
        {
            //List<QuotationViewModel> QuoDetailList = _QuotationRepo.ReadQuoDetailData().ToList();
            //if (QuoDetailList.Count() == 0)
            //{
            //    return null;
            //}
            //QuotationViewModel QuoDetailVM = (QuotationViewModel)QuoDetailList.Where(x => x.Id == id)
            //    .Select(x => new QuotationViewModel
            //    {

            //    });

            return null;
        }
    }
}