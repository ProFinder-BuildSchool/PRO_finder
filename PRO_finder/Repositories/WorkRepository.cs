using PRO_finder.Models.DBModel;
using PRO_finder.Service;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PRO_finder.Repositories
{
    public class WorkRepository:GeneralRepository
    {
        private DbContext _context;
        public WorkRepository(DbContext context):base(context)
        {
            _context = context;
        }

        public OperationResult CreateNewWork(Works entity, List<WorkPictures> pictures, List<WorkAttachment> attachments)
        {
            OperationResult result = new OperationResult();
            using(var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    Create(entity);
                    SaveChanges();
                    foreach(var item in pictures)
                    {
                        Create(item);
                        SaveChanges();
                    }
                    foreach(var item in attachments)
                    {
                        Create(item);
                        SaveChanges();
                    }
                    result.IsSuccessful = true;
                    transaction.Commit();
                }
                catch(Exception ex)
                {
                    result.IsSuccessful = false;
                    result.Exception = ex;
                    transaction.Rollback();
                }
            }
            return result;
        }
    }
}