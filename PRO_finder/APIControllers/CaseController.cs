using PRO_finder.Models.ViewModels;
using PRO_finder.Models.ViewModels.APIModels.APIBase;
using PRO_finder.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PRO_finder.APIControllers
{
    public class CaseController : ApiController
    {
        private readonly CaseService _caseService;


        public CaseController()
        {
            _caseService = new CaseService();
        }

        [HttpGet]
        public APIResult GetCase(string  Cateid = null)
        {

            List<CaseViewModel> result = new List<CaseViewModel>();
            try
            {
                if (Cateid == null)
                {
                    result = _caseService.GetCasesList().ToList();
                }
                else
                {
                    result = _caseService.GetCasesList().Where(x => x.CategoryID == Int32.Parse(Cateid)).ToList();
                }
                return new APIResult(APIStatus.Success, string.Empty, result);

            }
            catch (Exception ex)
            {
                return new APIResult(APIStatus.Fail, ex.Message, result);
            };
        }

        [HttpPost]
        public APIResult Searchinput(int CateID ,string seacrh)
        {
            List<CaseViewModel> result = new List<CaseViewModel>();
            try
            {
                if (seacrh == null)
                {
                    result = _caseService.GetCasesList().ToList();
                }
                else
                {
                    result = _caseService.GetCasesList().Where(x=>x.Description.Contains(seacrh) &&x.CategoryID== CateID).ToList();
                }
                return new APIResult(APIStatus.Success, string.Empty, result);

            }
            catch (Exception ex)
            {
                return new APIResult(APIStatus.Fail, ex.Message, result);
            };

        }

    }
}
