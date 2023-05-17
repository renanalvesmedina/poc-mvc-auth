using Azure.Storage.Blobs;
using Lumini.Common.Model;
using Microsoft.AspNetCore.Http;

namespace Lumini.FireKeeper.Application.Services.Upload
{
    public class FileUploadService : IFileUploadService
    {
        private readonly BlobServiceClient _blobServiceClient;

        public FileUploadService(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        public async Task<Result> Send(string folder, string fileName, IFormFile file, CancellationToken cancellationToken)
        {
            try
            {
                var containerClient = _blobServiceClient.GetBlobContainerClient(folder);

                await containerClient.CreateIfNotExistsAsync(cancellationToken: cancellationToken);

                var fileExtension = Path.GetExtension(file.FileName);

                var blobClient = containerClient.GetBlobClient($"{fileName}{fileExtension}");

                await blobClient.UploadAsync(file.OpenReadStream(), cancellationToken);

                return Result.Success();
            }
            catch (Exception ex)
            {
                return ex;
            }
        }
    }
}
