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
                QuotationTitle = "�U�� �g�� ��t Q�����e",
                UpdateDate = null,
                QuotationUnit=4,
                ExecuteDate=8,
                MemberID=1,
                Description= "���e / ���e�]�p�G1�B�گର�zø�@A4�j�p�H��������(�p�ݨ�L�j�p�W��i����)/n2�B����i�Q�סA���ѦҹϬ���/n3�B���e�p����¦�c�Q�B�c�ϡA�i�ƥ����w/n4�B�|�̷ӽ����{�צ��p�������P/n5�B�ݨƥ����Ѹm�J����r�B��Ƶ�����/n6�B���ѤT���K�O��ϭק�A����u�Z / �W��i�L�T�ק�T���A�W�L�����t�p/n7�B�p��Logo�д���/n8�B������I���w���ɮ׮榡(jpg.png)9�B���~�|�V�z�����@�b�q���A���Z�ɦA�����ѤU�Z�O/n10�Bñ��(�Q��) > �q�� > �s�@ > ���� > ��� > ����",
                Evaluation=null,
                SubCategoryID=23,
                Price=5000,
                MainPicture= "https://y.qichejiashi.com/tupian/upload/109121698.jpg"

            });
            context.Quotation.AddOrUpdate(x => x.QuotationID, new Quotation
            {
                QuotationID = 2100,
                QuotationTitle = "�U�� �g�� ��t Q�����e",
                UpdateDate = null,
                QuotationUnit = 4,
                ExecuteDate = 8,
                MemberID = 1,
                Description = "���e / ���e�]�p�G1�B�گର�zø�@A4�j�p�H��������(�p�ݨ�L�j�p�W��i����)/n2�B����i�Q�סA���ѦҹϬ���/n3�B���e�p����¦�c�Q�B�c�ϡA�i�ƥ����w/n4�B�|�̷ӽ����{�צ��p�������P/n5�B�ݨƥ����Ѹm�J����r�B��Ƶ�����/n6�B���ѤT���K�O��ϭק�A����u�Z / �W��i�L�T�ק�T���A�W�L�����t�p/n7�B�p��Logo�д���/n8�B������I���w���ɮ׮榡(jpg.png)9�B���~�|�V�z�����@�b�q���A���Z�ɦA�����ѤU�Z�O/n10�Bñ��(�Q��) > �q�� > �s�@ > ���� > ��� > ����",
                Evaluation = null,
                SubCategoryID = 23,
                Price = 5000,
                MainPicture = "https://y.qichejiashi.com/tupian/upload/109121698.jpg"

            });
            context.Quotation.AddOrUpdate(x => x.QuotationID, new Quotation
            {
                QuotationID = 2101,
                QuotationTitle = "LINE�K��ø�s40�i",
                UpdateDate = null,
                QuotationUnit = 3,
                ExecuteDate = 10,
                MemberID = 1,
                Description = "1.�K�Ϧ���8�i�B16�i�B24�i�B32�i�B40�i�A��i250�����W�i��=�O��(2000~10000)2.����i�Q��(�i���ѰѦҹϤ�����)3.�|�̷Ө���M�����{�צ��p�������P",
                Evaluation = null,
                SubCategoryID = 12,
                Price = 9000,
                MainPicture = "https://y.qichejiashi.com/tupian/upload/109121697.jpg"

            });
            context.Quotation.AddOrUpdate(x => x.QuotationID, new Quotation
            {
                QuotationID = 2102,
                QuotationTitle = "�Ȳ����]�˦L�s",
                UpdateDate = null,
                QuotationUnit = 6,
                ExecuteDate = 15,
                MemberID = 1,
                Description = "�w��U�ػݨD�l�ͥX����P���]�˯Ȳ��]�p�A�t�X�M�~���]�˯Ȳ��L��޳N�A�L�s�X�Ȼs�ƪ��]�˯Ȳ��A���z���ȤH�b���ʧ����~��A�٥i���۽�߮��ت��Ȳ��]�ˡA�i���Q���qCIS�W�i���֧ζH�i�Ȳ��]�˦L�s�y�{�j���ѱz�һݥ]�˪��ӫ~�P�ݨD�BLogo�B�ӫ~��T�B��סB�M�ҩδ��ѥi�L�ꤧAI�ɡ��������T�{�X�@���]�p�����ˡ����ѱz�T�{�O�_�ŦX�ݨD���j�q�L�s���X�f",
                Evaluation = null,
                SubCategoryID = 10,
                Price = 90,
                MainPicture = "https://y.qichejiashi.com/tupian/upload/109121699.jpg"

            });
        }
    }
}
