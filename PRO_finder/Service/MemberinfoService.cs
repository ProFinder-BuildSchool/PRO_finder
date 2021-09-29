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
using System.Globalization;

namespace PRO_finder.Service
{
    public class MemberinfoService
    {
        private readonly MemberInfoRepository _ctx;
        public MemberinfoService()
        {
            _ctx = new MemberInfoRepository(new ProFinderContext());
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
            var experiences = _ctx.GetAll<Experience>().Where(x => x.MemberID == memberID).Select(x => new ExperienceViewModel
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

            var memInfo = _ctx.GetAll<MemberInfo>().FirstOrDefault(x => x.MemberID == memberID);
            var memberInfoVM = new MemberInfoViewModel
            {
                MemberID = memInfo.MemberID,
                Cellphone = memInfo.Cellphone,
                Email = memInfo.Email,
                Status = memInfo.Status,
                NickName = memInfo.NickName,
                LiveCity = memInfo.LiveCity,
                SubCategoryID = memInfo.SubCategoryID,
                AllPieceworkExp = memInfo.AllPieceworkExp,
                Description = memInfo.Description,
            };
            //接案身份
            memberInfoVM.Identity = memInfo.Identity == null ? (MemberInfoViewModel.IdentityStatus)(-1) : (MemberInfoViewModel.IdentityStatus)memInfo.Identity;
            //理想接案城市
            memberInfoVM.LocationIDInt = memInfo.LocationID == null ? -1 : (int)memInfo.LocationID;

            if (exp != null)
            {
                memberInfoVM.Experiences = exp;
            }
            return memberInfoVM;
        }
        public OperationResult UpdateMemberInfo(int memberID, MemberInfoViewModel newSettings)
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

            //接案經驗vm to dm
            List<Experience> expList = new List<Experience>();
            if (newSettings.JsonExDList != null)
            {
                JArray tempArray = JArray.Parse(newSettings.JsonExDList);
                expList = tempArray.ToObject<List<Experience>>();
            }

            //擅長工具 vm to dm
            List<TalentTool> toolList = new List<TalentTool>();
            if (newSettings.JsonToolList != null)
            {
                JArray tempArray = JArray.Parse(newSettings.JsonToolList);
                toolList = tempArray.ToObject<List<TalentTool>>();
                
            }
            var result = _ctx.CreateMemberInfo(entity, expList, toolList);
            return result;
        }

        public string GetToolRecord(int memberID)
        {
            var record = _ctx.GetAll<TalentTool>().Where(x => x.MemberID == memberID).ToList();
            return JsonConvert.SerializeObject(record);
        }
        public BankAccountViewModel GetBankAccount(int memberID)
        {
            var record = _ctx.GetAll<MemberInfo>().Where(x => x.MemberID == memberID).ToList();
            var BankAccountVM = (from m in record
                                 select new BankAccountViewModel
                                 {
                                     MemberID = m.MemberID,
                                     BankCode = m.BankCode,
                                     BankAccount = m.BankAccount

                                 });
            return BankAccountVM.FirstOrDefault();
        }
        public OperationResult UpdateBankAccount(BankAccountViewModel newBank)
        {
            var entity = _ctx.GetAll<MemberInfo>().FirstOrDefault(x => x.MemberID == newBank.MemberID);
            var result = new OperationResult();
            try
            {
                entity.MemberID = newBank.MemberID;
                entity.BankCode = newBank.BankCode;
                entity.BankAccount = newBank.BankAccount;
                _ctx.Update(entity);
                _ctx.SaveChanges();
                result.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                result.IsSuccessful = false;
                result.Exception = ex;
            }
            return result;
        }

        public MemberInfoViewModel GetAccountInfo(int userId)
        {
            var memberInfo = _ctx.GetAll<MemberInfo>().FirstOrDefault(x => x.MemberID == userId);

            var memberList = new MemberInfoViewModel()
            {
                Email = memberInfo.Email,
                Cellphone = memberInfo.Cellphone
            };

            return memberList;

        }


        public bool UpdateMemberInfoData(int memberId, MemberInfoViewModel memberdata)
        {

            _ctx.GetAll<MemberInfo>().First(x => x.MemberID == memberId).Email = memberdata.Email;
            _ctx.GetAll<MemberInfo>().First(x => x.MemberID == memberId).Cellphone = memberdata.Cellphone;
            _ctx.SaveChanges();

            return true;
        }

        //取得會員帳戶餘額
        public string getBalance(int memberID)
        {
            var member = _ctx.GetAll<MemberInfo>().FirstOrDefault(x => x.MemberID == memberID);
            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
            decimal balance = member.Balance != null ? (decimal)member.Balance : 0;
            return balance.ToString("C", nfi);
        }
        //取得會員總成交金額
        public string getTotalRevenue(int memberID)
        {
            var orderList = _ctx.GetAll<Order>().Where(x => x.ProposerID == memberID).ToList();
            var total = orderList.Select(x => x.Count * x.Price).Sum();
            decimal totalRevenue = total != null ? (decimal)total : 0;
            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
            return totalRevenue.ToString("C", nfi);
        }
        //取得會員進行中案件數量
        public int getOrderDoingCount(int memberID)
        {
            var orderList = _ctx.GetAll<Order>().Where(x => x.ProposerID == memberID && x.OrderStatus == 1).ToList();
            return orderList != null ? orderList.Count : 0;
        }
        //取得會員已完成案件數量
        public int getOrderCompleteCount(int memberID)
        {
            var orderList = _ctx.GetAll<Order>().Where(x => x.ProposerID == memberID && x.OrderStatus >= 2).ToList();
            return orderList != null ? orderList.Count : 0;
        }
    }


}