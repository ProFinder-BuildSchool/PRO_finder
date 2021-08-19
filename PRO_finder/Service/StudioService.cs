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

        private readonly WorkPageRepository _WorkPageRepo;

        public StudioService()
        {
            _WorkPageRepo = new WorkPageRepository();
        }

        public List<WorkPageViewModel> GetWorkPageData(int WorkID)
        {
            List<WorkPageViewModel> WorkVM = _WorkPageRepo.ReadWorkPageData().Where(x => x.WorkID == WorkID).ToList();

            if (WorkVM.Count() == 0)
            {
                return null;
            }

            return WorkVM;
        }

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