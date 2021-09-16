using System;
using System.Collections.Generic;

#nullable disable

namespace Background_ProFinder.Models.DBModel
{
    public partial class ServiceRecord
    {
        public string MemberId { get; set; }
        public int CaseId { get; set; }
        public DateTime SavedDate { get; set; }
        public int CustomerId { get; set; }
        public string Message { get; set; }
        public string CaseReview { get; set; }
    }
}
