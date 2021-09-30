using PRO_finder.Models.DBModel;
using PRO_finder.Service;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PRO_finder.Repositories
{
    public class QuotationRepository : GeneralRepository
    {
        private DbContext _context;
        public QuotationRepository(DbContext context) : base(context)
        {
            _context = context;
        }
        public OperationResult CreateNewQuotation(Quotation entity, List<OtherPicture> pics)
        {
            OperationResult result = new OperationResult();
            using(var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    Create(entity);
                    SaveChanges();

                    foreach(var item in pics)
                    {
                        item.QuotationID = entity.QuotationID;
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
                return result;
            }
        }
        public OperationResult UpdateQuotation(Quotation entity, List<OtherPicture> pics)
        {
            OperationResult result = new OperationResult();
            using(var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    Update(entity);
                    SaveChanges();

                    List<OtherPicture> originPics = GetAll<OtherPicture>().Where(x => x.QuotationID == entity.QuotationID).ToList();
                    foreach (var op in originPics)
                    {
                        Delete(op);
                        SaveChanges();
                    }
                    foreach (var p in pics)
                    {
                        Create(p);
                        SaveChanges();
                    }
                    transaction.Commit();
                    result.IsSuccessful = true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    result.Exception = ex;
                    result.IsSuccessful = false;
                }
            }
            return result;
        }
    }
}