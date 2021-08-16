using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PRO_finder.Models;
using PRO_finder.Models.DBModel;

namespace PRO_finder.Repository
{
    public class MemInfoRepository
    {
        private readonly ProFinderContext _ctx;
        public MemInfoRepository()
        {
            _ctx = new ProFinderContext();
        }
        public List<MemberInfo> ReadMemInfoData()
        {
            var MemInfoList = _ctx.MemberInfo.ToList();
            return MemInfoList;
        }
    }
}