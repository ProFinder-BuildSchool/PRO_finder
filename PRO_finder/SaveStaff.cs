namespace PRO_finder
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SaveStaff")]
    public partial class SaveStaff
    {
        public int MemberID { get; set; }

        public int SavedTalentID { get; set; }

        [Column(TypeName = "date")]
        public DateTime SavedDate { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SaveStaffID { get; set; }

        public virtual MemberInfo MemberInfo { get; set; }

        public virtual MemberInfo MemberInfo1 { get; set; }
    }
}
