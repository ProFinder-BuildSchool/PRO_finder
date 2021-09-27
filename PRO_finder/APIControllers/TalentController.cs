﻿using Microsoft.AspNet.Identity;
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
        public APIResult CreateQuotation([FromBody] CreateQuotationViewModel newQ)
        {
            int result = 0;
            try
            {
                string userID = User.Identity.GetUserId();
                newQ.MemberID = _memberInfoService.GetMemberID(userID);
                var newQ_entity = _quotationService.CreateQuotation(newQ);
                result = newQ_entity.QuotationID;
                return new APIResult(APIStatus.Success, string.Empty, result);
            }
            catch (Exception ex)
            {
                result = -1;
                return new APIResult(APIStatus.Fail, ex.Message, result);
            }
        }
        [HttpPost]
        public HttpResponseMessage UploadOtherPics()
        {
            var request = HttpContext.Current.Request;
            int fileslen = request.Files.Count;
            if (fileslen <= 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                
                int quotationID = Int32.Parse(request["QuotationID"]);
                try
                {
                    //接收Picture File
                    for(int i = 0; i < fileslen; i++)
                    {
                        HttpPostedFile picture = request.Files[i];
                        //cloudinary上傳
                        string link = _cloudinaryHelper.UploadToCloudinary(picture);
                        //new entity
                        UploadOtherPicture newPic = new UploadOtherPicture
                        {
                            OtherPictureLink = link,
                            QuotationID = quotationID,
                            SortNumber = i
                        };
                        //儲存
                        _quotationService.RevisedCreateOtherPics(newPic);
                    };
                    //回傳
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(ex.Message);
                }
            }
        }
        public APIResult UpdateQuotation([FromBody] CreateQuotationViewModel updateQ)
        {
            string result = "";
            try
            {
                _quotationService.UpdateQuotation(updateQ);
                result = "成功更新";
                return new APIResult(APIStatus.Success, string.Empty, result);
            }
            catch (Exception ex)
            {
                result = "更新失敗";
                return new APIResult(APIStatus.Fail, ex.Message, result);
            }
        }

        [HttpPost]
        public HttpResponseMessage UPDATEOtherPics()
        {
            var request = HttpContext.Current.Request;
            int fileslen = request.Files.Count;
            if (fileslen <= 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                
                int quoID = Int32.Parse(request["QuotationID"]);
                try
                {
                    for(int i = 0; i < fileslen; i++)
                    {
                        //接收Picture File及其他參數
                        HttpPostedFile picture = request.Files[i];

                        //cloudinary上傳
                        string link = _cloudinaryHelper.UploadToCloudinary(picture);
                        //new entity
                        UploadOtherPicture newPic = new UploadOtherPicture
                        {
                            OtherPictureLink = link,
                            QuotationID = quoID,
                            SortNumber = i
                        };
                        //刪除原先資料
                        if (newPic.SortNumber == 0)
                        {
                            _quotationService.DeleteOriginPics(newPic.QuotationID);
                        }
                        //儲存
                        _quotationService.RevisedCreateOtherPics(newPic);
                    }
                    
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
        public APIResult UploadMyWork([FromBody] UploadMyWorksViewModel newWorks)
        {
            //取得memberID,並加至newWorks
            string userID = User.Identity.GetUserId();
            newWorks.MemberID = _memberInfoService.GetMemberID(userID);
            var newEntity = _worksService.CreateWorks(newWorks);
            int workID = newEntity.WorkID;
            return new APIResult(APIStatus.Success, string.Empty, workID);
        }
        [HttpPost]
        public HttpResponseMessage UploadFile()
        {
            var request = HttpContext.Current.Request;
            int fileslen = request.Files.Count;
            if (fileslen <= 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                try
                {
                    //取得workNameList
                    string worknames = request["FileNames"];
                    JArray worknameArray = JArray.Parse(worknames);
                    List<string> worknameList = worknameArray.ToObject<List<string>>();

                    int workID = Int32.Parse(request["WorkID"]);

                    
                    for(int i = 0; i < fileslen; i ++)
                    {
                        HttpPostedFile file = request.Files[i];
                        string fileSavePath = WebConfigurationManager.AppSettings["UploadPath"];
                        string newFileName = string.Concat(Path.GetRandomFileName().Replace(".", ""), Path.GetExtension(file.FileName).ToLower());
                        string fullFilePath = Path.Combine(HostingEnvironment.MapPath(fileSavePath), newFileName);
                        file.SaveAs(fullFilePath);

                        WorkAttachmentViewModel newWorkAttachment = new WorkAttachmentViewModel
                        {
                            WorkAttachmentLink = fullFilePath,
                            WorkAttachmentName = worknameList[i],
                            WorkID = workID
                        };

                        _worksService.RevisedCreateWorkAttachment(newWorkAttachment);
                    }
                    return Request.CreateResponse(HttpStatusCode.OK);

                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(ex.Message);
                }
            }
        }
        [HttpPost]
        public HttpResponseMessage UploadWorkPics()
        {
            var request = HttpContext.Current.Request;
            int fileCount = request.Files.Count;
            if (fileCount <= 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                try
                {
                    
                    int workID = Int32.Parse(request["WorkID"]);

                    for (int i = 0; i < fileCount; i++)
                    {
                        HttpPostedFile file = request.Files[i];
                        string link = _cloudinaryHelper.UploadToCloudinary(file);
                        WorkPicturesViewModel newPic = new WorkPicturesViewModel()
                        {
                            WorkID = workID,
                            SortNumber = i,
                            WorkPicture = link
                        };
                        _worksService.RevisedCreateWorkPictures(newPic);
                    }
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
    }
}