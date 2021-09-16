using System;
using System.Collections.Generic;

#nullable disable

namespace Background_ProFinder.Models.DBModel
{
    public partial class Case
    {
        public int CaseId { get; set; }
        public int? SortNumber { get; set; }
        public string CaseTitle { get; set; }
        public int? SubCategoryId { get; set; }
        public DateTime UpdateDate { get; set; }
        public int? Price { get; set; }
        public int? Location { get; set; }
        public string Description { get; set; }
        public int? MemberId { get; set; }
        public int? Type { get; set; }
        public int? CaseStatus { get; set; }
        public string Contact { get; set; }
        public bool? AnswerPhone { get; set; }
        public string LocalCallsCode { get; set; }
        public string LocalCalls { get; set; }
        public string LocalCallsExtension { get; set; }
        public string ContactTime { get; set; }
        public string ContactEmail { get; set; }
        public string LineId { get; set; }
        public int? CompleteDate { get; set; }

        public virtual MemberInfo Member { get; set; }
    }
}
