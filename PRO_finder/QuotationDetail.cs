namespace PRO_finder
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QuotationDetail")]
    public partial class QuotationDetail
    {
        public int CaseID { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProposerID { get; set; }

        public int PredictDays { get; set; }

        [Required]
        public string ProposeDescription { get; set; }

        public virtual Case Case { get; set; }

        public virtual MemberInfo MemberInfo { get; set; }
    }
}
