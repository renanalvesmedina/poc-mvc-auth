using Lumini.Common.Mediator;

namespace Lumini.FireKeeper.Application.Requests.Authentication.GenerateToken
{
    public class GenerateTokenRequest : Request<GenerateTokenResult>
    {
        public Guid UserId { get; set; }
    }
}
