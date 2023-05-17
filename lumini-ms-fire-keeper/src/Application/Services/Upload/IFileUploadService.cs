using Lumini.Common.Model;
using Microsoft.AspNetCore.Http;

namespace Lumini.FireKeeper.Application.Services.Upload
{
    public interface IFileUploadService
    {
        Task<Result> Send(string folder, string fileName, IFormFile file, CancellationToken cancellationToken);
    }
}
