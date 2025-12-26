using vigere.domain.Entities;

namespace vigere.domain.Repositories.Users;

public interface IReadOnlyUserRepository
{
    public Task<User?> FindByEmail(string email);
    public Task<bool> ExistsUserWithEmail(string email);
}
