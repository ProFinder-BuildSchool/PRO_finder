using System;
using System.Collections.Generic;

#nullable disable

namespace Background_ProFinder.Models.DBModel
{
    public partial class Order
    {
        public int? OrderType { get; set; }
        public int OrderId { get; set; }
        public int? ProposerId { get; set; }
        public decimal? CaseReview { get; set; }
        public string CaseMessage { get; set; }
        public string CaseReplyMessage { get; set; }
        public string CloseReason { get; set; }
        public int? OrderStatus { get; set; }
        public int? DepositStatus { get; set; }
        public decimal? Price { get; set; }
        public DateTime? DealedDate { get; set; }
        public int? ClientId { get; set; }
        public string QuotationImg { get; set; }
        public string StudioName { get; set; }
        public int? Count { get; set; }
        public int? Unit { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Tel { get; set; }
        public string LineId { get; set; }
        public string Memo { get; set; }
        public int? ContactTime { get; set; }
        public int? PredictDays { get; set; }
        public int? MemberId { get; set; }
        public DateTime? CompleteDate { get; set; }
        public string PaymentCode { get; set; }
        public int? QuotationId { get; set; }
        public int? CaseId { get; set; }
        public string Title { get; set; }
        public string ProposerEmail { get; set; }
        public string ProposerPhone { get; set; }

        public virtual MemberInfo Member { get; set; }
    }
}
