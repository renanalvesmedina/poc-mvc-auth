using Lumini.Common.Mediator;
using Microsoft.AspNetCore.Http;

namespace Lumini.FireKeeper.Application.Requests.Upload.UploadFile
{
    public class UploadFileRequest : Request
    {
        public Guid UserId { get; set; }
        public IFormFile File { get; set; }
    }
}
