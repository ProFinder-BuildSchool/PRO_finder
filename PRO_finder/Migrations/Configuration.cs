namespace PRO_finder.Migrations
{
    using PRO_finder.Models.DBModel;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PRO_finder.Models.DBModel.ProFinderContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PRO_finder.Models.DBModel.ProFinderContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Works.AddOrUpdate(x => x.WorkID, new Works
            {

                WorkID = 1,
                WorkName = "ScalpX簡易頭皮檢測軟體",
                WorkDescription = "1.搭配建議的數位顯微鏡使用此app\n2.隨插即用，隨拍即存\n3.可做Before & After頭皮護理前後比對\n4.可將圖檔另外儲存於裝置中\n5.可於裝置上編輯名稱、分享及儲存所拍攝之頭皮圖片\n6.提供使用者便利即時的頭皮檢測工具",
                Client = "美科實業有限公司",
                Role = "App開發工程師",
                YearStarted = 2020,
                WebsiteURL = "https://play.google.com/store/apps/details?id=com.scalpx.scalpxdetectionLite&hl=zh_TW&gl=US",
                SubCategoryID = 3,
                MemberID=1
            });

        }
    }
}
