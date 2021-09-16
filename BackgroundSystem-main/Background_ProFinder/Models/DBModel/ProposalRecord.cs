using System;
using System.Collections.Generic;

#nullable disable

namespace Background_ProFinder.Models.DBModel
{
    public partial class ProposalRecord
    {
        public int MemberId { get; set; }
        public int CaseId { get; set; }
        public DateTime SavedDate { get; set; }
        public int ProposalRecordId { get; set; }

        public virtual MemberInfo Member { get; set; }
    }
}
