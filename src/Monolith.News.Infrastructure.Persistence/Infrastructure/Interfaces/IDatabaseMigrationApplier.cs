namespace Monolith.News.Infrastructure.Persistence.Infrastructure.Interfaces
{
    public interface IDatabaseMigrationApplier
    {
        void ApplyMigrations();
    }
}
