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

        public SaveCaseViewModel()
        {
            this.saveCaseItems = new List<SaveCaseItemViewModel>();
        }
        public List<SaveCaseItemViewModel> saveCaseItems;
    }
}