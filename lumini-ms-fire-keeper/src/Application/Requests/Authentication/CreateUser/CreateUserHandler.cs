using Lumini.Common.Mediator;
using Lumini.Common.Model;
using Lumini.FireKeeper.Domain.Catalogs;
using Lumini.FireKeeper.Domain.Entities.Authentication;
using Microsoft.AspNetCore.Identity;

namespace Lumini.FireKeeper.Application.Requests.Authentication.CreateUser
{
    public class CreateUserHandler : Handler<CreateUserRequest>
    {
        private readonly UserManager<User> _userManager;

        public CreateUserHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public override async Task<Result> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            if (!CreateUserValidator.ValidCpf(request.Document))
                return BusinessRuleViolated(ErrorCatalog.InvalidDocument);

            if (!CreateUserValidator.ValidEmail(request.Email))
                return BusinessRuleViolated(ErrorCatalog.InvalidEmail);

            var user = new User
            {
                UserName = request.Email,
                Email = request.Email,
                EmailConfirmed = true,
                FullName = request.FullName.Trim(),
                PhoneNumber = request.Phone,
                PhoneNumberConfirmed = true,
                Document = request.Document,
                CreatedOn = DateTime.Now
            };

            var userResult = await _userManager.CreateAsync(user, request.Password);

            if (!userResult.Succeeded)
            {
                foreach (var error in userResult.Errors)
                {
                    return BusinessRuleViolated(ErrorCatalog.Authentication.NotCreated(error.Description));
                }
            }

            return Success();
        }
    }
}
