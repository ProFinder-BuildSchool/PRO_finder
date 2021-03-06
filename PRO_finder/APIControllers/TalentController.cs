using Microsoft.AspNet.Identity;
using PRO_finder.Models.ViewModels;
using PRO_finder.Helper;
using PRO_finder.Models.ViewModels.APIModels.APIBase;
using PRO_finder.Service;
using PRO_finder.ViewModels;
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
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using PRO_finder.Models.ViewModel;

namespace PRO_finder.APIControllers
{
    public class TalentController : ApiController
    {
        private readonly CategoryService _cateService;
        private readonly MemberinfoService _memberInfoService;
        private readonly QuotationService _quotationService;
        private readonly CloudinaryHelper _cloudinaryHelper;
        private readonly WorksService _worksService;
        public TalentController()
        {
            _cateService = new CategoryService();
            _memberInfoService = new MemberinfoService();
            _quotationService = new QuotationService();
            _cloudinaryHelper = new CloudinaryHelper();
            _worksService = new WorksService();
        }

        public APIResult GetAllCategoryAndSubCategoryList()
        {
            string result = "";
            try
            {
                result = _cateService.GetAllCatAndSubCat();
                return new APIResult(APIStatus.Success, string.Empty, result);
            }
            catch (Exception ex)
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

        [HttpPost]
        public APIResult ChangeQuotationStatus([FromBody] QuotationDetailViewModel newStatus)
        {
            string result = "";
            try
            {
                _quotationService.ChangeQStatus(newStatus.QuotationId, newStatus.Status);
                result = "加入成功";
                return new APIResult(APIStatus.Success, string.Empty, result);
            }
            catch (Exception ex)
            {
                return new APIResult(APIStatus.Fail, ex.Message, result);
            }
        }

       
        [HttpPost]
        public HttpResponseMessage CreateQuotation()
        {
            var request = HttpContext.Current.Request;
            var newQ = JsonConvert.DeserializeObject<CreateQuotationViewModel>(request["newQ"]);
            int fileslen = request.Files.Count;
            if (fileslen <= 0 || newQ == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                try
                {
                    string userID = User.Identity.GetUserId();
                    newQ.MemberID = _memberInfoService.GetMemberID(userID);

                    List<OtherPictureViewModel> otherPicList = new List<OtherPictureViewModel>();
                    //接收Picture File
                    for (int i = 0; i < fileslen; i++)
                    {
                        HttpPostedFile picture = request.Files[i];
                        //cloudinary上傳
                        string link = _cloudinaryHelper.UploadToCloudinary(picture);
                        //加入OtherPicList
                        otherPicList.Add(new OtherPictureViewModel
                        {
                            OtherPictureLink = link,
                            SortNumber = i
                        });
                    };
                    newQ.OtherPicList = otherPicList;
                    _quotationService.CreateQuotation(newQ);
                    //回傳
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(ex.Message);
                }
            }
        }

        [HttpPost]
        public HttpResponseMessage UpdateQuotation()
        {
            var request = HttpContext.Current.Request;
            var updateQ = JsonConvert.DeserializeObject<CreateQuotationViewModel>(request["updateQ"]);
            int fileslen = request.Files.Count;
            if (fileslen <= 0 || updateQ == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                try
                {
                    List<OtherPictureViewModel> otherPicList = new List<OtherPictureViewModel>();
                    for (int i = 0; i < fileslen; i++)
                    {
                        //接收Picture File及其他參數
                        HttpPostedFile picture = request.Files[i];

                        //cloudinary上傳
                        string link = _cloudinaryHelper.UploadToCloudinary(picture);
                        //new entity
                        otherPicList.Add(new OtherPictureViewModel 
                        {
                            OtherPictureLink = link,
                            QuotationID = updateQ.QuotationID,
                            SortNumber = i
                        });
                    }
                    updateQ.OtherPicList = otherPicList;
                    _quotationService.UpdateQuotation(updateQ);

                    //回傳
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(ex.Message);
                }
            }
        }
        [HttpPost]
        public HttpResponseMessage UploadMyWork()
        {
            var request = HttpContext.Current.Request;
            int fileslen = request.Files.Count;
            UploadMyWorksViewModel newWork = JsonConvert.DeserializeObject<UploadMyWorksViewModel>(request["newWork"]);
            List<string> worknameList = JsonConvert.DeserializeObject<List<string>>(request["FileNames"]);
            //string worknames = request["FileNames"];
            //JArray worknameArray = JArray.Parse(worknames);
            //List<string> worknameList = worknameArray.ToObject<List<string>>();

            if (fileslen == 0 || newWork == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                try
                {
                    //newWork資料處理
                    //加入MemberID
                    string userID = User.Identity.GetUserId();
                    newWork.MemberID = _memberInfoService.GetMemberID(userID);

                    //WorkPictures, WorkAttachments資料處理
                    List<WorkPicturesViewModel> picList = new List<WorkPicturesViewModel>();
                    List<WorkAttachmentViewModel> attList = new List<WorkAttachmentViewModel>();

                    for (int i = 0; i < fileslen; i++)
                    {
                        string key = request.Files.GetKey(i);
                        HttpPostedFile file = request.Files[i];
                        if (key == "WorkPicture")
                        {
                            string link = _cloudinaryHelper.UploadToCloudinary(file);
                            picList.Add( new WorkPicturesViewModel()
                            {
                                SortNumber = i,
                                WorkPicture = link
                            });
                        }
                        else if(key == "WorkAttachment")
                        {
                            int nameIndex = 0;
                            string fileSavePath = WebConfigurationManager.AppSettings["UploadPath"];
                            string newFileName = string.Concat(Path.GetRandomFileName().Replace(".", ""), Path.GetExtension(file.FileName).ToLower());
                            string fullFilePath = Path.Combine(HostingEnvironment.MapPath(fileSavePath), newFileName);
                            file.SaveAs(fullFilePath);
                            attList.Add(new WorkAttachmentViewModel
                            {
                                WorkAttachmentLink = fullFilePath,
                                WorkAttachmentName = worknameList[nameIndex]
                            });
                            nameIndex++;
                        }
                        
                    }
                    newWork.WorkPictureList = picList;
                    newWork.WorkAttachmentList = attList;
                    _worksService.CreateWorks(newWork);
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                catch(Exception ex)
                {
                    return Request.CreateResponse(ex.Message);
                }
            }
        }
        [HttpPost]
        public APIResult ChangeBankAccount([FromBody] BankAccountViewModel newStatus)
        {
            var op_result = _memberInfoService.UpdateBankAccount(newStatus);
            if (op_result.IsSuccessful)
                return new APIResult(APIStatus.Success, string.Empty, "");
            else
                return new APIResult(APIStatus.Fail, op_result.Exception.ToString(), "");

        }

        [HttpPost]
        public APIResult UpdateMemberInfoData(int memberId, MemberInfoViewModel memberdata)
        {
            try
            {
                var result = _memberInfoService.UpdateMemberInfoData( memberId,memberdata);
                return new APIResult(APIStatus.Success, string.Empty, result);
            }
            catch (Exception ex)
            {
                string result = "";
                return new APIResult(APIStatus.Fail, ex.Message, result);
            }
        } 
    }
}