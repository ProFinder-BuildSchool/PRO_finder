using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PRO_finder.Models.DBModel;
using PRO_finder.Models.ViewModels;
using PRO_finder.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRO_finder.Service
{

    public class WorksService
    {
        private readonly GeneralRepository _repo;
        public WorksService()
        {
            _repo = new GeneralRepository(new ProFinderContext());
        }
        public Works CreateWorks(UploadMyWorksViewModel input)
        {
            int lastworkID = _repo.GetAll<Works>().ToList().Last().WorkID;
            int newID = lastworkID+1;
            Works entity = new Works()
            {
                WorkID = newID,
                WorkName = input.WorkName,
                WorkDescription = input.WorkDescription,
                Client = input.Client,
                Role = input.Role,
                YearStarted = input.YearStarted,
                WebsiteURL = input.WebsiteURL,
                SubCategoryID = input.SubCategoryID,
                MemberID = input.MemberID
            };
            _repo.Create(entity);
            _repo.SaveChanges();
            return entity;
        }
        public void CreateWorkAttachment(int workID, string attachmentList)
        {
            JArray tempArray = JArray.Parse(attachmentList);
            var parseAttachmentList = tempArray.ToObject<List<WorkAttachment>>();
            foreach(var item in parseAttachmentList)
            {
                WorkAttachment entity = new WorkAttachment
                {
                    WorkID = workID,
                    WorkAttachmentName = item.WorkAttachmentName,
                    WorkAttachmentLink = item.WorkAttachmentLink
                };
                _repo.Create(entity);
                _repo.SaveChanges();
            }
        }

        public void CreateWorkPictures(int workID, string pictureList)
        {
            JArray tempArray = JArray.Parse(pictureList);
            var parsePictureList = tempArray.ToObject<List<WorkPictures>>();
            foreach(var item in parsePictureList)
            {
                WorkPictures entity = new WorkPictures
                {
                    WorkID = workID,
                    WorkPicture = item.WorkPicture,
                    SortNumber = item.SortNumber
                };
                _repo.Create(entity);
                _repo.SaveChanges();
            }
        }



        public List<WorkViewModel> GetWorks_HomeIndex()
        {

            WorkViewModel WorkVM = new WorkViewModel();

            var temp =  (from work in _repo.GetAll<Works>()
                        join workpic in _repo.GetAll<WorkPictures>() on work.WorkID equals workpic.WorkID
                        join S in _repo.GetAll<SubCategory>() on work.SubCategoryID equals S.SubCategoryID
                        select new 
                        {
                            WorkID = work.WorkID,
                            Picture = workpic.WorkPicture,
                            SubCategoryName = S.SubCategoryName,
                            Info = work.WorkDescription,
                            studio = work.Client
                        }).ToList();
            var tempGroup = temp.GroupBy(x => x.WorkID).Select(x => new WorkViewModel {
                WorkID = x.First().WorkID,
                WorkPicture = x.Select(p=>p.Picture).ToList(),
                SubCategoryName = x.First().SubCategoryName,
                Info = x.First().Info,
                studio = x.First().studio
            }).OrderBy(x=>x.WorkID).ToList();

       

            return tempGroup;

        }
      

    }
}