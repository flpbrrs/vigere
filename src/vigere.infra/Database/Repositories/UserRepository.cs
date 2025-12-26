using Microsoft.EntityFrameworkCore;
using vigere.domain.Entities;
using vigere.domain.Repositories.Users;

namespace vigere.infra.Database.Repositories;

internal class UserRepository(VigereDbContext _context) : IWriteOnlyUsersRepository, IReadOnlyUserRepository
{
    public async Task<bool> ExistsUserWithEmail(string email)
    {
        return await _context.Users.AnyAsync(u => u.Email == email);
    }

    public async Task<User?> FindByEmail(string email)
    {
        return await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<User> Register(User user)
    {
        _context.Users.Add(user);
        return user;
    }
}
