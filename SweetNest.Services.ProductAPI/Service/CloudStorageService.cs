using Google.Cloud.Storage.V1;

namespace SweetNest.Services.ProductAPI.Service
{

    public class GcpCloudStorageService : ICloudStorageService
    {
        private readonly string _bucketName;
        private readonly StorageClient _storageClient;

        public GcpCloudStorageService(string bucketName)
        {
            _bucketName = bucketName;
            _storageClient = StorageClient.Create();
        }

        public async Task<string> UploadFileAsync(string fileName, string filePath, IFormFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                memoryStream.Position = 0;

                // 如果有指定資料夾路徑，將其加到檔案名稱前
                string fullFileName = string.IsNullOrEmpty(filePath)
                    ? fileName
                    : $"{filePath.TrimEnd('/')}/{fileName}";

                await _storageClient.UploadObjectAsync(_bucketName, fullFileName, file.ContentType, memoryStream);
            }

            return $"https://storage.googleapis.com/{_bucketName}/{(string.IsNullOrEmpty(filePath) ? fileName : $"{filePath.TrimEnd('/')}/{fileName}")}";
        }

        public async Task<bool> DeleteFileAsync(string fileName, string filePath)
        {
            try
            {
                string fullFileName = string.IsNullOrEmpty(filePath)
                    ? fileName
                    : $"{filePath.TrimEnd('/')}/{fileName}";

                await _storageClient.DeleteObjectAsync(_bucketName, fullFileName);
                return true;
            }
            catch
            {
                return false; // 如果發生錯誤，回傳 false
            }
        }


        public async Task<bool> UpdateFileAsync(string fileName, string filePath, IFormFile newFile)
        {
            try
            {
                // 刪除舊檔案
                await DeleteFileAsync(fileName, filePath);

                // 上傳新檔案
                await UploadFileAsync(fileName, filePath, newFile);

                return true;
            }
            catch
            {
                return false; // 如果發生錯誤，回傳 false
            }
        }

    }

}
