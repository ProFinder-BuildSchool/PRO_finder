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
                SubCategoryID = 9,
                MemberID = 1

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

     


            context.WorkPictures.AddOrUpdate(x => x.WorkID, new WorkPictures
            {
                WorkPictureID=43,
                WorkID = 20,
                SortNumber = 1,
                WorkPicture = "https://files.bountyhunter.co/bhuntr/public/202107/a9f15d7a-f736-51b1-9a16-f7c3e57e0f79_800x800.jpg",
               

            });
            context.WorkPictures.AddOrUpdate(x => x.WorkID, new WorkPictures
            {
                WorkPictureID = 44,
                WorkID = 19,
                SortNumber = 1,
                WorkPicture = "https://files.bountyhunter.co/bhuntr/public/202104/a748ae26-55d4-4dfe-b88a-ccc4dae16fde_800x800.jpg",

            });
  
            context.WorkPictures.AddOrUpdate(x => x.WorkID, new WorkPictures
            {
                WorkPictureID = 45,
                WorkID = 18,
                SortNumber = 1,
                WorkPicture = "https://files.bountyhunter.co/bhuntr/public/202108/f3d1f96b-e0f7-553c-87c7-976c14f27dba_800x800.jpg",

            });
            context.WorkPictures.AddOrUpdate(x => x.WorkID, new WorkPictures
            {
                WorkPictureID = 46,
                WorkID = 17,
                SortNumber = 1,
                WorkPicture = "https://files.bountyhunter.co/bhuntr/public/202005/3073f3bc-ea35-4aff-87ad-b98b65e43097_800x800.jpg",

            });
            context.WorkPictures.AddOrUpdate(x => x.WorkID, new WorkPictures
            {
                WorkPictureID = 47,
                WorkID = 18,
                SortNumber = 1,
                WorkPicture = "https://files.bountyhunter.co/bhuntr/public/201911/508c1d21-0435-43f3-ad89-737739a993bb_800x800.jpg",

            });
        }
    }
}
