using PRO_finder.Models;
using PRO_finder.Models.Enum;
using PRO_finder.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRO_finder.Settings
{
    public static class Setting
    {
        //把enum轉成字串 ， 因為有斜線
        public static Dictionary<Models.Enum.SubCategory, string> SubCategoryNameMapping = new Dictionary<Models.Enum.SubCategory, string> {
            //平面設計
            {Models.Enum.SubCategory.LOGO商標設計, "LOGO/商標設計" },{Models.Enum.SubCategory.名片信封設計, "名片/信封設計" },
            {Models.Enum.SubCategory.企業形象VI設計, "企業形象/VI設計" },{Models.Enum.SubCategory.DM海報卡片設計, "DM/海報/卡片設計" },
            {Models.Enum.SubCategory.書籍手冊簡報設計, "書籍/手冊/簡報設計" },{Models.Enum.SubCategory.插畫漫畫, "插畫/漫畫" },
            {Models.Enum.SubCategory.命名Slogan標語, "命名/Slogan標語" },
            //網頁設計
            {Models.Enum.SubCategory.網站維護經營, "網站維護/經營" },{Models.Enum.SubCategory.網站行銷SEO, "網站行銷/SEO" },
            {Models.Enum.SubCategory.網站程式設計網站架設, "網站程式設計/網站架設" },{Models.Enum.SubCategory.UIUX設計, "UI/UX設計" },
        };

        public static List<Cate> Titles = new List<Cate>() {
            new Cate{ Category = Models.Enum.Category.平面設計, Icon="fas fa-pencil-ruler", SubCategories = new List<string>
            {
                ConvertToName(Models.Enum.SubCategory.LOGO商標設計), ConvertToName(Models.Enum.SubCategory.招牌設計) ,
                ConvertToName(Models.Enum.SubCategory.名片信封設計), ConvertToName(Models.Enum.SubCategory. 企業形象VI設計) ,
                ConvertToName(Models.Enum.SubCategory.DM海報卡片設計), ConvertToName(Models.Enum.SubCategory.封面設計) ,
                ConvertToName(Models.Enum.SubCategory.書籍手冊簡報設計), ConvertToName(Models.Enum.SubCategory.產品包裝設計) ,
                ConvertToName(Models.Enum.SubCategory.插畫漫畫), ConvertToName(Models.Enum.SubCategory. 織品服裝設計) ,
                ConvertToName(Models.Enum.SubCategory.命名Slogan標語), ConvertToName(Models.Enum.SubCategory.ICON設計) ,
            } },


            new Cate{ Category = Models.Enum.Category.網頁設計, Icon="far fa-window-restore", SubCategories = new List<string>
            {
                ConvertToName(Models.Enum.SubCategory.網頁版型設計), ConvertToName(Models.Enum.SubCategory.網頁切版製作) ,
                ConvertToName(Models.Enum.SubCategory.EDM設計), ConvertToName(Models.Enum.SubCategory.廣告Banner),
                ConvertToName(Models.Enum.SubCategory.網站維護經營), ConvertToName(Models.Enum.SubCategory.網站行銷SEO),
                ConvertToName(Models.Enum.SubCategory.網站程式設計網站架設), ConvertToName(Models.Enum.SubCategory.網拍商品上架),
                 ConvertToName(Models.Enum.SubCategory.UIUX設計),
            } },


            new Cate{ Category = Models.Enum.Category.程式開發, Icon="far fa-heart", SubCategories = new List<string>{ ConvertToName(Models.Enum.SubCategory.名片信封設計), ConvertToName(Models.Enum.SubCategory.LOGO商標設計) } }
        };

        private static string ConvertToName(Models.Enum.SubCategory subCategory)
        {
            return SubCategoryNameMapping.ContainsKey(subCategory) ? SubCategoryNameMapping[subCategory] : subCategory.ToString();
        }

    }
}