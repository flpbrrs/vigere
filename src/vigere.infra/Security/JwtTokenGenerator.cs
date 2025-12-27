using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using vigere.domain.Entities;
using vigere.domain.Providers;

namespace vigere.infra.Security;

public class JwtTokenGenerator(IOptions<JwtSettings> jwtOptions) : ITokenGenerator
{
    private readonly JwtSettings _jwtSettings = jwtOptions.Value;

    public string GenerateToken(User user)
    {
        var key = Encoding.UTF8.GetBytes(_jwtSettings.SecretKey);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpirationTimeInMinutes),
            Claims = new Dictionary<string, object>
            {
                { JwtRegisteredClaimNames.Sub, user.Identifier.ToString() },
                { JwtRegisteredClaimNames.Email, user.Email },
                { "role", user.Role },
                { JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString() }
            },
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature
            )
        };

        var handler = new JsonWebTokenHandler();
        return handler.CreateToken(tokenDescriptor);
    }
}
