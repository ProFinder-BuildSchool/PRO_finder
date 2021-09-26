using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace PRO_finder.Models.ViewModels
{
    public class CaseDetailViewModel
    {
        public string title { get; set; }
        public int CaseId { get; set; }
        public int LocationID { get; set; }
        public string LocationName { get; set; }

        public enum TypeEnum
        {
            長期合作, 急件, 一般案件
        }

        public TypeEnum Type
        {
            get; set;
        }
        public enum PriceEnum
        {不可為零 , 五千元以下, 五千至一萬元間, 一萬至五萬元間, 五萬至十萬元間, 十萬至三十萬元間, 查無資料}
        public PriceEnum Price { get; set; }
        public int PriceInt { get; set; }
        public int? CompleteDate { get; set; }
        public string Description { get; set; }
        public string Contact { get; set; }
        public string ContactTime { get; set; }
        public string LocalCallsCode { get; set; }
        public string LocalCalls { get; set; }
        public string LocalCallsExtension { get; set; }
        public string ContactEmail { get; set; }
        public string LineID { get; set; }
        public int CategoryID { get; set; }
        public int SubCategoryID { get; set; }
        public string SubCategoryName { get; set; }
        //public string LogInTime { get; set; }
        public bool SavedOrNot { get; set; }
        public string CellPhone { get; set; }


        //案主積極度
        public decimal Degree { get; set; }
        public int Readed { get; set; }
        public int Replyed { get; set; }
        public int Propose { get; set; }
        public DateTime OnlineTime { get; set; }


    }

    
}