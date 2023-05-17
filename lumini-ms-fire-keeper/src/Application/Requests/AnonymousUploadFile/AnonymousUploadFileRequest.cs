using Lumini.Common.Mediator;
using Microsoft.AspNetCore.Http;

namespace Lumini.FireKeeper.Application.Requests.AnonymousUploadFile
{
    public class AnonymousUploadFileRequest : Request
    {
        public Guid ContainerId { get; set; }
        public IFormFile File { get; set; }
    }
}
