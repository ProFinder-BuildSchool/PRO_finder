using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRO_finder.Models.ViewModels
{
    public class SaveCaseViewModel
    {
        public int CaseID { get; set; }

        public DateTime SavedDate { get; set; }

        public int MemberID { get; set; }

        
        public List<SaveCaseItemViewModel> SaveCaseItems { get; set; }

        //public static explicit operator SaveCaseViewModel(object v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}