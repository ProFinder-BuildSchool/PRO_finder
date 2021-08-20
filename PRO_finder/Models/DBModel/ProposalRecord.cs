namespace PRO_finder.Models.DBModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProposalRecord")]
    public partial class ProposalRecord
    {
        public int MemberID { get; set; }

        public int CaseID { get; set; }

        public TimeSpan SavedDate { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProposalRecordID { get; set; }

        public virtual MemberInfo MemberInfo { get; set; }
    }
}
