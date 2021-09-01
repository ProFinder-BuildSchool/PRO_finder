namespace PRO_finder.Models.DBModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SaveCase")]
    public partial class SaveCase
    {
        public DateTime SavedDate { get; set; }

        public int MemberID { get; set; }

        public int? CaseID { get; set; }

        public int SaveCaseID { get; set; }
    }
}
