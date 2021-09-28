using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRO_finder.Models.ViewModels
{
    public class WorkViewModel
    {
      

        public int WorkID { get; set; }

        public int SortNum { get; set; }


        public List<string> WorkPicture { get; set; }
        public string SubCategoryName { get; set; }


        public string Info { get; set; }


        public string studio { get; set; }
        public int MemberID { get; set; }
        public string Memo { get; set; }
    }

}