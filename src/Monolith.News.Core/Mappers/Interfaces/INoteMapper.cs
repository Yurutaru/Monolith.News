using Monolith.News.Core.Dto.Notes;
using Monolith.News.Domain.Entities;
using Monolith.News.Domain.Interfaces;

namespace Monolith.News.Core.Mappers.Interfaces
{
    // NOTE: rewrite on factory
    public interface INoteMapper :
        IMapper<NoteCreateRequest, Note>,
        IMapper<NoteUpdateRequest, Note>,
        IMapper<Note, NoteResponse>
    {
    }
}
