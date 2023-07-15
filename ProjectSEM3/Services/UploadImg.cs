using CloudinaryDotNet.Actions;
using CloudinaryDotNet;

namespace ProjectSEM3.Services
{
    public class UploadImg
    {
        public UploadImg() { }

        async public Task<string> Upload(string? url,string? folder,string? filename)
        {
            Cloudinary cloudinary = new Cloudinary(Environment.GetEnvironmentVariable("CLOUDINARY_URL"));
            cloudinary.Api.Secure = true;
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(@"https://www.copahost.com/blog/wp-content/uploads/2019/11/O-QUE-%C3%89-CMS-1-340x170.png"),
                UseFilename = true,
                UniqueFilename = false,
                Overwrite = true,
                Folder = "User",
                PublicId="hoangnam",
            };
            var uploadResult = await cloudinary.UploadAsync(uploadParams);
            var rs = uploadResult.JsonObj;
            return rs.ToString();
        }
    }
}
