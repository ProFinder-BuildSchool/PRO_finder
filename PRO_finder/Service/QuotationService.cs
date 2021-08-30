using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PRO_finder.Repositories;
using PRO_finder.Models.DBModel;
using PRO_finder.Models.ViewModels;
using PRO_finder.ViewModels;
using Newtonsoft.Json;
using System.Web.Mvc;
using PRO_finder.Models.ViewModel;
using static PRO_finder.Models.ViewModels.QuotationViewModel;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Data.SqlClient;

namespace PRO_finder.Service
{
    public class QuotationService
    {
        private readonly GeneralRepository _ctx;
        private readonly GeneralRepository _repo;


        public QuotationService()
        {
            _repo = new GeneralRepository(new ProFinderContext());
            _ctx = new GeneralRepository(new ProFinderContext());
        }

        public List<QuotationViewModel> GetAllCardData()
        {
            var quotationVM = (from q in _ctx.GetAll<Quotation>()
                               join s in _ctx.GetAll<SubCategory>() on q.SubCategoryID equals s.SubCategoryID
                               join m in _ctx.GetAll<MemberInfo>() on q.MemberID equals m.MemberID
                               join l in _ctx.GetAll<Locations>() on m.LocationID equals l.LocationID
                               join c in _ctx.GetAll<Category>() on s.CategoryID equals c.CategoryID
                               select new QuotationViewModel
                               {
                                   QuotationId = q.QuotationID,
                                   CategoryName = c.CategoryName,
                                   Price = (q.Price).ToString(),
                                   Unit = q.QuotationUnit,
                                   StudioName = m.NickName,
                                   Img = q.MainPicture,
                                   CategoryId = s.CategoryID,
                                   SubcategoryId = s.SubCategoryID,
                                   SubcategoryName = s.SubCategoryName,
                                   Location = l.LocationName
                                   

                               }
                   );

            if (quotationVM.Count() == 0)
            {
                return null;
            }


            return quotationVM.ToList();

        }

        public List<QuotationViewModel> GetCategoryPageData(int categoryId)
        {

            var quotationVM = GetAllCardData().Where(x => x.CategoryId == categoryId).ToList();



            if (quotationVM.Count() == 0)
            {
                return null;
            }

            return quotationVM;
        }


        public List<SubCategory> GetsubcatrgotyName(int categoryId)
        {
            List<SubCategory> subCateList = _ctx.GetAll<SubCategory>().ToList();
            List<SubCategory> quotationVM = subCateList.Where(x => x.CategoryID == categoryId).ToList();

            if (quotationVM.Count() == 0)
            {
                return null;
            }

            return quotationVM;
        }

        public List<Locations> GetLocationName()
        {
            List<Locations> LocationList = _ctx.GetAll<Locations>().ToList();

            

            if (LocationList.Count() == 0)
            {
                return null;
            }

            return LocationList;
        }

        public List<QuotationViewModel> GetKeyWordCardData(string keyword)
        {
            var quotationVM = GetAllCardData();

            if (quotationVM.Count() != 0)
            {
                return quotationVM.Where(x => x.SubcategoryName.Contains(keyword)).ToList();
            }

            return null;
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
            var OtherPicVM = (from op in OtherPicList
                              where op.QuotationID == QuotationId
                              select new OtherPictureViewModel
                              {
                                  QuotationID = op.QuotationID,
                                  SortNumber = op.SortNumber,
                                  //IsDefault = (op.IsDefault == 0 ? false : true),
                                  OtherPicture = op.OtherPictureLink
                              });
            var OrderList = _ctx.GetAll<Order>();
            var OrderVM = (from o in OrderList
                           join m in MemInfoList on o.DealedTalentMemberID equals m.MemberID
                           where o.SourceID == QuotationId
                           select new QuotationReview
                           {
                               ReviewName = m.NickName,
                               SubmitDate = o.SubmitDate.ToString(),
                               CaseReview = o.CaseReview,
                               CaseMessage = o.CaseMessage
                           });

            var QuoDetailVM = (from m in MemInfoList
                               join q in QuoList on m.MemberID equals q.MemberID
                               where m.MemberID == MemId && q.QuotationID == QuotationId
                               select new QuotationDetailViewModel
                               {
                                   QuotationId = q.QuotationID,
                                   MemberID = m.MemberID,
                                   NickName = m.NickName,
                                   LogInTime = m.LogInTime.ToString(),
                                   Identity = (QuotationDetailViewModel.IdentityStatus)m.Identity,
                                   //SubcategoryId = (int)m.SubCategoryID,
                                   MainPicture = q.MainPicture,
                                   OtherPicture = OtherPicVM,
                                   QuotationTitle = q.QuotationTitle,
                                   SubcategoryName = q.SubCategoryID.ToString(),
                                   Price = q.Price.ToString(),
                                   UpdateDate = q.UpdateDate.ToString(),
                                   ExecuteDate = q.ExecuteDate,
                                   Description = m.Description,
                                   Evaluation = q.Evaluation == null ? (-1) : (decimal)q.Evaluation,
                                   QuotationReview = OrderVM

                               }).FirstOrDefault();

            return QuoDetailVM;
        }
            

        //刊登新服務 CreateQuotation
        public Quotation CreateQuotation(CreateQuotationViewModel newQ)
        {
            Quotation entity = new Quotation
            {
                QuotationTitle = newQ.QuotationTitle,
                UpdateDate = DateTime.UtcNow,
                QuotationUnit = (int)newQ.QuotationUnit,
                ExecuteDate = newQ.ExecuteDate,
                MemberID = newQ.MemberID,
                Description = newQ.Description,
                SubCategoryID = newQ.SubCategoryID,
                Price = newQ.Price,
                MainPicture = newQ.MainPicture,
            };
            _repo.Create(entity);
            _repo.SaveChanges();
            return entity;
        }

