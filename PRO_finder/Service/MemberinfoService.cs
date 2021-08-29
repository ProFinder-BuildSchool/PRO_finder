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

        public List<MemberInfo> getMemberInfoItem()
        {
            using (ProFinderContext context = new ProFinderContext())
            {
                List<MemberInfo> memberinfoList = context.MemberInfo.ToList();
                return memberinfoList;
            }
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

        public MemberInfo UpdateMemberInfo(int memberID ,MemberInfoViewModel newSettings)
        {
            var entity = _ctx.GetAll<MemberInfo>().FirstOrDefault(x => x.MemberID == memberID);
            entity.Status = newSettings.Status;
            entity.NickName = newSettings.NickName;
            entity.Identity = (int)newSettings.Identity;
            entity.LiveCity = newSettings.LiveCity;
            entity.Cellphone = newSettings.Cellphone;
            entity.Email = newSettings.Email;
            entity.LocationID = (int)newSettings.LocationID;
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
            foreach(var item in origin)
            {
                _ctx.Delete(item);
                _ctx.SaveChanges();
            }
            //加入新記錄
            JArray tempArray = JArray.Parse(jsonExDList);
            List<Experience> expList = tempArray.ToObject<List<Experience>>();
            foreach(var item in expList)
            {
                Experience e = new Experience
                {
                    MemberID = memberID,
                    SubCategoryID = item.SubCategoryID,
                    PieceworkExp = item.PieceworkExp
                };
                _ctx.Create(e);
                _ctx.SaveChanges();
            }
        }

        public void UpdateToolList(int memberID, string jsonToolList)
        {
            //刪除原有記錄
            List<TalentTool> origin = _ctx.GetAll<TalentTool>().Where(x => x.MemberID == memberID).ToList();
            foreach(var item in origin)
            {
                _ctx.Delete(item);
                _ctx.SaveChanges();
            }
            
            //加入新紀錄
            JArray tempArray = JArray.Parse(jsonToolList);
            List<TalentTool> toolList = tempArray.ToObject<List<TalentTool>>();
            foreach(var item in toolList)
            {
                TalentTool t = new TalentTool
                {
                    ToolCategoryID = item.ToolCategoryID,
                    ToolSubCategoryID = item.ToolSubCategoryID,
                    //ToolSubCategoryName = item.ToolSubCategoryName,
                    ToolSubCategoryName = 1,
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