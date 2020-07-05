namespace Fruitify.Services.Data.AppServices
{
    using System.IO;
    using System.Threading.Tasks;

    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using Fruitify.Services.Data.AppServices.Contracts;

    using Microsoft.AspNetCore.Http;

    public class CloudinaryService : ICloudinaryService
    {
        private readonly Cloudinary cloudinary;

        public CloudinaryService(Cloudinary cloudinary)
        {
            this.cloudinary = cloudinary;
        }

        public async Task<string> UploadImageAsync(IFormFile formFile, string fileName, string folder)
        {
            byte[] destinationData;

            using (var memoryStream = new MemoryStream())
            {
                await formFile.CopyToAsync(memoryStream);
                destinationData = memoryStream.ToArray();
            }

            UploadResult uploadResult;

            using (var resultStream = new MemoryStream(destinationData))
            {
                ImageUploadParams uploadParams = new ImageUploadParams()
                {
                    Folder = folder,
                    File = new FileDescription(fileName, resultStream),
                };

                uploadResult = await this.cloudinary.UploadAsync(uploadParams);
            }

            var result = uploadResult?.SecureUri.AbsoluteUri;

            return result;
        }
    }
}
