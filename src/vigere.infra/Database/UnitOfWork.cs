using vigere.domain.Repositories;

namespace vigere.infra.Database;

internal class UnitOfWork(VigereDbContext _context) : IUnitOfWork
{
    public async Task Commit() => await _context.SaveChangesAsync();

    public void Dispose()
    {
        _context?.Dispose();
        GC.SuppressFinalize(this);
    }
}
