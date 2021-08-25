using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRO_finder.Helper
{
    public class DateToString
    {

        public static string TransDate(DateTime updateDate)
        {
            DateTime nowDate = DateTime.UtcNow;

            var diff = nowDate.Subtract(updateDate);
            string result = string.Empty;
            if (diff.TotalDays > 0)
            {
                result = $"{(int)diff.TotalDays}天前";
            }
            else
            {
                result = $"{diff.Hours}小時前";
            }

            return result;
        }
    }
}