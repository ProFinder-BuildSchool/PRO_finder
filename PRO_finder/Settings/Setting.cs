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
        public static Dictionary<SubCategory, string> SubCategoryNameMapping = new Dictionary<SubCategory, string> {
            //平面設計
            {SubCategory.LOGO商標設計, "LOGO/商標設計" },{SubCategory.名片信封設計, "名片/信封設計" },
            {SubCategory.企業形象VI設計, "企業形象/VI設計" },{SubCategory.DM海報卡片設計, "DM/海報/卡片設計" },
            {SubCategory.書籍手冊簡報設計, "書籍/手冊/簡報設計" },{SubCategory.插畫漫畫, "插畫/漫畫" },
            {SubCategory.命名Slogan標語, "命名/Slogan標語" },
            //網頁設計
            {SubCategory.網站維護經營, "網站維護/經營" },{SubCategory.網站行銷SEO, "網站行銷/SEO" },
            {SubCategory.網站程式設計網站架設, "網站程式設計/網站架設" },{SubCategory.UIUX設計, "UI/UX設計" },
        };

        public static List<Cate> Titles = new List<Cate>() {
            new Cate{Category = Category.平面設計, Icon="fas fa-pencil-ruler", SubCategories = new List<string>
            {
                ConvertToName(SubCategory.LOGO商標設計), ConvertToName(SubCategory.招牌設計) ,
                ConvertToName(SubCategory.名片信封設計), ConvertToName(SubCategory. 企業形象VI設計) ,
                ConvertToName(SubCategory.DM海報卡片設計), ConvertToName(SubCategory.封面設計) ,
                ConvertToName(SubCategory.書籍手冊簡報設計), ConvertToName(SubCategory.產品包裝設計) ,
                ConvertToName(SubCategory.插畫漫畫), ConvertToName(SubCategory. 織品服裝設計) ,
                ConvertToName(SubCategory.命名Slogan標語), ConvertToName(SubCategory.ICON設計) ,
            } },


            new Cate{Category = Category.網頁設計, Icon="far fa-window-restore", SubCategories = new List<string>
            { 
                ConvertToName(SubCategory.網頁版型設計), ConvertToName(SubCategory.網頁切版製作) ,
                ConvertToName(SubCategory.EDM設計), ConvertToName(SubCategory.廣告Banner),
                ConvertToName(SubCategory.網站維護經營), ConvertToName(SubCategory.網站行銷SEO),
                ConvertToName(SubCategory.網站程式設計網站架設), ConvertToName(SubCategory.網拍商品上架),
                 ConvertToName(SubCategory.UIUX設計),
            } },


            new Cate{Category = Category.程式開發, Icon="far fa-heart", SubCategories = new List<string>{ ConvertToName(SubCategory.名片信封設計), ConvertToName(SubCategory.LOGO商標設計) } }
        };

        private static string ConvertToName(SubCategory subCategory)
        {
            return SubCategoryNameMapping.ContainsKey(subCategory) ? SubCategoryNameMapping[subCategory] : subCategory.ToString();
        }

    }
}