using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRO_finder.Models.ViewModels
{
    public class BankAccountViewModel
    {
        public int MemberID { get; set; }
        public string BankCode { get; set; }
        public string BankAccount { get; set; }

        //public bool Saveornot { get; set; }
    }
}