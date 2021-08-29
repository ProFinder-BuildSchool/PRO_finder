using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRO_finder.Helper
{
    public class PriceToString
    {

        public static string PriceToRange(int priceNum)
        {
            switch (priceNum)
            {
                case 1:
                    return "5000元以下";
                case 2:
                    return "5001~10000元";
                case 3:
                    return "10001~50000元";
                case 4:
                    return "50001~100000元";
                case 5:
                    return "100001~300000元";
                default:
                    return "查無資料";
            }
        }
    }
}