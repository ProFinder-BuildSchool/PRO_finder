using Microsoft.AspNet.Identity;
using PRO_finder.Models.ViewModels;
using PRO_finder.Models.ViewModels.APIModels.APIBase;
using PRO_finder.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace PRO_finder.APIControllers
{
    public class CaseController : ApiController
    {
        private readonly CaseService _caseService;
        private readonly MemberinfoService _memberService;

        public CaseController()
        {
            _caseService = new CaseService();
            _memberService = new MemberinfoService();
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

        //Api For CreateNewCase
        [HttpGet]
        public APIResult GetCategoryList()
        {
            string result = "";
            try
            {
                result = _caseService.GetAllCategory();
                return new APIResult(APIStatus.Success, "", result);
            }
            catch(Exception ex)
            {
                return new APIResult(APIStatus.Fail, ex.Message, result);
            }
        }

        [HttpGet]
        public APIResult GetLocationList()
        {
            string result = "";
            try
            {
                result = _caseService.GetLocationList();
                return new APIResult(APIStatus.Success, "", result);
            }
            catch(Exception ex)
            {
                return new APIResult(APIStatus.Fail, ex.Message, result);
            }
        }
        [HttpPost]
        public APIResult PostNewCase([FromBody]CaseDetailViewModel newCase)
        {
            int result = 0;
            string userID = User.Identity.GetUserId();
            int memberID = _memberService.GetMemberID(userID);
            try
            {
                result = _caseService.CreateNewCase(memberID, newCase);
                return new APIResult(APIStatus.Success, "", result);
            }
            catch(Exception ex)
            {
                return new APIResult(APIStatus.Fail, ex.Message, result);
            }
        }
        //[HttpPost]
        //public APIResult PostNewCaseFile(int caseID)
        //{
        //    string result = "";
        //    try
        //    {
        //        HttpPostedFile file = 
        //    }
        //    catch(Exception ex)
        //    {
        //        return new APIResult(APIStatus.Success, ex.Message, result);
        //    }
        //}
    }
}
