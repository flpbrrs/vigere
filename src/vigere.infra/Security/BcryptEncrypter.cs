using vigere.domain.Providers;

namespace vigere.infra.Security;

public class BcryptEncrypter : IEncrypter
{
    public string Encrypt(string plainText)
    {
        return BCrypt.Net.BCrypt.HashPassword(plainText);
    }
}
