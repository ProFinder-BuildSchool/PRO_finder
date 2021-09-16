using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PRO_finder.Models.DBModel;
using PRO_finder.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using PRO_finder.Repositories;
using PRO_finder.Models.ViewModels;
using System.Data.Entity;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;

namespace PRO_finder.Service
{


    public class StudioService
    {

        private readonly GeneralRepository _ctx;

        public StudioService()
        {
            _ctx = new GeneralRepository(new ProFinderContext());
        }
        //作品資訊
        public WorkDetailViewModel GetWorkDetailData(int WorkID)
        {
            var WorkList = _ctx.GetAll<Works>();
            var WorkPicList = _ctx.GetAll<WorkPictures>();
            var MemInfoList = _ctx.GetAll<MemberInfo>();

            if (WorkList.Count() == 0)
            {
                return null;
            }
            var WorkPicVM = (from wp in WorkPicList
                             where wp.WorkID == WorkID
                             select new WorkPicturesViewModel
                             {
                                 WorkID = wp.WorkID,
                                 WorkPictureID = wp.WorkPictureID,
                                 SortNumber = wp.SortNumber,
                                 WorkPicture = wp.WorkPicture
                             });
            var WorkDetailVM = (from w in WorkList
                                join m in MemInfoList on w.MemberID equals m.MemberID
                                where w.WorkID == WorkID
                                select new WorkDetailViewModel
                                {
                                    WorkID = w.WorkID,
                                    WorkName = w.WorkName,
                                    WorkDescription = w.WorkDescription,
                                    Client = w.Client,
                                    Role = w.Role,
                                    YearStarted = w.YearStarted,
                                    WebsiteURL = w.WebsiteURL,
                                    SubCategoryID = w.SubCategoryID,
                                    MemberID = m.MemberID,
                                    ProfilePicture = m.ProfilePicture,
                                    NickName = m.NickName,
                                    Identity = m.Identity,
                                    WorkPicture = WorkPicVM
                                    //Evaluation = q.Evaluation == null ? (-1) : (decimal)q.Evaluation,

                                }).FirstOrDefault();

            return WorkDetailVM;
        }


        //工作室資訊

        public StudioDetailViewModel GetStudioDetailData(int MemberID)
        {
            var WorkList = _ctx.GetAll<Works>();
            var WorkPicList = _ctx.GetAll<WorkPictures>();
            var MemInfoList = _ctx.GetAll<MemberInfo>();
            var SubCateList = _ctx.GetAll<SubCategory>();
            var QuotList = _ctx.GetAll<Quotation>();
            var CateList = _ctx.GetAll<Category>();
            var OrderList = _ctx.GetAll<Order>();
            var LocatList = _ctx.GetAll<Locations>();

            if (MemInfoList.Count() == 0)
            {
                return null;
            }

 
            var StudioWorkVM = (from w in WorkList
                                join m in MemInfoList on w.MemberID equals m.MemberID
                                where w.MemberID == MemberID
                                join wp in WorkPicList on w.WorkID equals wp.WorkID
                                where wp.SortNumber == 1
                                join sub in SubCateList on w.SubCategoryID equals sub.SubCategoryID
                                select new StudioworksViewModel
                                {
                                    WorkID = w.WorkID,
                                    WorkName = w.WorkName,
                                    WebsiteURL = w.WebsiteURL,
                                    WorkSubCategory = sub.SubCategoryName,
                                    SubCategoryID=sub.SubCategoryID,
                                    WorkPicture = wp.WorkPicture
                                });
            var WorkSubcategoryVM = (from s in StudioWorkVM
                                     select new WorkSubcategoryViewModel
                                     { 
                                         WorkSubCategory = s.WorkSubCategory,
                                         SubCategoryID = s.SubCategoryID
                                     }).Distinct();
            var StudioQuotVM = (from q in QuotList
                                where q.MemberID == MemberID
                                join sub in SubCateList on q.SubCategoryID equals sub.SubCategoryID
                                join cate in CateList on sub.CategoryID equals cate.CategoryID
                                select new StudioQuotationViewModel
                                {
                                    QuotationId = q.QuotationID,
                                    SubcategoryName = q.QuotationTitle,
                                    CategoryName = cate.CategoryName,
                                    Price = q.Price,
                                    Unit = (StudioQuotationViewModel.UnitEnum)q.QuotationUnit,
                                    QuotationImg = q.MainPicture
                                });

            var StudioReviewVM = (from o in OrderList
                                  join m in MemInfoList on o.ProposerID equals m.MemberID
                                  select new StudioReviewViewModel
                                  {
                                      CaseReview = (decimal)o.CaseReview,
                                      CaseMessage = o.CaseMessage,
                                      CaseReplyMessage = o.CaseReplyMessage,
                                      MemberID = m.MemberID,
                                      NickName = m.NickName
                                  });


            var StudioDetailVM = (from m in MemInfoList
                                  join L in LocatList on m.LocationID equals L.LocationID
                                  where m.MemberID == MemberID
                                  select new StudioDetailViewModel
                                  {
                                      MemberID = m.MemberID,
                                      NickName = m.NickName,
                                      Description = m.Description,
                                      LocationName = L.LocationName,
                                      LogInTime = m.LogInTime,
                                      ProfilePicture = m.ProfilePicture,
                                      Identity = (StudioDetailViewModel.IdentityStatus)m.Identity,
                                      //StudioReview = StudioReviewVM,
                                      Studioworks = StudioWorkVM,
                                      StudioQuotation = StudioQuotVM,
                                      WorkSubcategory = WorkSubcategoryVM

                                  }).FirstOrDefault();

            return StudioDetailVM;
        }





      


        public IEnumerable<SaveStaffViewModel> GetFavorite(int MemberID, int TalentID)
        {
            var SaveStaffList = _ctx.GetAll<SaveStaff>();

            return from savestaff in SaveStaffList
                   where savestaff.MemberID == MemberID && savestaff.SavedTalentID== TalentID


                   select new SaveStaffViewModel
                   {
                       MemberID = savestaff.MemberID,
                       SavedTalentID = savestaff.SavedTalentID,
                       SavedDate = savestaff.SavedDate,
                       SaveStaffID = savestaff.SaveStaffID
                   };

        }
    }

}


       