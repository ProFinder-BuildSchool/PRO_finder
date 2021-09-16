using System;
using System.Collections.Generic;

#nullable disable

namespace Background_ProFinder.Models.DBModel
{
    public partial class Message
    {
        public int CaseId { get; set; }
        public int TargetId { get; set; }
        public DateTime? ChatTime { get; set; }
        public int SourceId { get; set; }
        public string ChatContent { get; set; }

        public virtual MemberInfo Source { get; set; }
        public virtual MemberInfo Target { get; set; }
    }
}
