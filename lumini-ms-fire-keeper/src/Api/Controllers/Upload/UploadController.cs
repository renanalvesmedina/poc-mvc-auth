using Lumini.Common.Model.Presenter.WebApi;
using Lumini.FireKeeper.Application.Requests.AnonymousUploadFile;
using Lumini.FireKeeper.Application.Requests.Upload.UserUploadFile;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Lumini.FireKeeper.Api.Controllers.Upload
{
    [Route("/upload")]
    [ApiController]
    public class UploadController : SuperApiController
    {
        /// <summary>
        /// Upload File to User private folder
        /// </summary>
        [Authorize]
        [HttpPost("me")]
        [Consumes("multipart/form-data")]
        [RequestSizeLimit(10L * 1024L * 1024L * 1024L)]
        [RequestFormLimits(MultipartBodyLengthLimit = 10L * 1024L * 1024L * 1024L)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UserUploadFile(IFormFile file)
        {
            var request = new UserUploadFileRequest
            {
                UserId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value),
                File = file
            };

            var result = await Send(request);

            return Ok(result);
        }

        /// <summary>
        /// Upload File to User shared folder
        /// </summary>
        [Authorize]
        [HttpPost("anonymous/{containerId}")]
        [AllowAnonymous]
        [Consumes("multipart/form-data")]
        [RequestSizeLimit(10L * 1024L * 1024L * 1024L)]
        [RequestFormLimits(MultipartBodyLengthLimit = 10L * 1024L * 1024L * 1024L)]

        public async Task<ActionResult> AnonymousUploadFile([FromRoute] Guid containerId, IFormFile file)
        {
            var request = new AnonymousUploadFileRequest
            {
                ContainerId = containerId,
                File = file
            };

            var result = await Send(request);

            return Ok(result);
        }
    }
}
