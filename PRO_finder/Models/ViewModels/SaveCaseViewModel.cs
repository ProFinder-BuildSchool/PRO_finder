using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;

namespace PRO_finder.Models.ViewModels
{
    public class SaveCaseViewModel 
    {
        public SaveCaseViewModel()
        {
            this.savedCaseItems = new List<SaveCaseItemViewModel>();
        }
        //存所有已收藏案件
        public List<SaveCaseItemViewModel> savedCaseItems;

        //取得已收藏案件總數量
        public int Count
        {
            get
            {
                return this.savedCaseItems.Count;
            }
        }

        
    }
}