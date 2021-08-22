using PRO_finder.Models.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using PRO_finder.Models.ViewModels;
using System.Globalization;
using PRO_finder.Model.ViewModels;

namespace PRO_finder.Repositories
{
    public class WorkPageRepository
    {
        private readonly ProFinderContext _ctx;
        public WorkPageRepository()
        {
            _ctx = new ProFinderContext();
        }
        public IEnumerable<WorkPageViewModel> ReadWorkPageData()
        {
            var workpageList = (from w in _ctx.Works
                                join wp in _ctx.WorkPictures on w.WorkID equals wp.WorkID


                                //join l in _ctx.Locations on q.LocationID equals l.LocationID
                                select new WorkPageViewModel
                                {
                                    WorkID = w.WorkID,
                                    WorkName = w.WorkName,
                                    WorkDescription = w.WorkDescription,
                                    Client = w.Client,
                                    Role = w.Role,
                                    YearStarted = w.YearStarted,
                                    WebsiteURL = w.WebsiteURL,
                                    SubCategoryID = w.SubCategoryID,
                                    WorkPictureID = wp.WorkPictureID,
                                    SortNumber = wp.SortNumber,
                                    WorkPicture = wp.WorkPicture
                                    //MemberID=,
                                    //ProfilePicture=,
                                    //NickName=,
                                    //TalentCategoryID=,
                                    //Identity=

                                }
                             );

            return workpageList;
        }

        //public List<WorkPictures> ReadWorkPicturesData(int WorkID)
        //{
        //    //var workpicturesList = (from w in _ctx.Works
        //    //                    join wp in _ctx.WorkPictures on w.WorkID equals wp.WorkID
        //    //List<WorkPictures> WorkPicturesList = _ctx.SubCategory.ToList();

        //   // return workpicturesList;
        //}
    }


}

