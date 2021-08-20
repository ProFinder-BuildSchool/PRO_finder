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

namespace PRO_finder.Service
{
    public class StudioService
        {
        public IEnumerable<WorkPageViewModel> GetWorkpicturesByWorkID(int WorkID)
        {
            var WorkpictureRepository = new GeneralRepository(new WorkPageViewModel());

            return from works in WorkpictureRepository.GetAll<Works>()
                   join workpictures in WorkpictureRepository.GetAll<WorkPictures>()
                   on works.WorkID equals workpictures.WorkID
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
                      // SubCategoryID = works.SubCategoryID,
                       WorkPictureID = workpictures.WorkPictureID,
                       SortNumber = workpictures.SortNumber,
                       WorkPicture = workpictures.WorkPicture
                   };
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
    }
}