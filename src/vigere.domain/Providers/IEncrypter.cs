namespace vigere.domain.Providers;

public interface IEncrypter
{
    string Encrypt(string plainText);
    bool Verify(string hashedText, string originalText);
}
