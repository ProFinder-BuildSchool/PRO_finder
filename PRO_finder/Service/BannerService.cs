using PRO_finder.Models.DBModel;
using PRO_finder.Models.ViewModels;
using PRO_finder.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRO_finder.Service
{
    public class BannerService
    {
        private readonly GeneralRepository _ctx;

        public BannerService()
        {

            _ctx = new GeneralRepository(new ProFinderContext());

        }

        public List<BannerViewModel> GetBanner()
        {
            return _ctx.GetAll<Banner>().Select(X => new BannerViewModel {
                BannerImgUrl=X.BannerImgUrl
            }).ToList();

        }


    }
}