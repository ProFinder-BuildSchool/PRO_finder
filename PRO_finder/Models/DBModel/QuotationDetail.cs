namespace PRO_finder.Models.DBModel
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

        public int ProposerID { get; set; }

        public int PredictDays { get; set; }

        [Required]
        public string ProposeDescription { get; set; }

        public DateTime ProposeDate { get; set; }

        public decimal ProposePrice { get; set; }

        [Key]
        public int QuotaionDetailID { get; set; }

        public virtual MemberInfo MemberInfo { get; set; }
    }
}
