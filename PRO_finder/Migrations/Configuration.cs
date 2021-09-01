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
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Works.AddOrUpdate(x => x.WorkID, new Works
            {
                WorkID = 15,
                WorkName = "台東秋收舞樂季",
                WorkDescription = "台東秋收舞樂季活動DMA3對折N字",
                Client = "台東市政府",
                Role = "文案編輯",
                YearStarted = 2017,
                WebsiteURL = "https://bhuntr.com/tw/work/dm-she-ji-2",
                SubCategoryID=9,
                WorkAttachmentID = null,
                MemberID =32

            });

            //context.WorkPictures.AddOrUpdate(x => x.WorkPictureID, new WorkPictures
            //{
            //    //WorkID = 1,
            //    WorkName = "台東秋收舞樂季",
            //    WorkDescription = "台東秋收舞樂季活動DMA3對折N字",
            //    Client = "台東市政府",
            //    Role = "文案編輯",
            //    YearStarted = 2017,
            //    WebsiteURL = "https://bhuntr.com/tw/work/dm-she-ji-2",
            //    SubCategoryID = 9,
            //    MemberID = 1

            //});

            context.Works.AddOrUpdate(x => x.WorkID, new Works
            {
                WorkID = 16,
                WorkName = "CITY CAFE咖啡杯",
                WorkDescription = "細細品味咖啡之香,在微苦的滋味中,帶著適度的酸味,最後帶出甜味的餘韻,苦、酸、甜，三個截然不同的滋味,相容在一起卻一點也不顯得矛盾,反而互相映襯著對方",
                Client = "7-11",
                Role = "美編設計",
                YearStarted = 2010,
                WebsiteURL = "https://bhuntr.com/tw/work/city-cafe-ka-fei-bei-2",
                SubCategoryID =13,
                WorkAttachmentID = null,
                MemberID =32

            });
            context.Works.AddOrUpdate(x => x.WorkID, new Works
            {
                WorkID = 17,
                WorkName = "Brighteeth",
                WorkDescription = "擁有一口亮白潔淨的牙齒，使人散發亮采自信，盡情展露笑容。Brighteeth以時尚會館的高規格，精心打造專業冷光淨白美學中心。",
                Client = "黑人牙膏",
                Role = "包裝設計",
                YearStarted = 2021,
                WebsiteURL = "https://bhuntr.com/tw/work/brighteeth",
                SubCategoryID =18,
                WorkAttachmentID = null,
                MemberID =32

            });
            context.Works.AddOrUpdate(x => x.WorkID, new Works
            {
                WorkID = 18,
                WorkName = "咖啡店餐車",
                WorkDescription = "在日本旅行時，我很喜歡在一個地方逛一整天。偶然在六本木看到一台餐車，看到時覺得好舒服又可愛，雖然我畫的並非同一台但是當時給我印象很深。",
                Client = "咖啡店",
                Role = "餐點設計",
                YearStarted = 2011,
                WebsiteURL = "https://bhuntr.com/tw/work/ka-fei-dian-can-che",
                SubCategoryID =14,
                WorkAttachmentID = null,
                MemberID =32

            });
            context.Works.AddOrUpdate(x => x.WorkID, new Works
            {
                WorkID = 19,
                WorkName = "MUJI無印良品台灣15週年",
                WorkDescription = "整體視覺構成，用中文輸入法打出的「ㄅㄢˋ」字來組合排列，讓每個字體視覺都有MUJI販售商品+MUJI英文單字藏匿著，每個字體也代表著每一年的生活中，無時無刻都有MUJI的陪伴",
                Client = "無印良品",
                Role = "商品設計",
                YearStarted = 2019,
                WebsiteURL = "https://bhuntr.com/tw/work/ban-she-ji-zheng-jian-zhanmuji-wu-yin-liang-pin-tai-wan15zhou-nian-tong-shang",
                SubCategoryID =16,
                WorkAttachmentID=null,
                MemberID =32

            });
            context.Works.AddOrUpdate(x => x.WorkID, new Works
            {
                WorkID = 20,
                WorkName = "開發名片設計",
                WorkDescription = "幸福美好的城市生活」是現代人夢寐以求的理想生活，人們嚮往有個舒適的生活品質與安全的友善環境，需要專業的工程公司幫忙規劃、翻新，",
                Client = "中華大學",
                Role = "美編設計",
                YearStarted = 2021,
                WebsiteURL = "https://bhuntr.com/tw/work/jian-dan-de-xian-tiao-liu-xing-de-se-cai-biao-xian-ming-pian-she-ji-de-zui-gao-jia-zhihe-sheng-gong-cheng-kai-fa-ming-pian-she-ji",
                SubCategoryID =11,
                WorkAttachmentID = null,
                MemberID =32

            });
        }
    }
}
