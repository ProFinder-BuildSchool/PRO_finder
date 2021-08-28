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

namespace PRO_finder.Service
{
    public class CaseService
    {
        private readonly GeneralRepository _ctx;
        

        public CaseService()
        {

            _ctx = new GeneralRepository(new ProFinderContext());

           
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

           
            return temp;
        }




        public IEnumerable<CaseDetailViewModel> GetCaseDetail()
        {


            return from Case in _ctx.GetAll<Case>()
                   //join MemberInfo in _ctx.GetAll<MemberInfo>() on Case.MemberID equals MemberInfo.MemberID
                   join SubCategory in _ctx.GetAll<SubCategory>() on Case.SubCategoryID equals SubCategory.SubCategoryID
                   join Locations in _ctx.GetAll<Locations>() on Case.Location equals Locations.LocationID
                   //join Category in _ctx.GetAll<Category>() on SubCategory.CategoryID equals Category.CategoryID
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


                   };





        }

        public enum TypeEnum
        {
            長期合作, 急件, 一般案件
        }

       
        public List<SelectListItem> GetToolSelectList()
        {
            var toolList = _ctx.GetAll<ToolCategory>().ToList();
            List<SelectListItem> toolSelectList = new List<SelectListItem>();
            toolSelectList.Add(new SelectListItem { Text = "選擇擅長工具類型" });
            foreach (var item in toolList)
            {
                toolSelectList.Add(new SelectListItem { Text = item.TalentCategoryName, Value = item.TalentCategoryID.ToString() });
            }
            return toolSelectList;
        }
        public string GetJsonSubTool()
        {
            var subToolDblist = _ctx.GetAll<ToolSubCategory>().ToList();
            var subToolVMList = new List<SubToolViewModel>();
            foreach (var tool in subToolDblist)
            {
                subToolVMList.Add(new SubToolViewModel { TalentCategoryID = tool.TalentCategoryID, SubTalentCategoryID = tool.SubTalentCategoryID, SubTalentCategoryName = tool.SubTalentCategoryName });
            }
            return JsonConvert.SerializeObject(subToolVMList);
        }
    }
}
