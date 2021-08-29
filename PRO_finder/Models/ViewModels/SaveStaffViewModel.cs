using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRO_finder.Models.ViewModels
{
    public class SaveStaffViewModel
    {
        public int MemberID { get; set; }
        public int SavedTalentID { get; set; }

        public DateTime SavedDate { get; set; }

        public int SaveStaffID { get; set; }


    }
}