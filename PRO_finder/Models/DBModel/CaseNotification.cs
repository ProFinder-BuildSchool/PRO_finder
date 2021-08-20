namespace PRO_finder.Models.DBModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CaseNotification")]
    public partial class CaseNotification
    {
        public int CaseID { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int InvitedTalentID { get; set; }

        [Column(TypeName = "date")]
        public DateTime InvitedDate { get; set; }

        public int ReplyStatus { get; set; }
    }
}
