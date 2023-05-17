using Lumini.Common.Mediator;
using Lumini.Common.Model;
using Lumini.FireKeeper.Application.Requests.Authentication.GenerateToken;
using Lumini.FireKeeper.Domain.Catalogs;
using Lumini.FireKeeper.Domain.Entities.Authentication;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Lumini.FireKeeper.Application.Requests.Authentication.UserLogin
{
    public class UserLoginHandler : Handler<UserLoginRequest, UserLoginResult>
    {
        private readonly UserManager<User> _userManager;
        private readonly IMediator _mediator;

        public UserLoginHandler(UserManager<User> userManager, IMediator mediator)
        {
            _userManager = userManager;
            _mediator = mediator;
        }

        public override async Task<Result<UserLoginResult>> Handle(UserLoginRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.Email);

            if (user == null)
                return NotFound(ErrorCatalog.Authentication.NotFound);

            if (!await _userManager.CheckPasswordAsync(user, request.Password))
                return BusinessRuleViolated(ErrorCatalog.Authentication.InvalidPassword);

            // Request generate JWT token...
            var tokenRequest = new GenerateTokenRequest
            {
                UserId = user.Id
            };

            var tokenResult = await _mediator.Send(tokenRequest, cancellationToken);


            var result = new UserLoginResult
            {
                UserName = user.FullName,
                Token = tokenResult.Value.Token
            };

            return Success(result);
        }
    }
}
