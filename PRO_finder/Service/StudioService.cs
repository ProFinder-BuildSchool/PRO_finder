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
using PRO_finder.Model.ViewModels;
using System.Data.Entity;
using PRO_finder.Models.ViewModels;

namespace PRO_finder.Service
{


    public class StudioService
    {

        private readonly GeneralRepository _repo;
        public StudioService()
        {
            _repo = new GeneralRepository(new ProFinderContext());
        }
        public IEnumerable<WorkPageViewModel> GetWorkpicturesByWorkID(int WorkID)
        {
            var WorkpictureRepository = new GeneralRepository(new ProFinderContext());

            return from works in WorkpictureRepository.GetAll<Works>()
                   join workpictures in WorkpictureRepository.GetAll<WorkPictures>()
                   on works.WorkID equals workpictures.WorkID
                   where works.WorkID == WorkID
                   orderby workpictures.SortNumber
                   select new WorkPageViewModel
                   {
                       WorkID = works.WorkID,
                       WorkPictureID = workpictures.WorkPictureID,
                       SortNumber = workpictures.SortNumber,
                       WorkPicture = workpictures.WorkPicture
                   };
        }

        public IEnumerable<WorkPageViewModel> GetWorkInfoByWorkID(int WorkID)
        {
            var WorkinfoRepository = new GeneralRepository(new ProFinderContext());

            return from works in WorkinfoRepository.GetAll<Works>()
                   join memberinfo in WorkinfoRepository.GetAll<MemberInfo>()
                   on works.MemberID equals memberinfo.MemberID
                   where works.WorkID == WorkID
                   select new WorkPageViewModel
                   {
                       WorkID = works.WorkID,
                       WorkName = works.WorkName,
                       WorkDescription = works.WorkDescription,
                       Client = works.Client,
                       Role = works.Role,
                       YearStarted = works.YearStarted,
                       WebsiteURL = works.WebsiteURL,
                       SubCategoryID = works.SubCategoryID,
                       MemberID = memberinfo.MemberID,
                       ProfilePicture = memberinfo.ProfilePicture,
                       NickName = memberinfo.NickName,
                       Identity = memberinfo.Identity
                   };
        }

        public IEnumerable<StudioViewModel> GetStudioInfoByMemberID(int MemberID)
        {
            var StudioinfoRepository = new GeneralRepository(new ProFinderContext());

            return from mermberinfo in StudioinfoRepository.GetAll<MemberInfo>()
                   join location in StudioinfoRepository.GetAll<Locations>()
                   on mermberinfo.LocationID equals location.LocationID
                   where mermberinfo.MemberID == MemberID
                   //join subcategory in StudioinfoRepository.GetAll<SubCategory>()
                   //on mermberinfo.SubCategoryID equals subcategory.SubCategoryID


                   select new StudioViewModel
                   {
                       MemberID = mermberinfo.MemberID,
                       NickName = mermberinfo.NickName,
                       Description = mermberinfo.Description,
                       LocationName = location.LocationName,
                       LogInTime = mermberinfo.LogInTime,
                       ProfilePicture = mermberinfo.ProfilePicture,
                       //ExpertSubCategory = subcategory.SubCategoryName,
                       Identity = mermberinfo.Identity

                   };
        }

        public IEnumerable<StudioViewModel> GetStudioworksByMemberID(int MemberID)
        {
            var StudioworkRepository = new GeneralRepository(new ProFinderContext());

            return from works in StudioworkRepository.GetAll<Works>()
                   join memberinfo in StudioworkRepository.GetAll<MemberInfo>()
                   on works.MemberID equals memberinfo.MemberID
                   where works.MemberID == MemberID
                   join workpictures in StudioworkRepository.GetAll<WorkPictures>()
                   on works.WorkID equals workpictures.WorkID
                   where workpictures.SortNumber == 3
                   join subcategory in StudioworkRepository.GetAll<SubCategory>()
                   on works.SubCategoryID equals subcategory.SubCategoryID

                   select new StudioViewModel
                   {
                       WorkID = works.WorkID,
                       WorkName = works.WorkName,
                       WebsiteURL = works.WebsiteURL,
                       WorkSubCategory = subcategory.SubCategoryName,
                       MemberID = memberinfo.MemberID,
                       WorkPicture = workpictures.WorkPicture
                   };
        }

