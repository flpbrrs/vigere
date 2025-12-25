using vigere.domain.Entities;
using vigere.domain.Repositories.Users;

namespace vigere.infra.Database.Repositories;

internal class UserRepository(VigereDbContext _context) : IWriteOnlyUsersRepository
{
    public async Task<User> Register(User user)
    {
        _context.Users.Add(user);
        return user;
    }
}
