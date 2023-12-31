﻿using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using ProjectSEM3.DTOs.Auth;
using System.Linq;

namespace ProjectSEM3.Services
{
    public  class UploadImg
    {
        async static public Task<CdnItem> Upload(IFormFile? img,string? folder,string? filename,string? tag)
        {
            Cloudinary cloudinary = new Cloudinary(Environment.GetEnvironmentVariable("CLOUDINARY_URL"));
            cloudinary.Api.Secure = true;
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(filename, img.OpenReadStream()),
                UseFilename = true, 
                UniqueFilename = false, // 
                Overwrite = false,
                Folder = folder,  // 
                Tags= tag,
                PublicId = filename, // ten sp
            };
            var uploadResult = await cloudinary.UploadAsync(uploadParams);
            var rs = uploadResult.JsonObj;
            return rs.ToObject<CdnItem>();
        }


        async static public Task<CdnItem> UploadStr(string url, string? folder, string? filename, string? tag)
        {
            Cloudinary cloudinary = new Cloudinary(Environment.GetEnvironmentVariable("CLOUDINARY_URL"));
            cloudinary.Api.Secure = true;
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(url),
                UseFilename = true,
                UniqueFilename = false, // 
                Overwrite = false,
                Folder = folder,  // 
                Tags = tag,
                PublicId = filename, // ten sp
            };
            var uploadResult = await cloudinary.UploadAsync(uploadParams);
            var rs = uploadResult.JsonObj;
            return rs.ToObject<CdnItem>();
        }


        async static public Task<Object> getImg(string? folder)
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
                Prefix = "Products/sp6",
                MaxResults=10
            };
            var listResourcesResult = cloudinary.ListResources(listResourcesByPrefixParams);
            return listResourcesResult.JsonObj.ToObject<Object>();
        }

        async static public Task<bool> DeleteImg (string? publicId)
        {
            try
            {
                Cloudinary cloudinary = new Cloudinary(Environment.GetEnvironmentVariable("CLOUDINARY_URL"));
                var check = await cloudinary.GetResourceAsync(publicId);
                if (check.StatusCode == System.Net.HttpStatusCode.NotFound) return false;
                await cloudinary.DeleteResourcesAsync(ResourceType.Image, publicId);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            
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
