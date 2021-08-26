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

            context.Quotation.AddOrUpdate(x => x.QuotationID, new Quotation
            {
                QuotationID = 2100,
                QuotationTitle = "各類 寫實 日系 Q版插畫",
                UpdateDate = null,
                QuotationUnit=4,
                ExecuteDate=8,
                MemberID=1,
                Description= "插畫 / 漫畫設計：1、我能為您繪作A4大小以內的插圖(如需其他大小規格可提供)/n2、風格可討論，有參考圖為佳/n3、插畫如有基礎構想、構圖，可事先指定/n4、會依照複雜程度有計價的不同/n5、需事先提供置入之文字、資料等文檔/n6、提供三次免費草圖修改，之後線稿 / 上色可微幅修改三次，超過價錢另計/n7、如有Logo請提供/n8、完成交付指定之檔案格式(jpg.png)9、中途會向您收取一半訂金，完稿時再收取剩下稿費/n10、簽約(討論) > 訂金 > 製作 > 尾款 > 交件 > 結案",
                Evaluation=null,
                SubCategoryID=23,
                Price=5000,
                MainPicture= "https://y.qichejiashi.com/tupian/upload/109121698.jpg"

            });
            context.Quotation.AddOrUpdate(x => x.QuotationID, new Quotation
            {
                QuotationID = 2100,
                QuotationTitle = "各類 寫實 日系 Q版插畫",
                UpdateDate = null,
                QuotationUnit = 4,
                ExecuteDate = 8,
                MemberID = 1,
                Description = "插畫 / 漫畫設計：1、我能為您繪作A4大小以內的插圖(如需其他大小規格可提供)/n2、風格可討論，有參考圖為佳/n3、插畫如有基礎構想、構圖，可事先指定/n4、會依照複雜程度有計價的不同/n5、需事先提供置入之文字、資料等文檔/n6、提供三次免費草圖修改，之後線稿 / 上色可微幅修改三次，超過價錢另計/n7、如有Logo請提供/n8、完成交付指定之檔案格式(jpg.png)9、中途會向您收取一半訂金，完稿時再收取剩下稿費/n10、簽約(討論) > 訂金 > 製作 > 尾款 > 交件 > 結案",
                Evaluation = null,
                SubCategoryID = 23,
                Price = 5000,
                MainPicture = "https://y.qichejiashi.com/tupian/upload/109121698.jpg"

            });
            context.Quotation.AddOrUpdate(x => x.QuotationID, new Quotation
            {
                QuotationID = 2101,
                QuotationTitle = "LINE貼圖繪製40張",
                UpdateDate = null,
                QuotationUnit = 3,
                ExecuteDate = 10,
                MemberID = 1,
                Description = "1.貼圖有分8張、16張、24張、32張、40張，單張250元乘上張數=費用(2000~10000)2.風格可討論(可提供參考圖片為佳)3.會依照角色和複雜程度有計價的不同",
                Evaluation = null,
                SubCategoryID = 12,
                Price = 9000,
                MainPicture = "https://y.qichejiashi.com/tupian/upload/109121697.jpg"

            });
            context.Quotation.AddOrUpdate(x => x.QuotationID, new Quotation
            {
                QuotationID = 2102,
                QuotationTitle = "紙盒的包裝印製",
                UpdateDate = null,
                QuotationUnit = 6,
                ExecuteDate = 15,
                MemberID = 1,
                Description = "針對各種需求衍生出高質感的包裝紙盒設計，配合專業的包裝紙盒印刷技術，印製出客製化的包裝紙盒，讓您的客人在選購完產品後，還可捧著賞心悅目的紙盒包裝，可替貴公司CIS增進不少形象【紙盒包裝印製流程】提供您所需包裝的商品與需求、Logo、商品資訊、文案、刀模或提供可印刷之AI檔→報價→確認合作→設計→打樣→提供您確認是否符合需求→大量印製→出貨",
                Evaluation = null,
                SubCategoryID = 10,
                Price = 90,
                MainPicture = "https://y.qichejiashi.com/tupian/upload/109121699.jpg"

            });
        }
    }
}
