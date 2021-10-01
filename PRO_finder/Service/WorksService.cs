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
        private readonly WorkRepository _repo;
        
        public WorksService()
        {
            _repo = new WorkRepository(new ProFinderContext());
        }
        public void CreateWorks(UploadMyWorksViewModel input)
        {
            int lastworkID = _repo.GetAll<Works>().OrderBy(x => x.WorkID).ToList().Last().WorkID;
            int newID = lastworkID + 1;
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

            List<WorkPictures> pictures = new List<WorkPictures>();
            int lastPicID = _repo.GetAll<WorkPictures>().OrderBy(x => x.WorkPictureID).ToList().Last().WorkPictureID;
            int newPicID = lastPicID + 1;
            for (int i = 0; i < input.WorkPictureList.Count; i++)
            {
                pictures.Add(new WorkPictures
                {
                    WorkPictureID = newPicID,
                    WorkID = newID,
                    SortNumber = i,
                    WorkPicture = input.WorkPictureList[i].WorkPicture
                });
                newPicID++;
            }

            List<WorkAttachment> attachments = new List<WorkAttachment>();
            int lastAttachmentID = _repo.GetAll<WorkAttachment>().OrderBy(x => x.WorkAttachmentID).ToList().Last().WorkAttachmentID;
            int newAttID = lastAttachmentID + 1;
            for(int j = 0; j < input.WorkAttachmentList.Count; j++)
            {
                attachments.Add(new WorkAttachment
                {
                    WorkAttachmentID = newAttID,
                    WorkID = newID,
                    WorkAttachmentName = input.WorkAttachmentList[j].WorkAttachmentName,
                    WorkAttachmentLink = input.WorkAttachmentList[j].WorkAttachmentLink
                });
                newAttID++;
            }
            _repo.CreateNewWork(entity, pictures, attachments);
        }
        
        public List<WorkViewModel> GetWorks_HomeIndex()
        {

            WorkViewModel WorkVM = new WorkViewModel();

            var temp = (from work in _repo.GetAll<Works>()
                        join workpic in _repo.GetAll<WorkPictures>() on work.WorkID equals workpic.WorkID
                        join S in _repo.GetAll<SubCategory>() on work.SubCategoryID equals S.SubCategoryID
                        where work.Featured == 1
                        select new
                        {
                            WorkID = work.WorkID,
                            Picture = workpic.WorkPicture,
                            SubCategoryName = S.SubCategoryName,
                            Info = work.WorkDescription,
                            studio = work.Client,
                            MemberID = work.MemberID,
                            Memo = work.Memo
                        }).ToList();
            var tempGroup = temp.GroupBy(x => x.WorkID).Select(x => new WorkViewModel
            {
                WorkID = x.First().WorkID,
                WorkPicture = x.Select(p => p.Picture).ToList(),
                SubCategoryName = x.First().SubCategoryName,
                Info = x.First().Info,
                studio = x.First().studio,
                MemberID = (int)x.First().MemberID,
                Memo =x.First().Memo
                
            }).OrderBy(x => x.WorkID).ToList();



            return tempGroup;

        }

       
    }
}