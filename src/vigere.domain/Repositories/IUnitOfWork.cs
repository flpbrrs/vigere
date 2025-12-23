namespace vigere.domain.Repositories;

public interface IUnitOfWork : IDisposable
{
    Task Commit();
}
