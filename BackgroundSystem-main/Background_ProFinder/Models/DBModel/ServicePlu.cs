using System;
using System.Collections.Generic;

#nullable disable

namespace Background_ProFinder.Models.DBModel
{
    public partial class ServicePlu
    {
        public int MemberId { get; set; }
        public int ServicePlusId { get; set; }
        public int EnhancedService { get; set; }
        public decimal Cost { get; set; }
        public byte Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual MemberInfo Member { get; set; }
    }
}
