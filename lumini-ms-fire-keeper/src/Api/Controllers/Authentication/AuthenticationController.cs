using Lumini.Common.Model.Presenter.WebApi;
using Lumini.FireKeeper.Api.Controllers.Authentication.Models;
using Lumini.FireKeeper.Application.Requests.Authentication.CreateUser;
using Lumini.FireKeeper.Application.Requests.Authentication.UserLogin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lumini.FireKeeper.Api.Controllers.Authentication
{
    [Route("/authentication")]
    [ApiController]
    public class AuthenticationController : SuperApiController
    {
        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="input">The User data</param>
        /// <returns>Created</returns>
        [Authorize]
        [HttpPost("user")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreateUser(CreateUserInput input)
        {
            var request = Map<CreateUserRequest>(input);

            var result = await Send(request);

            return Created(result);
        }

        /// <summary>
        /// Login with email and password
        /// </summary>
        /// <param name="input">The User login data</param>
        /// <returns>A Bearer Token valid</returns>
        [HttpPost("user/login")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserLoginResult>> Authenticate(UserLoginInput input)
        {
            var request = Map<UserLoginRequest>(input);

            var result = await Send(request);

            return Ok(result);
        }
    }
}
