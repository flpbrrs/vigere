using vigere.domain.Providers;

namespace vigere.infra.Security;

public class BcryptEncrypter : IEncrypter
{
    public bool Verify(string hashedText, string originalText) => BCrypt.Net.BCrypt.Verify(originalText, hashedText);

    public string Encrypt(string plainText) => BCrypt.Net.BCrypt.HashPassword(plainText);
}
