namespace PRO_finder
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Message")]
    public partial class Message
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CaseID { get; set; }

        public int TargetID { get; set; }

        public DateTime? ChatTime { get; set; }

        public int SourceID { get; set; }

        public string ChatContent { get; set; }

        public virtual MemberInfo MemberInfo { get; set; }

        public virtual MemberInfo MemberInfo1 { get; set; }
    }
}
