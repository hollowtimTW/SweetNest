namespace SweetNest.Services.ProductAPI.Service
{
    public interface ICloudStorageService
    {
        Task<string> UploadFileAsync(string fileName, string filePath, IFormFile file);
        Task<bool> UpdateFileAsync(string fileName, string filePath, IFormFile newFile);
        Task<bool> DeleteFileAsync(string fileName, string filePath);
    }
}
