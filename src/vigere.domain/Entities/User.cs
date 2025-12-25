using vigere.domain.Enums;

namespace vigere.domain.Entities;

public class User
{
    public long Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public Guid Identifier { get; set; } = Guid.NewGuid();
    public string Role { get; set; } = Roles.User;
    public DateTime ControlDate { get; set; } = DateTime.UtcNow;
}
