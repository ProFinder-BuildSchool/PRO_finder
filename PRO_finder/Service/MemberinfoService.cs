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
using PRO_finder.Models.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PRO_finder.Service
{
    public class MemberinfoService
    {
        private readonly GeneralRepository _ctx;
        public MemberinfoService()
        {
            _ctx = new GeneralRepository(new ProFinderContext());
        }

        //public List<MemberInfo> getMemberInfoItem()
        //{
        //    using (ProFinderContext context = new ProFinderContext())
        //    {
        //        List<MemberInfo> memberinfoList = context.MemberInfo.ToList();
        //        return memberinfoList;
        //    }
        //}

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
        public int GetMemberID(string userID)
        {
            return _ctx.GetAll<MemberInfo>().FirstOrDefault(x => x.UserId == userID).MemberID;
        }
        public MemberInfoViewModel GetMemberInfo(int memberID)
        {
            //取得會員Experience資料
            var experiences = _ctx.GetAll<Experience>().Select(x => new ExperienceViewModel
            {
                MemberID = x.MemberID,
                CategoryID = x.CategoryID,
                SubCategoryID = x.SubCategoryID,
                PieceworkExp = x.PieceworkExp
            }).ToList();
            var exp = new List<ExperienceSelectItemViewModel>();
            if (experiences != null)
            {
                foreach (var item in experiences)
                {
                    //製作Experience 主類型Category選單（MemberInfo資料庫中的記錄尚未Selected）
                    var categoryDropdownList = new List<SelectListItem>
                    {
                        new SelectListItem{ Value= "-1", Text = "請選擇主類型"}
                    };
                    var allCate = _ctx.GetAll<Category>().ToList();
                    foreach (var c in allCate)
                    {
                        categoryDropdownList.Add(new SelectListItem { Value = c.CategoryID.ToString(), Text = c.CategoryName });
                    }
                    //設定 Category Selected
                    categoryDropdownList.FirstOrDefault(x => Int32.Parse(x.Value) == item.CategoryID).Selected = true;

                    //製作Experience 子類型SubCategory選單（資料庫尚未Selected）
                    var subCategoryDropdownList = new List<SelectListItem>
                {
                    new SelectListItem{ Value= "-1", Text = "請選擇子類型"}
                };
                    var allSubCate = _ctx.GetAll<SubCategory>().ToList();
                    foreach (var s in allSubCate)
                    {
                        subCategoryDropdownList.Add(new SelectListItem { Value = s.SubCategoryID.ToString(), Text = s.SubCategoryName });
                    }
                    //設定 Subcategory Selected
                    subCategoryDropdownList.FirstOrDefault(x => Int32.Parse(x.Value) == item.SubCategoryID).Selected = true;

                    //製作Experience Piecework 選單（資料庫尚未Selected）
                    var pieceworkDropdownList = new List<SelectListItem>()
                    {
                        new SelectListItem{ Value= "-1", Text = "請選擇工作期間"},
                        new SelectListItem {Value="無工作經驗", Text = "無工作經驗"},
                        new SelectListItem {Value="0-1年工作經驗", Text = "0-1年工作經驗"},
                        new SelectListItem {Value="1-2年工作經驗", Text = "1-2年工作經驗"},
                        new SelectListItem {Value="2-3年工作經驗", Text = "2-3年工作經驗"},
                        new SelectListItem {Value="3-4年工作經驗", Text = "3-4年工作經驗"},
                        new SelectListItem {Value="4-5年工作經驗", Text = "4-5年工作經驗"},
                        new SelectListItem {Value="5-6年工作經驗", Text = "5-6年工作經驗"},
                        new SelectListItem {Value="6-7年工作經驗", Text = "6-7年工作經驗"},
                        new SelectListItem {Value="7-8年工作經驗", Text = "7-8年工作經驗"},
                        new SelectListItem {Value="8-9年工作經驗", Text = "8-9年工作經驗"},
                        new SelectListItem {Value="9-10年工作經驗", Text = "9-10年工作經驗"},
                        new SelectListItem {Value="10年以上工作經驗", Text = "10年以上工作經驗"},
                    };
                    Console.WriteLine(item.PieceworkExp);
                    //設定Experience Selected
                    pieceworkDropdownList.FirstOrDefault(x => x.Value == item.PieceworkExp).Selected = true;

                    exp.Add(new ExperienceSelectItemViewModel
                    {
                        MemberID = memberID,
                        CategoryDropdown = categoryDropdownList,
                        SubCategoryDropdown = subCategoryDropdownList,
                        PieceworkDropdown = pieceworkDropdownList
                    });
                }
            }
            else
            {
                exp = null;
            }


            var memberInfoVM = _ctx.GetAll<MemberInfo>().Where(x => x.MemberID == memberID).Select(x => new MemberInfoViewModel
            {
                MemberID = x.MemberID,
                Cellphone = x.Cellphone,
                Email = x.Email,
                Status = x.Status,
                NickName = x.NickName,
                Identity = (MemberInfoViewModel.IdentityStatus)x.Identity,
                LiveCity = x.LiveCity,
                LocationIDInt = (int)x.LocationID,
                SubCategoryID = x.SubCategoryID,
                AllPieceworkExp = x.AllPieceworkExp,
                Description = x.Description,
            }).FirstOrDefault();

            if (exp != null)
            {
                memberInfoVM.Experiences = exp;
            }
            return memberInfoVM;
        }
        public MemberInfo UpdateMemberInfo(int memberID, MemberInfoViewModel newSettings)
        {
            var entity = _ctx.GetAll<MemberInfo>().FirstOrDefault(x => x.MemberID == memberID);
            entity.Status = newSettings.Status;
            entity.NickName = newSettings.NickName;
            entity.Identity = (int)newSettings.Identity;
            entity.LiveCity = newSettings.LiveCity;
            entity.Cellphone = newSettings.Cellphone;
            entity.Email = newSettings.Email;
            entity.LocationID = (int)newSettings.LocationIDInt;
            entity.AllPieceworkExp = newSettings.AllPieceworkExp;
            entity.Description = newSettings.Description;
            entity.SubCategoryID = newSettings.SubCategoryID;
            _ctx.Update(entity);
            _ctx.SaveChanges();
            return entity;
        }

        public void UpdateExD(int memberID, string jsonExDList)
        {
            //先刪除原有記錄
            List<Experience> origin = _ctx.GetAll<Experience>().Where(x => x.MemberID == memberID).ToList();
            foreach (var item in origin)
            {
                _ctx.Delete(item);
                _ctx.SaveChanges();
            }
            //加入新記錄
            JArray tempArray = JArray.Parse(jsonExDList);
            List<Experience> expList = tempArray.ToObject<List<Experience>>();
            foreach (var item in expList)
            {
                Experience e = new Experience
                {
                    MemberID = memberID,
                    SubCategoryID = item.SubCategoryID,
                    PieceworkExp = item.PieceworkExp,
                    CategoryID = item.CategoryID
                };
                _ctx.Create(e);
                _ctx.SaveChanges();
            }
        }

        public void UpdateToolList(int memberID, string jsonToolList)
        {
            //刪除原有記錄
            List<TalentTool> origin = _ctx.GetAll<TalentTool>().Where(x => x.MemberID == memberID).ToList();
            foreach (var item in origin)
            {
                _ctx.Delete(item);
                _ctx.SaveChanges();
            }

            //加入新紀錄
            JArray tempArray = JArray.Parse(jsonToolList);
            List<TalentTool> toolList = tempArray.ToObject<List<TalentTool>>();
            foreach (var item in toolList)
            {
                TalentTool t = new TalentTool
                {
                    ToolCategoryID = item.ToolCategoryID,
                    ToolSubCategoryID = item.ToolSubCategoryID,
                    ToolSubCategoryName = item.ToolSubCategoryName,
                    MemberID = memberID
                };
                _ctx.Create(t);
                _ctx.SaveChanges();
            }

        }
        public string GetToolRecord(int memberID)
        {
            var record = _ctx.GetAll<TalentTool>().Where(x => x.MemberID == memberID).ToList();
            return JsonConvert.SerializeObject(record);
        }

    }
}