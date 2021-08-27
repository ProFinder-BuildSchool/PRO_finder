using PRO_finder.Models.ViewModels.APIModels.APIBase;
using PRO_finder.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PRO_finder.APIControllers
{
    public class TalentController : ApiController
    {
        private readonly CategoryService _cateService;
        private readonly MemberinfoService _memberInfoService;
        public TalentController()
        {
            _cateService = new CategoryService();
            _memberInfoService = new MemberinfoService();
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
    }
}
