namespace Monolith.News.Domain.Interfaces
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork BeginTransaction();
    }
}
