using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using web_site_BAL.Contracts;
using web_site_Domain.Models;
using Document = web_site_Domain.Models.Document;

namespace web_site_BAL.Services
{
    public class AzureBlobService : IAzureBlobStorage
    {
        BlobServiceClient _blobClient;

        public AzureBlobService(IConfiguration configuration)
        {
            _blobClient = new BlobServiceClient(configuration.GetConnectionString("AzureBlob"));
        }

        public async Task<List<Document>> UploadFiles(List<IFormFile> files, string containerName)
        {
            try
            {
                BlobContainerClient _containerClient = _blobClient.GetBlobContainerClient(
                    containerName
                );

                var blobHttpHeader = new BlobHttpHeaders { ContentType = "application/pdf" };

                var azureResponse = new List<Azure.Response<BlobContentInfo>>();
                var savedFileNames = new List<Document>();
                foreach (var file in files)
                {
                    string fileName = $"{Guid.NewGuid()}.pdf";
                    BlobClient blobClient = _containerClient.GetBlobClient(fileName);
                    using (var memoryStream = new MemoryStream())
                    {
                        file.CopyTo(memoryStream);
                        memoryStream.Position = 0;
                        azureResponse.Add(
                            await blobClient.UploadAsync(memoryStream, blobHttpHeader)
                        );
                        savedFileNames.Add(new Document { FileName = fileName });
                    }
                }

                return savedFileNames;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ImageUrl> UploadPhoto(IFormFile photo, string containerName)
        {
            try
            {
                BlobContainerClient _containerClient = _blobClient.GetBlobContainerClient(
                    containerName
                );

                var extension = Path.GetExtension(photo.FileName);

                var blobHttpHeader = new BlobHttpHeaders
                {
                    ContentType = $"image/{extension[1..]}"
                };

                var azureResponse = new List<Azure.Response<BlobContentInfo>>();
                ImageUrl? savedFileName;

                string fileName = $"{Guid.NewGuid()}{extension}";
                BlobClient blobClient = _containerClient.GetBlobClient(fileName);
                using (var memoryStream = new MemoryStream())
                {
                    photo.CopyTo(memoryStream);
                    memoryStream.Position = 0;
                    await blobClient.UploadAsync(memoryStream, blobHttpHeader);
                    savedFileName = new ImageUrl
                    {
                        FileName = fileName,
                        Url =
                            $"https://documentsinhome.blob.core.windows.net/{containerName}/{fileName}#toolbar=0&navpanes=0&scrollbar=0",
                    };
                }

                return savedFileName;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ImageUrl>> UploadPhotos(List<IFormFile> photos, string containerName)
        {
            try
            {
                BlobContainerClient _containerClient = _blobClient.GetBlobContainerClient(
                    containerName
                );

                var azureResponse = new List<Azure.Response<BlobContentInfo>>();
                List<ImageUrl> savedPhotos = new();

                foreach (var photo in photos)
                {
                    var extension = Path.GetExtension(photo.FileName);

                    var blobHttpHeader = new BlobHttpHeaders
                    {
                        ContentType = $"image/{extension[1..]}"
                    };

                    string fileName = $"{Guid.NewGuid()}{extension}";
                    BlobClient blobClient = _containerClient.GetBlobClient(fileName);
                    using (var memoryStream = new MemoryStream())
                    {
                        photo.CopyTo(memoryStream);
                        memoryStream.Position = 0;
                        await blobClient.UploadAsync(memoryStream, blobHttpHeader);
                        savedPhotos.Add(
                            new ImageUrl
                            {
                                FileName = fileName,
                                Url =
                                    $"https://documentsinhome.blob.core.windows.net/{containerName}/{fileName}#toolbar=0&navpanes=0&scrollbar=0",
                            }
                        );
                    }
                }

                return savedPhotos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteBlob(string containerName, string blobName)
        {
            try
            {
                BlobContainerClient _containerClient = _blobClient.GetBlobContainerClient(
                    containerName
                );

                return await _containerClient.DeleteBlobIfExistsAsync(blobName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<BlobItem>> GetUploadedBlobs(string containerName)
        {
            BlobContainerClient _containerClient = _blobClient.GetBlobContainerClient(
                containerName
            );
            var items = new List<BlobItem>();
            var uploadedFiles = _containerClient.GetBlobsAsync();
            await foreach (BlobItem file in uploadedFiles)
            {
                items.Add(file);
            }

            return items;
        }
    }
}
