using Newtonsoft.Json.Linq;
using PRO_finder.Models.DBModel;
using PRO_finder.Models.ViewModels;
using PRO_finder.Service;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PRO_finder.Repositories
{
    public class MemberInfoRepository : GeneralRepository
    {
        private DbContext _context;
       public MemberInfoRepository(DbContext context) : base(context)
        {
            _context = context;
        }
        public OperationResult CreateMemberInfo(int memberID, MemberInfoViewModel newSettings)
        {
            OperationResult result = new OperationResult();
            using(var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var entity = GetAll<MemberInfo>().FirstOrDefault(x => x.MemberID == memberID);
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
                    Update(entity);
                    SaveChanges();

                    //接案經驗
                    if (newSettings.JsonExDList != null)
                    {
                        //先刪除原有記錄
                        List<Experience> origin = GetAll<Experience>().Where(x => x.MemberID == memberID).ToList();
                        foreach (var item in origin)
                        {
                            Delete(item);
                            SaveChanges();
                        }
                        //加入新記錄
                        JArray tempArray = JArray.Parse(newSettings.JsonExDList);
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
                            Create(e);
                            SaveChanges();
                        }
                    }

                    //擅長工具
                    if (newSettings.JsonToolList != null)
                    {
                        //刪除原有記錄
                        List<TalentTool> origin = GetAll<TalentTool>().Where(x => x.MemberID == memberID).ToList();
                        foreach (var item in origin)
                        {
                            Delete(item);
                            SaveChanges();
                        }

                        //加入新紀錄
                        JArray tempArray = JArray.Parse(newSettings.JsonToolList);
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
                            Create(t);
                            SaveChanges();
                        }
                    }
                    transaction.Commit();
                    result.IsSuccessful = true;
                }
                catch(Exception ex)
                {
                    transaction.Rollback();
                    result.IsSuccessful = false;
                    result.Exception = ex;
                }
            }
            return result;
        }
    }
}