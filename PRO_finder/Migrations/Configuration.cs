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
                WorkName = "ScalpX²���Y���˴��n��",
                WorkDescription = "1.�f�t��ĳ���Ʀ���L��ϥΦ�app\n2.�H���Y�ΡA�H��Y�s\n3.�i��Before & After�Y���@�z�e����\n4.�i�N���ɥt�~�x�s��˸m��\n5.�i��˸m�W�s��W�١B���ɤ��x�s�ҩ��ᤧ�Y�ֹϤ�\n6.���ѨϥΪ̫K�Q�Y�ɪ��Y���˴��u��",
                Client = "�����~�������q",
                Role = "App�}�o�u�{�v",
                YearStarted = 2020,
                WebsiteURL = "https://play.google.com/store/apps/details?id=com.scalpx.scalpxdetectionLite&hl=zh_TW&gl=US",
                SubCategoryID = 3,
                MemberID=1
            });

        }
    }
}
