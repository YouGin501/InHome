using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using web_site_Domain.Models;

namespace web_site_BAL.Contracts
{
    public interface IAzureBlobStorage
    {
        Task<List<Document>> UploadFiles(List<IFormFile> files, string containerName);
        Task<bool> DeleteBlob(string containerName, string blobName);
        Task<List<BlobItem>> GetUploadedBlobs(string containerName);
        Task<List<ImageUrl>> UploadPhotos(List<IFormFile> photos, string containerName);
        Task<ImageUrl> UploadPhoto(IFormFile photo, string containerName);
    }
}
