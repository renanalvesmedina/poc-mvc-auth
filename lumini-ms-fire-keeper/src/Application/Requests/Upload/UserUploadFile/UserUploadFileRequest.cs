using Lumini.Common.Mediator;
using Microsoft.AspNetCore.Http;

namespace Lumini.FireKeeper.Application.Requests.Upload.UserUploadFile
{
    public class UserUploadFileRequest : Request
    {
        public Guid UserId { get; set; }
        public IFormFile File { get; set; }
    }
}
