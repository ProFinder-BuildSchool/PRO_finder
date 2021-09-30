using PRO_finder.Models.DBModel;
using PRO_finder.Service;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PRO_finder.Repositories
{
    public class CaseRepository : GeneralRepository
    {
        private DbContext _context;
        public CaseRepository(DbContext context) : base(context)
        {
            _context = context;
        }
        public OperationResult CreateNewCase(Case entity, List<CaseReference> refList)
        {
            OperationResult result = new OperationResult();
            using(var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    Create(entity);
                    SaveChanges();
                    foreach(var item in refList)
                    {
                        item.CaseID = entity.CaseID;
                        Create(item);
                        SaveChanges();
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