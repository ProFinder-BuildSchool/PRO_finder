using Newtonsoft.Json;
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
            Works entity = new Works()
            {
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
            var parseAttachmentList = (List<WorkAttachment>)JsonConvert.DeserializeObject(attachmentList);
            foreach(var item in parseAttachmentList)
            {
                WorkAttachment entity = new WorkAttachment
                {
                    //WorkID = workID,
                    WorkAttachmentName = item.WorkAttachmentName,
                    WorkAttachmentLink = item.WorkAttachmentLink
                };
                _repo.Create(entity);
                _repo.SaveChanges();
            }
        }

        public void CreateWorkPictures(int workID, string pictureList)
        {
            var parsePictureList = (List<WorkPictures>)JsonConvert.DeserializeObject(pictureList);
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
        
    }
}