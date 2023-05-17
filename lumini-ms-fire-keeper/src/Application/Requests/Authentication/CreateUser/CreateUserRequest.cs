using Lumini.Common.Mediator;

namespace Lumini.FireKeeper.Application.Requests.Authentication.CreateUser
{
    public class CreateUserRequest : Request
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Document { get; set; }
    }
}
