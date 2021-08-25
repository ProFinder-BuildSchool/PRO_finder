using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRO_finder.Models.ViewModels.APIModels.APIBase
{
    public class APIResult
    {
        public APIResult(int status, string errMsg, object result)
        {
            Status = status;
            ErrMsg = errMsg;
            Result = result;
        }
        public int Status { get; set; }
        public string ErrMsg { get; set; }
        public object Result { get; set; }

    }

    public static class APIStatus
    {
        public const int Success = 0;
        public const int Fail = 1;
        public const int DataBaseBreak = 101;

    }
}