namespace PRO_finder.Models.DBModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Locations
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LocationID { get; set; }

        [Required]
        [StringLength(10)]
        public string LocationName { get; set; }
    }
}
