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
                WorkName = "�x�F��R�֩u",
                WorkDescription = "�x�F��R�֩u����DMA3���N�r",
                Client = "�x�F���F��",
                Role = "��׽s��",
                YearStarted = 2017,
                WebsiteURL = "https://bhuntr.com/tw/work/dm-she-ji-2",
                SubCategoryID=9,
                WorkAttachmentID = null,
                MemberID =32

            });

            //context.WorkPictures.AddOrUpdate(x => x.WorkPictureID, new WorkPictures
            //{
            //    //WorkID = 1,
            //    WorkName = "�x�F��R�֩u",
            //    WorkDescription = "�x�F��R�֩u����DMA3���N�r",
            //    Client = "�x�F���F��",
            //    Role = "��׽s��",
            //    YearStarted = 2017,
            //    WebsiteURL = "https://bhuntr.com/tw/work/dm-she-ji-2",
            //    SubCategoryID = 9,
            //    MemberID = 1

            //});

            context.Works.AddOrUpdate(x => x.WorkID, new Works
            {
                WorkID = 16,
                WorkName = "CITY CAFE�@�تM",
                WorkDescription = "�Ӳӫ~���@�ؤ���,�b�L�W��������,�a�۾A�ת��Ĩ�,�̫�a�X�������l��,�W�B�ġB���A�T�ӺI�M���P������,�ۮe�b�@�_�o�@�I�]����o�٬�,�ϦӤ��۬MŨ�۹��",
                Client = "7-11",
                Role = "���s�]�p",
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
                WorkDescription = "�֦��@�f�G�ռ�b�������A�ϤH���o�G���۫H�A�ɱ��i�S���e�CBrighteeth�H�ɩ|�|�]�����W��A��ߥ��y�M�~�N���b�լ��Ǥ��ߡC",
                Client = "�¤H���I",
                Role = "�]�˳]�p",
                YearStarted = 2021,
                WebsiteURL = "https://bhuntr.com/tw/work/brighteeth",
                SubCategoryID =18,
                WorkAttachmentID = null,
                MemberID =32

            });
            context.Works.AddOrUpdate(x => x.WorkID, new Works
            {
                WorkID = 18,
                WorkName = "�@�ة��\��",
                WorkDescription = "�b�饻�Ȧ�ɡA�ګܳ��w�b�@�Ӧa��}�@��ѡC���M�b������ݨ�@�x�\���A�ݨ��ı�o�n�ΪA�S�i�R�A���M�ڵe���ëD�P�@�x���O��ɵ��ڦL�H�ܲ`�C",
                Client = "�@�ة�",
                Role = "�\�I�]�p",
                YearStarted = 2011,
                WebsiteURL = "https://bhuntr.com/tw/work/ka-fei-dian-can-che",
                SubCategoryID =14,
                WorkAttachmentID = null,
                MemberID =32

            });
            context.Works.AddOrUpdate(x => x.WorkID, new Works
            {
                WorkID = 19,
                WorkName = "MUJI�L�L�}�~�x�W15�g�~",
                WorkDescription = "�����ı�c���A�Τ����J�k���X���u�t�����v�r�ӲզX�ƦC�A���C�Ӧr���ı����MUJI�c��ӫ~+MUJI�^���r�ðεۡA�C�Ӧr��]�N��ۨC�@�~���ͬ����A�L�ɵL�賣��MUJI������",
                Client = "�L�L�}�~",
                Role = "�ӫ~�]�p",
                YearStarted = 2019,
                WebsiteURL = "https://bhuntr.com/tw/work/ban-she-ji-zheng-jian-zhanmuji-wu-yin-liang-pin-tai-wan15zhou-nian-tong-shang",
                SubCategoryID =16,
                WorkAttachmentID=null,
                MemberID =32

            });
            context.Works.AddOrUpdate(x => x.WorkID, new Works
            {
                WorkID = 20,
                WorkName = "�}�o�W���]�p",
                WorkDescription = "���֬��n�������ͬ��v�O�{�N�H�ڴK�H�D���z�Q�ͬ��A�H���Q�����ӵξA���ͬ��~��P�w�����͵����ҡA�ݭn�M�~���u�{���q�����W���B½�s�A",
                Client = "���ؤj��",
                Role = "���s�]�p",
                YearStarted = 2021,
                WebsiteURL = "https://bhuntr.com/tw/work/jian-dan-de-xian-tiao-liu-xing-de-se-cai-biao-xian-ming-pian-she-ji-de-zui-gao-jia-zhihe-sheng-gong-cheng-kai-fa-ming-pian-she-ji",
                SubCategoryID =11,
                WorkAttachmentID = null,
                MemberID =32

            });
        }
    }
}
