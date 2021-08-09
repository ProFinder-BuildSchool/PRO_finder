using PRO_finder.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace PRO_finder.Models
{
    public class Cate
    {
        public Models.Enum.Category Category { get; set; }
        public string Icon { get; set; }
        public List<string> SubCategories { get; set; }
    }
}