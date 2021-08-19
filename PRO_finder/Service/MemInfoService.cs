using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PRO_finder.Models.DBModel;
using PRO_finder.Repositories;
using PRO_finder.Models.ViewModels;

namespace PRO_finder.Service
{
    public class MemInfoService
    {
        private readonly MemInfoRepository _MemInfoRepo;

        public MemInfoService()
        {
            _MemInfoRepo = new MemInfoRepository();
        }
        public MemberInfoViewModel GetMemInfoData(int Memid)
        {

            List<MemberInfo> MemInfoList = _MemInfoRepo.ReadMemInfoData();
            if (MemInfoList.Count == 0)
            {
                return null;
            }
            MemberInfoViewModel MemInfoVM = MemInfoList.Where(x => x.MemberID == Memid)
                .Select(x => new MemberInfoViewModel
                {
                    MemberID = x.MemberID,
                    NickName = x.NickName,
                    LogInTime = x.LogInTime,
                    Identity = (MemberInfoViewModel.IdentityStatus)x.Identity
                    //SubCategoryID = x.SubCategoryID


                }).FirstOrDefault();
            

            return MemInfoVM;
        }

    }
}