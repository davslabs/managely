using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace Managely.Providers;

public interface ICloudinaryProvider
{
    Task<string> Upload(IFormFile file);
} 

public class CloudinaryProvider : ICloudinaryProvider
{
    private readonly Cloudinary _cloudinary;
    
    public CloudinaryProvider(IConfiguration configuration)
    {
        string apiKey = configuration.GetValue<string>("Cloudinary:CloudinaryApiKey");
        string apiSecret = configuration.GetValue<string>("Cloudinary:CloudinarySecretKey");
        string cloudName = configuration.GetValue<string>("Cloudinary:CloudinaryAccount");
        var myAccount = new Account { Cloud = cloudName, ApiKey = apiKey, ApiSecret = apiSecret };
        _cloudinary = new Cloudinary(myAccount);
    }
    
    public async Task<string> Upload(IFormFile file)
    {
        ImageUploadParams uploadParams = new ImageUploadParams()
        {
            File = new FileDescription(file.FileName, file.OpenReadStream())
        };

        var uploadResult = await _cloudinary.UploadAsync(uploadParams)
            .ConfigureAwait(false);
        
        return uploadResult.Url.AbsoluteUri;
    }
}