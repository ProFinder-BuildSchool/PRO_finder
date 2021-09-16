using System;
using System.Collections.Generic;

#nullable disable

namespace Background_ProFinder.Models.DBModel
{
    public partial class QuotationDetail
    {
        public int CaseId { get; set; }
        public int ProposerId { get; set; }
        public int PredictDays { get; set; }
        public string ProposeDescription { get; set; }
        public DateTime ProposeDate { get; set; }
        public decimal ProposePrice { get; set; }
        public int QuotaionDetailId { get; set; }
        public bool? Status { get; set; }
        public int? Unit { get; set; }

        public virtual MemberInfo Proposer { get; set; }
    }
}
