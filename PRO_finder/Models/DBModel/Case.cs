namespace PRO_finder.Models.DBModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Case")]
    public partial class Case
    {
        public int CaseID { get; set; }

        public int? SortNumber { get; set; }

        [StringLength(30)]
        public string CaseTitle { get; set; }

        public int? SubCategoryID { get; set; }

        public DateTime UpdateDate { get; set; }

        public int? Price { get; set; }

        public int? Location { get; set; }

        public string Description { get; set; }

        public int? MemberID { get; set; }

        public int? Type { get; set; }

        public int? CaseStatus { get; set; }

        [StringLength(50)]
        public string Contact { get; set; }

        public bool? AnswerPhone { get; set; }

        [StringLength(10)]
        public string LocalCallsCode { get; set; }

        [StringLength(50)]
        public string LocalCalls { get; set; }

        [StringLength(50)]
        public string LocalCallsExtension { get; set; }

        [StringLength(50)]
        public string ContactTime { get; set; }

        [StringLength(50)]
        public string ContactEmail { get; set; }

        [StringLength(50)]
        public string LineID { get; set; }

        public int? CompleteDate { get; set; }

        public virtual MemberInfo MemberInfo { get; set; }
    }
}
