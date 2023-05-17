using Azure.Storage.Blobs;
using Lumini.Common.Mediator;
using Lumini.Common.Model;

namespace Lumini.FireKeeper.Application.Requests.Upload.UploadFile
{
    public class UploadFileHandler : Handler<UploadFileRequest>
    {
        private readonly BlobServiceClient _blobServiceClient;

        public UploadFileHandler(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        public override async Task<Result> Handle(UploadFileRequest request, CancellationToken cancellationToken)
        {
            var blobContainer = request.UserId.ToString();
            var fileId = Guid.NewGuid();

            try
            {
                var containerClient = _blobServiceClient.GetBlobContainerClient(blobContainer);

                await containerClient.CreateIfNotExistsAsync(cancellationToken: cancellationToken);

                var fileExtension = Path.GetExtension(request.File.FileName);

                var blobClient = containerClient.GetBlobClient($"{fileId}{fileExtension}");

                await blobClient.UploadAsync(request.File.OpenReadStream(), cancellationToken);

                return Success();
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }
    }
}
