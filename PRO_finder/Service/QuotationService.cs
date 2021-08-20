using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PRO_finder.Repositories;
using PRO_finder.Models.DBModel;
using PRO_finder.Models.ViewModels;
using PRO_finder.Models.ViewModel;

namespace PRO_finder.Service
{
    public class QuotationService
    {
        private readonly QuotationRepository _QuotationRepo;
        private GeneralRepository _ctx;


        public QuotationService()
        {
            _QuotationRepo = new QuotationRepository();
            _ctx = new GeneralRepository(new ProFinderContext());
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
        public QuotationDetailViewModel GetQuoDetailData(int MemId,int QuotationId)
        {
            var MemInfoList = _ctx.GetAll<MemberInfo>();
            var QuoList = _ctx.GetAll<Quotation>();
            var OtherPicList = _ctx.GetAll<OtherPicture>();
    

            if (MemInfoList.Count() == 0 && QuoList.Count()==0 )
            {
                return null;
            }

            IEnumerable<QuotationReview> QuotationReview = new QuotationService().GetQuoReview(QuotationId);
            var QuoDetailVM = (from m in MemInfoList
                               join q in QuoList on m.MemberID equals q.MemberID
                               where m.MemberID == MemId && q.QuotationID == QuotationId
                               select new QuotationDetailViewModel
                               {
                                   Id = m.MemberID,
                                   NickName = m.NickName,
                                   LogInTime = m.LogInTime,
                                   Identity = (QuotationDetailViewModel.IdentityStatus)m.Identity,
                                   SubcategoryId = (int)m.SubCategoryID,
                                   OtherPicture = (from op in OtherPicList
                                                   where op.QuotationID == QuotationId
                                                   select new OtherPictureViewModel
                                                   {
                                                       QuotationID = op.QuotationID,
                                                       MainPicture = op.MainPicture,
                                                       SortNumber = op.SortNumber,
                                                       IsDefault = (op.IsDefault == 0 ? false : true),
                                                       OtherPicture = op.OtherPicture1
                                                   }),
                                   QuotationTitle = q.QuotationTitle,
                                   UpdateDate = q.UpdateDate.ToString(),
                                   ExecuteDate = q.ExecuteDate,
                                   Description = m.Description,
                                   Evaluation = q.Evaluation == null ? (-1) : (decimal)q.Evaluation,
                                   QuotationReview = QuotationReview
                               }
                                 ).FirstOrDefault();

            return QuoDetailVM;
        }

        public IEnumerable<QuotationReview> GetQuoReview(int QuotationId)
        {
            var OrderList = _ctx.GetAll<Order>();
            var MemInfoList = _ctx.GetAll<MemberInfo>();

            var OrderVM = (from o in OrderList
                           join m in MemInfoList on o.DealedTalentMemberID equals m.MemberID
                           where o.SourceID == QuotationId
                           select new QuotationReview
                           {
                               NickName = m.NickName,
                               
                               SubmitDate = o.SubmitDate.ToString(),
                               CaseReview = o.CaseReview,
                               CaseMessage = o.CaseMessage
                           });
            return OrderVM;
        }
    }
}