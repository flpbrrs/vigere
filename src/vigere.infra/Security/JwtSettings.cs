namespace vigere.infra.Security;

public class JwtSettings
{
    public const string SectionName = "Jwt";
    public string SecretKey { get; init; } = string.Empty;
    public int ExpirationTimeInMinutes { get; init; }
}
