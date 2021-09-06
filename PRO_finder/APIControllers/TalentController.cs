using Microsoft.AspNet.Identity;
using PRO_finder.Models.ViewModels.APIModels.APIBase;
using PRO_finder.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace PRO_finder.APIControllers
{
    public class TalentController : ApiController
    {
        private readonly CategoryService _cateService;
        private readonly MemberinfoService _memberInfoService;
        private readonly QuotationService _quotationService;
        public TalentController()
        {
            _cateService = new CategoryService();
            _memberInfoService = new MemberinfoService();
            _quotationService = new QuotationService();
        }
        
        public APIResult GetAllCategoryAndSubCategoryList()
        {
            string result = "";
            try
            {
                result = _cateService.GetAllCatAndSubCat();
                return new APIResult(APIStatus.Success, string.Empty, result);
            }
            catch(Exception ex)
            {
                return new APIResult(APIStatus.Fail, ex.Message, result);
            }
        }

        public APIResult GetSubTool()
        {
            string result = "";
            try
            {
                
                result = _memberInfoService.GetJsonSubTool();
                return new APIResult(APIStatus.Success, string.Empty, result);
            }
            catch (Exception ex)
            {
                return new APIResult(APIStatus.Fail, ex.Message, result);
            } 
        }

        public APIResult GetMemberToolRecord()
        {
            //取得memberID
            string userID = User.Identity.GetUserId();
            int memberID = _memberInfoService.GetMemberID(userID);
            string result = "";
            try
            {
                //尋找memberID 儲存的Tools
                result = _memberInfoService.GetToolRecord(memberID);
                return new APIResult(APIStatus.Success, string.Empty, result);
            }
            catch (Exception ex)
            {
                return new APIResult(APIStatus.Fail, ex.Message, result);
            }
        }

        public APIResult ChangeQuotationStatus([FromBody]QuotationDetailViewModel newStatus)
        {
            string result = "";
            try
            {
                _quotationService.ChangeQStatus(newStatus.QuotationId, newStatus.Status);
                result = "加入成功";
                return new APIResult(APIStatus.Success, string.Empty, result);
            }
            catch(Exception ex)
            {
                return new APIResult(APIStatus.Fail, ex.Message, result);
            }
        }
        
    }
}
