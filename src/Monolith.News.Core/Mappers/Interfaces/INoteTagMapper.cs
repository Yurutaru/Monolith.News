using Monolith.News.Core.Dto.NoteTags;
using Monolith.News.Domain.Entities;
using Monolith.News.Domain.Interfaces;

namespace Monolith.News.Core.Mappers.Interfaces
{
    // NOTE: rewrite on factory
    public interface INoteTagMapper :
        IMapper<NoteTag, NoteTagResponse>
    {
    }
}
