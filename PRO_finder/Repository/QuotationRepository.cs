using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PRO_finder.Models;
using PRO_finder.Models.DBModel;

namespace PRO_finder.Repository
{
    public class QuotationRepository
    {
        private readonly ProFinderContext _ctx;
        public QuotationRepository()
        {
            _ctx = new ProFinderContext();
        }
        public List<Quotation> ReadQuotationData()
        {
            var QuotationList = _ctx.Quotation.ToList();
            return QuotationList;
        }
    }
}