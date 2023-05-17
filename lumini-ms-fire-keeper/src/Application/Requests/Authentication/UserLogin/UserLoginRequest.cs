using Lumini.Common.Mediator;

namespace Lumini.FireKeeper.Application.Requests.Authentication.UserLogin
{
    public class UserLoginRequest : Request<UserLoginResult>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
