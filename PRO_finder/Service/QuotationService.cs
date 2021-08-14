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
            List<QuotationViewModel> quotationVM = _QuotationRepo.ReadQuotationData().Where(x =>x.CategoryId == categoryId).ToList();

            if (quotationVM.Count() == 0)
            {
                return null;
            }

            return quotationVM;
        }
    }
}