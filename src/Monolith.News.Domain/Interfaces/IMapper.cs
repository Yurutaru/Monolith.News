namespace Monolith.News.Domain.Interfaces
{
    public interface IMapper<in TSource, out TDestination>
        where TSource : class
        where TDestination : class
    {
        TDestination Map(TSource source);
        IEnumerable<TDestination> MapCollection(IEnumerable<TSource> source);
    }
}
