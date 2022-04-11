namespace Monolith.News.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task CommitAsync();
        Task RollbackAsync();
    }
}
