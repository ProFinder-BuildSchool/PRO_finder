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
        public OperationResult CreateMemberInfo(MemberInfo entity, List<Experience> expList, List<TalentTool> toolList)
        {
            OperationResult result = new OperationResult();
            using(var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    Update(entity);
                    SaveChanges();

                    int memberID = entity.MemberID;
                    //接案經驗
                    if (expList != null)
                    {
                        //先刪除原有記錄
                        List<Experience> origin = GetAll<Experience>().Where(x => x.MemberID == memberID).ToList();
                        foreach (var item in origin)
                        {
                            Delete(item);
                            SaveChanges();
                        }
                        //加入新記錄
                        
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
                    if (toolList != null)
                    {
                        //刪除原有記錄
                        List<TalentTool> origin = GetAll<TalentTool>().Where(x => x.MemberID == memberID).ToList();
                        foreach (var item in origin)
                        {
                            Delete(item);
                            SaveChanges();
                        }

                        //加入新記錄
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