using Lumini.Common.Mediator;
using Lumini.Common.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Lumini.FireKeeper.Application.Requests.Authentication.GenerateToken
{
    public class GenerateTokenHandler : Handler<GenerateTokenRequest, GenerateTokenResult>
    {
        private readonly IConfiguration _configuration;

        public GenerateTokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public override Task<Result<GenerateTokenResult>> Handle(GenerateTokenRequest request, CancellationToken cancellationToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("Secret").Value);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, request.UserId.ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            var result = new GenerateTokenResult
            {
                Token = tokenHandler.WriteToken(token),
            };

            return Success(result);
        }
    }
}
