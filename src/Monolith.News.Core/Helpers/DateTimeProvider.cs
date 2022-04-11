using Monolith.News.Core.Helpers.Interfaces;

namespace Monolith.News.Core.Helpers
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTimeOffset GetUtcNow()
        {
            var result = DateTimeOffset.UtcNow;
            return result;
        }
    }
}
