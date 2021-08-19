using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using PRO_finder.Models.DBModel;

namespace PRO_finder.Models.ViewModels
{

    public class MemberInfoViewModel
    {
      
        public int MemberID { get; set; }

        public string Cellphone { get; set; }

        public string Email { get; set; }

        public DateTime? LogInTime { get; set; }

        public string Password { get; set; }

        public byte[] RegistedTime { get; set; }

        public TimeSpan? EditedTime { get; set; }

        public bool? isDeleted { get; set; }

        public TimeSpan? CreateUser { get; set; }

        public TimeSpan? UpdateUser { get; set; }

        public decimal? Balance { get; set; }

        public byte[] ProfilePicture { get; set; }

        public bool? Status { get; set; }

        public string NickName { get; set; }

        public enum IdentityStatus
        {
            �ӤH��¾, �M¾SOHO, �u�@��, ��¾�W�Z��, ���q, �ǥ�
        }
        public IdentityStatus Identity { get; set; }

        public int? LiveCity { get; set; }

        public int? TalentCategoryID { get; set; }

        public enum LocationCity
        {
            �y����, �򶩥�, �O�_��, �s�_��, ��饫, �s�˥�, �s�˿�,
            �x����, �]�߿�, ���ƿ�, ���L��, �n�뿤, �Ÿq��, �Ÿq��, �x�n��, ������,
            �̪F��, ���, �x�F��, �Ὤ��, ��L���q
        }
        public LocationCity LocationID { get; set; }

        public int? CategoryID { get; set; }

        public int? SubCategoryID { get; set; }

        public string AllPieceworkExp { get; set; }

        public string Description { get; set; }

        public string UserId { get; set; }

    }
}
