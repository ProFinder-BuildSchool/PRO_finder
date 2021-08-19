using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PRO_finder.Models.DBModel;
using PRO_finder.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace PRO_finder.Service
{
    public class MemberinfoService
        {

            public List<MemberInfo> getMemberInfoItem()
            {
                using (ProFinderContext context = new ProFinderContext())
                {
                    List<MemberInfo> memberinfoList = context.MemberInfo.ToList();

                return memberinfoList;

                }
            }


        }
}