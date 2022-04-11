using Monolith.News.Core.Dto.Tags;
using Monolith.News.Domain.Entities;
using Monolith.News.Domain.Interfaces;

namespace Monolith.News.Core.Mappers.Interfaces
{
    // NOTE: rewrite on factory
    public interface ITagMapper :
        IMapper<Tag, TagResponse>,
        IMapper<TagResponse, Tag>,
        IMapper<TagCreateRequest, Tag>
    {
    }
}
