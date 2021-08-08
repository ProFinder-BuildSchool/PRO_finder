namespace PRO_finder.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SaveCase")]
    public partial class SaveCase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CaseID { get; set; }

        public TimeSpan SavedDate { get; set; }

        public int MemberID { get; set; }

        public virtual Case Case { get; set; }
    }
}
