using System;
using System.Collections.Generic;

#nullable disable

namespace Background_ProFinder.Models.DBModel
{
    public partial class HostingDetail
    {
        public int MemberId { get; set; }
        public int CaseId { get; set; }
        public decimal HostedAmount { get; set; }
        public DateTime HostedTime { get; set; }
        public int HostId { get; set; }

        public virtual MemberInfo Member { get; set; }
    }
}