        public IEnumerable<StudioViewModel> GetStudioQuotationByMemberID(int MemberID)
        {
            var StudioquotRepository = new GeneralRepository(new ProFinderContext());

            return from quotation in StudioquotRepository.GetAll<Quotation>()
                       //join memberinfo in StudioquotRepository.GetAll<MemberInfo>()
                       //on quotation.MemberID equals memberinfo.MemberID
                   where quotation.MemberID == MemberID
                   //join quotationpicture in StudioquotRepository.GetAll<OtherPicture>()
                   //on quotation.QuotationID equals quotationpicture.QuotationID
                   join subcategory in StudioquotRepository.GetAll<SubCategory>()
                   on quotation.SubCategoryID equals subcategory.SubCategoryID
                   join category in StudioquotRepository.GetAll<Category>()
                   on subcategory.CategoryID equals category.CategoryID



                   select new StudioViewModel
                   {
                       QuotationId = quotation.QuotationID,
                       //QuotationCategoryId = quotation.Category,要用sub反找cate  CategoryName
                       SubcategoryName = subcategory.SubCategoryName,
                       CategoryName = category.CategoryName,
                       Price = quotation.Price,
                       Unit = quotation.QuotationUnit,
                       QuotationImg = quotation.MainPicture
                       //用id去找name SubcategoryName 
                       //WorkName = works.WorkName,
                       //WebsiteURL = works.WebsiteURL,
                       //WorkSubCategoryID = works.SubCategoryID,
                       //MemberID = memberinfo.MemberID,
                       //WorkPicture = workpictures.WorkPicture
                   };

        }

        public IEnumerable<StudioViewModel> GetCaseReviewByMemberID(int MemberID)
        {
            var CaseReviewRepository = new GeneralRepository(new ProFinderContext());

            return from order in CaseReviewRepository.GetAll<Order>()
                   join memberinfo in CaseReviewRepository.GetAll<MemberInfo>()
                   on order.DealedTalentMemberID equals memberinfo.MemberID


                   select new StudioViewModel
                   {
                       CaseReview = order.CaseReview,
                       CaseMessage = order.CaseMessage,
                       CaseReplyMessage = order.CaseReplyMessage,
                       MemberID = memberinfo.MemberID,
                       NickName = memberinfo.NickName



                   };
        }

        public SaveStaff CreateFavorite(StudioViewModel input)
        {

            SaveStaff entity = new SaveStaff()
            {
                MemberID = input.MemberID,
                SavedTalentID = input.SavedTalentID,
                SavedDate = input.SavedDate,
                SaveStaffID = input.SaveStaffID
            };
            _repo.Create(entity);
            _repo.SaveChanges();
            return entity;
        }
        //public IEnumerable<StudioViewModel> PostSaveStaffByMemberID(int MemberID)
        //{
    }    //    var StudioworkRepository = new GeneralRepository(new ProFinderContext());

        //}
}


        //public IEnumerable<WorkPageViewModel> GetWorkdetailAndMemberinfoByWorkID(int WorkID)
        //{
        //    var repository = new GeneralRepository(new WorkPageViewModel());

        //    return from works in repository.GetAll<Works>()
        //           join memberInfo in repository.GetAll<MemberInfo>()
        //           on Works.MemberID equals MemberInfo.MemberID
        //           where selling.SalesJobNumber == jobNumber
        //           && selling.SellingDay >= begin
        //           && selling.SellingDay < end
        //           select new SellingQueryViewModel
        //           {
        //               PartNo = selling.PartNo,
        //               Quantity = selling.Quantity,
        //               SalesJobNumber = selling.SalesJobNumber,
        //               SalesName = sales.Name,
        //               SellingDay = selling.SellingDay,
        //               SellingId = selling.SellingId,
        //               UnitPrice = selling.UnitPrice,
        //               TotalPrice = selling.UnitPrice * selling.Quantity
        //           };
        //}

        //private readonly WorkPageRepository _WorkPageRepo;

        //public StudioService()
        //{
        //    _WorkPageRepo = new WorkPageRepository();
        //}



        //public List<WorkPageViewModel> GetWorkdetailData(int WorkID)
        //{

        //    List<WorkPageViewModel> WorkVM = _WorkPageRepo.ReadWorkPageData().Where(x => x.WorkID == WorkID).ToList();

        //    if (WorkVM.Count() == 0)
        //    {
        //        return null;
        //    }

        //    return WorkVM;
        //}

        //public List<WorkPictures> GetWorkPictures(int WorkID)
        //{
        //    List<WorkPictures> WorkPicturesVM = _WorkPageRepo.ReadSubCateData().Where(x => x.CategoryID == categoryId).ToList();

        //    if (quotationVM.Count() == 0)
        //    {
        //        return null;
        //    }

        //    return quotationVM;
        //}
    