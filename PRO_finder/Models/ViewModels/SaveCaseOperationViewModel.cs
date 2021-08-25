using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace PRO_finder.Models.ViewModels
{
    public static class SaveCaseOperationViewModel
    {
        //啟用Session
        [WebMethod(EnableSession = true)]
        public static Models.ViewModels.SaveCaseViewModel GetCurrentSaveCase()
        {
            if (System.Web.HttpContext.Current != null)
            {
                if (System.Web.HttpContext.Current.Session["SaveCase"] == null)
                {
                    var saved = new SaveCaseViewModel();
                    System.Web.HttpContext.Current.Session["SaveCase"] = saved;
                }
                return (SaveCaseViewModel)System.Web.HttpContext.Current.Session["SaveCase"];
            }
            else
            {
                throw new InvalidOperationException("System.Web.HttpContext.Current為空,請檢查");
            }


        }


    }
}