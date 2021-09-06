using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PRO_finder.Helper
{
    public class CloudinaryHelper
    {
        private readonly Account _account;
        private readonly Cloudinary _cloudinary;
        public CloudinaryHelper()
        {
            _account = new Account("dwwmf9pyq", "691819382586651", "wOf6jj4sSd582t4ohD85sQ7k5ag");
            _cloudinary = new Cloudinary(_account);
            _cloudinary.Api.Secure = true;
        }
        public async Task<string> UploadCloudinaryAsync(HttpPostedFileBase file)
        {
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(file.FileName, file.InputStream)
            };
            Task<ImageUploadResult> imageUploadTask = _cloudinary.UploadAsync(uploadParams);
            var uploadResult = await imageUploadTask;
            return uploadResult.SecureUri.AbsoluteUri;
        }

    }
}