using Monolith.News.Domain;
using Monolith.News.Domain.Entities;

namespace Monolith.News.Core.Specifications.Tags
{
    public class GetTagsById : BaseSpecification<Tag>
    {
        public GetTagsById(IEnumerable<int> tags)
        {
            Criteria = t => tags.Contains(t.Id);
        }
    }
}
