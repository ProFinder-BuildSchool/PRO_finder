using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRO_finder.Models.ViewModels
{
    
    public class WorkAttachmentViewModel
    {

        public int WorkAttachmentID { get; set; }

        public string WorkAttachmentName { get; set; }

        public string WorkAttachmentLink { get; set; }

        public int? WorkID { get; set; }
    }
}