        public void CreateOtherPics(int quotationID, string picList)
        {
            JArray tempArray = JArray.Parse(picList);
            List<OtherPicture> pics = tempArray.ToObject<List<OtherPicture>>();
            foreach(var item in pics)
            {
                OtherPicture p = new OtherPicture
                {
                    QuotationID = quotationID,
                    OtherPictureLink = item.OtherPictureLink,
                    SortNumber = item.SortNumber
                };
                _repo.Create(p);
                _repo.SaveChanges();
            }
        }

        public List<SelectListItem> GetLocationSelectList()
        {
            List<Locations> locationDB = _repo.GetAll<Locations>().ToList();
            List<SelectListItem> locationlist = new List<SelectListItem>();
            locationlist.Add(new SelectListItem { Text = "地區" , Value="-1"});
            foreach (var item in locationDB)
            {
                locationlist.Add(
                    new SelectListItem { Text = item.LocationName, Value = item.LocationID.ToString() });
            }
            return locationlist;
        }

        public IEnumerable<QuotationDetailViewModel> GetMyQuotations(int memberID)
        {
            var temp =  from q in _ctx.GetAll<Quotation>()
                   join s in _ctx.GetAll<SubCategory>() on q.SubCategoryID equals s.SubCategoryID
                   where q.MemberID == memberID
                   select new QuotationDetailViewModel
                   {
                       QuotationId = q.QuotationID,
                       MainPicture = q.MainPicture,
                       SubcategoryId = q.SubCategoryID,
                       SubcategoryName = s.SubCategoryName,
                       CategoryId = s.CategoryID,
                       Price = q.Price.ToString(),
                       Unit = (QuotationDetailViewModel.UnitEnum)q.QuotationUnit,
                       UpdateDateOrigin = q.UpdateDate,
                       QuotationTitle = q.QuotationTitle
                       //Status = q.Status
                   };
            var result = temp.ToList();
            for(int i = 0; i < result.Count(); i++)
            {
                string date = result[i].UpdateDateOrigin.ToString("yyyy-MM-dd");
                result[i].UpdateDate = date;
            }
            return result;
        }

        public void DeleteQ(int? id)
        {
            var theQuotation = _repo.GetAll<Quotation>().FirstOrDefault(x => x.QuotationID == id);
            var pictures = _repo.GetAll<OtherPicture>().Where(x => x.QuotationID == id).ToList();
            _repo.Delete(theQuotation);
            _repo.SaveChanges();

            foreach(var item in pictures)
            {
                _repo.Delete(item);
                _repo.SaveChanges();
            }
            
        }

        public CreateQuotationViewModel GetQuotation(int? id)
        {
            var found = _repo.GetAll<Quotation>().FirstOrDefault(x => x.QuotationID == id);
            string pictures = JsonConvert.SerializeObject(_repo.GetAll<OtherPicture>().Where(x => x.QuotationID == id).ToList());
            var result = new CreateQuotationViewModel
            {
                QuotationID = found.QuotationID,
                QuotationTitle = found.QuotationTitle,
                Price = (decimal)found.Price,
                QuotationUnit = (CreateQuotationViewModel.UnitEnum)found.QuotationUnit,
                ExecuteDate = found.ExecuteDate,
                SubCategoryID = found.SubCategoryID,
                OtherPictureList = pictures,
                CategoryID = _repo.GetAll<SubCategory>().FirstOrDefault(x => x.SubCategoryID == found.SubCategoryID).CategoryID,
                Description = found.Description,
                OtherPicList = _repo.GetAll<OtherPicture>().Where(x => x.QuotationID == id).Select(x => new OtherPictureViewModel
                {
                    QuotationID = x.QuotationID,
                    SortNumber = x.SortNumber,
                    OtherPictureLink = x.OtherPictureLink
                }).ToList()
            };
            return result;
        }

        public void UpdateQuotation(CreateQuotationViewModel quo)
        {
            var entity = _repo.GetAll<Quotation>().FirstOrDefault(x => x.QuotationID == quo.QuotationID);
            entity.QuotationTitle = quo.QuotationTitle;
            entity.UpdateDate = DateTime.UtcNow;
            entity.Price = Math.Round(quo.Price);
            entity.QuotationUnit = (int)quo.QuotationUnit;
            entity.ExecuteDate = quo.ExecuteDate;
            entity.Description = quo.Description;
            entity.SubCategoryID = quo.SubCategoryID;
            entity.MainPicture = quo.MainPicture;
            _repo.Update(entity);
            _repo.SaveChanges();

            if(quo.OtherPictureList != null)
            {
                var oldPictures = _repo.GetAll<OtherPicture>().Where(x => x.QuotationID == quo.QuotationID).ToList();
                foreach(var item in oldPictures)
                {
                    _repo.Delete(item);
                    _repo.SaveChanges();
                }
                JArray temp = JArray.Parse(quo.OtherPictureList);
                List<OtherPicture> newPictureList = temp.ToObject<List<OtherPicture>>();
                foreach (var item in newPictureList)
                {
                    OtherPicture p = new OtherPicture
                    {
                        QuotationID = quo.QuotationID,
                        OtherPictureLink = item.OtherPictureLink,
                        SortNumber = item.SortNumber
                    };
                    _repo.Create(p);
                    _repo.SaveChanges();
                }

            }

        }
    }
}