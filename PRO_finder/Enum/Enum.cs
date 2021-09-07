using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRO_finder.Enum
{
    public class Enum
    {
        public enum UnitEnum
        {
            件, 張, 頁, 份, 字, 個, 天, 時, 坪, 才, 秒, 月, 則, 幅
        }


        public enum CaseStatusEnum
        {
        審核中,代托管, 審核未通過,草稿,已上架,進行中,已成交,已關閉,未上架
        }


        public enum OrderStatus
        {
            製作中=1,待驗收=2
        }
    }
}