using System;
using System.Collections.Generic;

#nullable disable

namespace Background_ProFinder.Models.DBModel
{
    public partial class CaseNotification
    {
        public int CaseId { get; set; }
        public int InvitedTalentId { get; set; }
        public DateTime InvitedDate { get; set; }
        public int ReplyStatus { get; set; }
    }
}
