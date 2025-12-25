using vigere.domain.Entities;

namespace vigere.domain.Repositories.Users;

public interface IWriteOnlyUsersRepository
{
    public Task<User> Register(User user);
}
