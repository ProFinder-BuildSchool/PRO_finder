using Newtonsoft.Json;
using PRO_finder.Models.DBModel;
using PRO_finder.Models.ViewModels;
using PRO_finder.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using PRO_finder.Helper;
using PRO_finder.ViewModels;

namespace PRO_finder.Service
{
    public class CaseService
    {
        private readonly CaseRepository _ctx;
        

        public CaseService()
        {

            _ctx = new CaseRepository(new ProFinderContext());

           
        }


        public List<CaseViewModel> GetFinishCases()
        {
            var temp = GetCasesList().Where(x=>x.CaseStatus == 6).ToList();

            foreach (var item in temp)
            {


                if (temp.IndexOf(item) <= 3)
                {
                    item.SortNum = 1;
                }
                else if (temp.IndexOf(item) > 3 && temp.IndexOf(item) <= 7)
                {
                    item.SortNum = 2;
                }
                else if (temp.IndexOf(item) > 7 && temp.IndexOf(item) <= 11)
                {
                    item.SortNum = 3;
                }
            }

            return temp;
        }

        public List<CaseViewModel> GetCasesList()
        {
           var temp = (from Case in _ctx.GetAll<Case>()
                   join MemberInfo in _ctx.GetAll<MemberInfo>() on Case.MemberID equals MemberInfo.MemberID
                   join SubCategory in _ctx.GetAll<SubCategory>() on Case.SubCategoryID equals SubCategory.SubCategoryID
                   join Locations in _ctx.GetAll<Locations>() on Case.Location equals Locations.LocationID
                   join Category in _ctx.GetAll<Category>() on SubCategory.CategoryID equals Category.CategoryID
                   select new CaseViewModel
                   {
                       CaseStatus = (int)Case.CaseStatus,
                       CaseId = Case.CaseID,
                       title = Case.CaseTitle,
                       Price = (int)Case.Price,
                       LocationID = (int)Case.Location,
                       LocationName = Locations.LocationName,
                       SubCategoryID = SubCategory.SubCategoryID,
                       Description = Case.Description,
                       UpdateDate = (DateTime)Case.UpdateDate,
                       SubCategoryName = SubCategory.SubCategoryName,
                       CategoryID = SubCategory.CategoryID
                   }).ToList();

            foreach(var item in temp)
            {
                item.DiffDateTime = DateToString.TransDate(item.UpdateDate);
            }
            foreach (var item in temp)
            {
                item.PriceToString = PriceToRange(item.Price);
            }







            return temp;
        }

        public static string PriceToRange(int? priceNum)
        {
            switch (priceNum)
            {
                case 1:
                    return "5000元以下";
                case 2:
                    return "5001~10000元";
                case 3:
                    return "10001~50000元";
                case 4:
                    return "50001~100000元";
                case 5:
                    return "100001~300000元";
                default:
                    return "查無資料";
            }
        }


        public CaseDetailViewModel GetCaseDetail(int caseID,int memberID)
        {
            var savedData = _ctx.GetAll<SaveCase>().FirstOrDefault(x => x.CaseID == caseID && x.MemberID == memberID);
            bool savedOrNot = false;
            if (savedData != null)
            {
                savedOrNot = true;
            }

            return  ( from Case in _ctx.GetAll<Case>()
                             join SubCategory in _ctx.GetAll<SubCategory>() on Case.SubCategoryID equals SubCategory.SubCategoryID
                             join Locations in _ctx.GetAll<Locations>() on Case.Location equals Locations.LocationID
                             where Case.CaseID == caseID
                   select new CaseDetailViewModel
                   {
                       title = Case.CaseTitle,
                       CaseId = Case.CaseID,
                       LocationID = (int)Case.Location,
                       LocationName = Locations.LocationName,
                       Price = (CaseDetailViewModel.PriceEnum)Case.Price,
                       CompleteDate = Case.CompleteDate,
                       Type = (CaseDetailViewModel.TypeEnum)(TypeEnum)Case.Type,
                       Description = Case.Description,
                       Contact = Case.Contact,
                       ContactTime = Case.ContactTime,
                       LocalCallsCode = Case.LocalCallsCode,
                       LocalCalls = Case.LocalCalls,
                       ContactEmail = Case.ContactEmail,
                       LineID = Case.LineID,
                       CategoryID = SubCategory.CategoryID,
                       SubCategoryName = SubCategory.SubCategoryName,
                       SavedOrNot = savedOrNot
                   }).FirstOrDefault();
        }

