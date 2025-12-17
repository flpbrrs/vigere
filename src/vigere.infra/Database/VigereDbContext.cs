using Microsoft.EntityFrameworkCore;
using vigere.domain.Entities;

namespace vigere.infra.Database;

internal class VigereDbContext(DbContextOptions<VigereDbContext> options) : DbContext(options)
{
    public DbSet<Expense> Expenses { get; set; }
    public DbSet<User> Users { get; set; }
}
