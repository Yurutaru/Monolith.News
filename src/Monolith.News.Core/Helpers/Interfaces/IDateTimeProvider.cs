namespace Monolith.News.Core.Helpers.Interfaces
{
    public interface IDateTimeProvider
    {
        DateTimeOffset GetUtcNow();
    }
}
