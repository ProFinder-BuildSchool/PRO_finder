﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PRO_finder.Repositories;
using PRO_finder.Models.DBModel;
using PRO_finder.Models.ViewModels;
using PRO_finder.ViewModels;
using Newtonsoft.Json;
using System.Web.Mvc;

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

        public List<QuotationViewModel> GetCategoryPageData(int categoryId)
        {

            var quotationVM = (from q in _ctx.GetAll<Quotation>()
                               join o in _ctx.GetAll<OtherPicture>() on q.OtherPictureID equals o.OtherPictureID
                               join s in _ctx.GetAll<SubCategory>() on q.SubCategoryID equals s.SubCategoryID
                               join m in _ctx.GetAll<MemberInfo>() on q.MemberID equals m.MemberID
                               join l in _ctx.GetAll<Locations>() on m.LocationID equals l.LocationID
                               join c in _ctx.GetAll<Category>() on s.CategoryID equals c.CategoryID
                               select new QuotationViewModel
                               {
                                   Id = q.QuotationID,
                                   CategoryName = c.CategoryName,
                                   Price = (q.Price).ToString(),
                                   Unit = q.QuotationUnit,
                                   StudioName = m.NickName,
                                   Img = o.MainPicture,
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

            return quotationVM.Where(x => x.CategoryId == categoryId).ToList();
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

        public List<QuotationViewModel> GetKeyWordCardData(string keyword)
        {
            var quotationVM = (from q in _ctx.GetAll<Quotation>()
                               join o in _ctx.GetAll<OtherPicture>() on q.OtherPictureID equals o.OtherPictureID
                               join s in _ctx.GetAll<SubCategory>() on q.SubCategoryID equals s.SubCategoryID
                               join m in _ctx.GetAll<MemberInfo>() on q.MemberID equals m.MemberID
                               join l in _ctx.GetAll<Locations>() on m.LocationID equals l.LocationID
                               join c in _ctx.GetAll<Category>() on s.CategoryID equals c.CategoryID
                               select new QuotationViewModel
                               {
                                   Id = q.QuotationID,
                                   CategoryName = c.CategoryName,
                                   Price = (q.Price).ToString(),
                                   Unit = q.QuotationUnit,
                                   StudioName = m.NickName,
                                   Img = o.MainPicture,
                                   CategoryId = s.CategoryID,
                                   SubcategoryId = s.SubCategoryID,
                                   SubcategoryName = s.SubCategoryName,
                                   Location = l.LocationName

                               }
                               );

            if (quotationVM.Count() != 0)
            {
                return quotationVM.Where(x => x.SubcategoryName.Contains(keyword)).ToList();
            }

                return null;
        }

        public List<QuotationViewModel> GetAllCardData()
        {
            var quotationVM = (from q in _ctx.GetAll<Quotation>()
                               join o in _ctx.GetAll<OtherPicture>() on q.OtherPictureID equals o.OtherPictureID
                               join s in _ctx.GetAll<SubCategory>() on q.SubCategoryID equals s.SubCategoryID
                               join m in _ctx.GetAll<MemberInfo>() on q.MemberID equals m.MemberID
                               join l in _ctx.GetAll<Locations>() on m.LocationID equals l.LocationID
                               join c in _ctx.GetAll<Category>() on s.CategoryID equals c.CategoryID
                               select new QuotationViewModel
                               {
                                   Id = q.QuotationID,
                                   CategoryName = c.CategoryName,
                                   Price = (q.Price).ToString(),
                                   Unit = q.QuotationUnit,
                                   StudioName = m.NickName,
                                   Img = o.MainPicture,
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

        //報價細節
        public QuotationViewModel GetQuoDetailData(int MemId,int QuotationId)
        {
            //List<QuotationViewModel> QuoDetailList = _QuotationRepo.ReadQuoDetailData().ToList();
            //if (QuoDetailList.Count() == 0)
            //{
            //    return null;
            //}
            //QuotationViewModel QuoDetailVM = (QuotationViewModel)QuoDetailList.Where(x => x.Id == id)
            //    .Select(x => new QuotationViewModel
            //    {

            //    });

            return null;
        }

        //刊登新服務 CreateQuotation
        public Quotation CreateQuotation(CreateQuotationViewModel newQ, DateTime now)
        {
            Quotation entity = new Quotation
            {
                QuotationTitle = newQ.QuotationTitle,
                //UpdateDate = now,
                QuotationUnit = (int)newQ.QuotationUnit,
                ExecuteDate = newQ.ExecuteDate,
                MemberID = newQ.MemberID,
                Description = newQ.Description,
                SubCategoryID = newQ.SubCategoryID,
                Price = newQ.Price,
                //MainPicture = newQ.MainPicture
            };
            _repo.Create(entity);
            _repo.SaveChanges();
            return entity;
        }

        public void CreateOtherPics(int quotationID, string picList)
        {
            List<OtherPicture> pics = (List<OtherPicture>)JsonConvert.DeserializeObject(picList);
            foreach(var item in pics)
            {
                OtherPicture p = new OtherPicture
                {
                    QuotationID = quotationID,
                    OtherPicture1 = item.OtherPicture1,
                    //OtherPictureLink = item.OtherPictureLink,
                    SortNumber = item.SortNumber
                };
                _repo.Create(p);
                _repo.SaveChanges();
            }
        }

        public List<SelectListItem> GetLocationList()
        {
            List<Locations> locationDB = _repo.GetAll<Locations>().ToList();
            List<SelectListItem> locationlist = new List<SelectListItem>();
            locationlist.Add(new SelectListItem { Text = "地區" });
            foreach (var item in locationDB)
            {
                locationlist.Add(
                    new SelectListItem { Text = item.LocationName, Value = item.LocationID.ToString() });
            }
            return locationlist;
        }
    }
}