using CloudinaryDotNet.Actions;
using CloudinaryDotNet;

namespace ProjectSEM3.Services
{
    public  class UploadImg
    {
        async static public Task<string> Upload(string? url,string? folder,string? filename)
        {
            Cloudinary cloudinary = new Cloudinary(Environment.GetEnvironmentVariable("CLOUDINARY_URL"));
            cloudinary.Api.Secure = true;
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(@"https://upload.wikimedia.org/wikipedia/commons/b/b5/IMG-20190601-WA0004.jpg"),
                UseFilename = true, 
                UniqueFilename = false, // 
                Overwrite = true,
                Folder = "User",  // 
                PublicId="hoangnam", // ten sp
            };
            var uploadResult = await cloudinary.UploadAsync(uploadParams);
           
            var rs = uploadResult.JsonObj;

           

            return rs.ToString();
        }
        
        async static public Task<String> getImg(string? PublicId)
        {
            Cloudinary cloudinary = new Cloudinary(Environment.GetEnvironmentVariable("CLOUDINARY_URL"));
            /*
                var resourceParams = new GetResourceParams(PublicId);
                var resourceResult = await cloudinary.GetResourceAsync(resourceParams);
                var fd = resourceResult.AssetFolder;
            */
            var listResourcesParams = new ListResourcesParams()
            {
                Type = "upload",
                
                MaxResults = 30
            };
            // get all item with folder
            //    new ListResourcesByAssetFolderParams();
            //    new ListResourcesByContextParams();
            //    new ListResourcesByTagParams();
            var listResourcesByPrefixParams = new ListResourcesByPrefixParams()
            {
                Type = "upload",
                Prefix = "User",
                MaxResults=2
            };
            var listResourcesResult = cloudinary.ListResources(listResourcesByPrefixParams);
            return listResourcesResult.JsonObj.ToString() ;
        }

        static public string CvImgBase64(IFormFile img)
        {
            using (var ms = new MemoryStream())
            {
                img.CopyTo(ms);
                byte[] imgBytes = ms.ToArray();
                string base64str = Convert.ToBase64String(imgBytes);
                return base64str;
            }
        }

        static public byte[] CvImgToBA(IFormFile img)
        {
            using (var ms = new MemoryStream())
            {
                img.CopyTo(ms);
                byte[] imageBytes = ms.ToArray();
                return imageBytes;
            }
        }

        private void useConvertImg(IFormFile img)
        {
            string base64String = CvImgBase64(img);
            byte[] imageBytes = CvImgToBA(img);
        }
    }
}
