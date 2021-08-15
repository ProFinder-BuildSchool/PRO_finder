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
                WorkID = 1,
                WorkName = "ScalpX",
                WorkDescription = "1.搭配建議的數位顯微鏡使用此app 2.隨插即用，隨拍即存 3.可做Before & After頭皮護理前後比對 4.可將圖檔另外儲存於裝置中 5.可於裝置上編輯名稱、分享及儲存所拍攝之頭皮圖片 6.提供使用者便利即時的頭皮檢測工具",
                Client= "美科",
                Role="前端",
                YearStarted=2020,
                WebsiteURLID= "https://play.google.com/store/apps/details?id=com.scalpx.scalpxdetectionLite&hl=zh_TW&gl=US",
                SubCategoryID=22,
                WorkAttachmentID=null

            });

            //context.MemberInfo.AddOrUpdate(x => x.MemberID, new MemberInfo
            //{
            //    MemberID = 1,
            //    Cellphone = "078573579",
            //    Email = ,
            //    LogInTime = 1,
            //    Password = "前端",
            //    RegistedTime=,
            //    EditedTime=,
            //    isDeleted=,
            //    CreateUser=,
            //    UpdateUser=,
            //    Balance=,
            //    ProfilePicture=,
            //    Status=,
            //    NickName=,
            //    Identity=,
            //    LiveCity=,
            //    TalentCategoryID=,
            //    LocationID=,
            //    CategoryID=,
            //    AllPieceworkExp=,
            //    Description=,
            //    UserId=,
            //    Case=,
            //    Case1=,
            //    Experience=,
            //    HostingDetail=,
            //    Message=,
            //    Message1=,
            //    Order=,
            //    SaveStaff=,
            //    SaveStaff1=,
            //    ServicePlus=,
            //    ProposalRecord=,
            //    ReplyFrequency=,
            //    QuotationDetail=


            //});

            context.WorkPictures.AddOrUpdate(x => x.WorkPictureID, new WorkPictures
            {
                //WorkID= 1,
                //WorkPictureID = 1,
                //WorkPicture= http://www.ntpceasygo.com.tw/images/case06_clip_image002.jpg,
                //SortNumber =1
            });
            //context.Users.AddOrUpdate(x => x.Id, new User
            //{
            //    Id = 3,
            //    UserName = "Tom ",
            //    Email = "tom@gmail.com"
            //});
        }
    }
}