        public IEnumerable<CaseDetailViewModel> GetOtherCase()
        {
            

            return from Case in _ctx.GetAll<Case>()
                    join SubCategory in _ctx.GetAll<SubCategory>() on Case.SubCategoryID equals SubCategory.SubCategoryID
                    join Locations in _ctx.GetAll<Locations>() on Case.Location equals Locations.LocationID
                    
                    select new CaseDetailViewModel
                    {
                        title = Case.CaseTitle,
                        CaseId = Case.CaseID,
                        LocationID = (int)Case.Location,
                        LocationName = Locations.LocationName,
                        Price = (CaseDetailViewModel.PriceEnum)Case.Price,
                        CompleteDate = Case.CompleteDate,
                        Type = (CaseDetailViewModel.TypeEnum)(TypeEnum)Case.Type,
                        Description = Case.Description,
                        Contact = Case.Contact,
                        ContactTime = Case.ContactTime,
                        LocalCallsCode = Case.LocalCallsCode,
                        LocalCalls = Case.LocalCalls,
                        ContactEmail = Case.ContactEmail,
                        LineID = Case.LineID,
                        CategoryID = SubCategory.CategoryID
                    };
        }

        public enum TypeEnum
        {
            長期合作, 急件, 一般案件
        }

        //Functions for CreateCase
        public string GetAllCategory()
        {
            var allCategory = _ctx.GetAll<Category>();
            var allSubCategory = _ctx.GetAll<SubCategory>();
            var all = new List<CategoryViewModel>();
            foreach (var item in allCategory)
            {
                var subList = new List<SubCateData>();
                foreach (var sub in allSubCategory)
                {
                    if (sub.CategoryID == item.CategoryID)
                    {
                        subList.Add(new SubCateData { SubCateID = sub.SubCategoryID, SubCateName = sub.SubCategoryName });
                    }
                }
                all.Add(new CategoryViewModel { CategoryID = item.CategoryID, CategoryName = item.CategoryName, JsonSubCategoryList = JsonConvert.SerializeObject(subList) });
            }
            return JsonConvert.SerializeObject(all);
        }
        
        public string GetLocationList()
        {
            var locations = _ctx.GetAll<Locations>().ToList();
            return JsonConvert.SerializeObject(locations);
        }
        public void CreateNewCase(int userID, CaseDetailViewModel newCase, List<CaseReference> refList) 
        {
            Case entity = new Case
            {
                SortNumber = 1,
                CaseTitle = newCase.title,
                SubCategoryID = newCase.SubCategoryID,
                UpdateDate = DateTime.UtcNow.AddHours(8),
                Price = newCase.PriceInt,
                Location = newCase.LocationID,
                Description = newCase.Description,
                MemberID = userID,
                Type = (int?)newCase.Type,
                Contact = newCase.Contact,
                LocalCalls = newCase.LocalCalls,
                LocalCallsCode = newCase.LocalCallsCode,
                LocalCallsExtension = newCase.LocalCallsExtension,
                ContactTime = newCase.ContactTime,
                ContactEmail = newCase.ContactEmail,
                LineID = newCase.LineID,
                CompleteDate = newCase.CompleteDate,
                CaseStatus = 4
            };
            _ctx.CreateNewCase(entity, refList);
        }
    }
}
