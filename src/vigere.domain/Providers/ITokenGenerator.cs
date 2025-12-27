using vigere.domain.Entities;

namespace vigere.domain.Providers;

public interface ITokenGenerator
{
    string GenerateToken(User user);
}
