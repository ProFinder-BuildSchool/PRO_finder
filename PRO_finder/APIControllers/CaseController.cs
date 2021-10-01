using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using PRO_finder.Models.DBModel;
using PRO_finder.Models.ViewModels;
using PRO_finder.Models.ViewModels.APIModels.APIBase;
using PRO_finder.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Configuration;
using System.Web.Hosting;
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
        public HttpResponseMessage PostNewCase()
        {
            var request = HttpContext.Current.Request;
            int fileslen = request.Files.Count;
            CaseDetailViewModel newCase = JsonConvert.DeserializeObject<CaseDetailViewModel>(request["newCase"]);

            if (newCase == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                try
                {
                    string userID = User.Identity.GetUserId();
                    int memberID = _memberService.GetMemberID(userID);
                    newCase.MemberID = memberID;

                    List<CaseReference> refList = new List<CaseReference>(); 
                    for(int i = 0; i < fileslen; i++)
                    {
                        HttpPostedFile file = request.Files[i];
                        string fileSavePath = WebConfigurationManager.AppSettings["UploadPath"];
                        string newFileName = string.Concat(Path.GetRandomFileName().Replace(".", ""), Path.GetExtension(file.FileName).ToLower());
                        string fullFilePath = Path.Combine(HostingEnvironment.MapPath(fileSavePath), newFileName);
                        file.SaveAs(fullFilePath);

                        refList.Add( new CaseReference
                        {
                            CaseRef = fullFilePath
                        });
                        
                        
                    }
                    _caseService.CreateNewCase(memberID, newCase, refList);
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(ex.Message);
                }
            }
            
        }
    }
}
