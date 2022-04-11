using Monolith.News.Core.Dto.NoteTags;
using Monolith.News.Domain.Interfaces;

namespace Monolith.News.Core.Services.Interfaces
{
    public interface INoteTagService : IService
    {
        Task<NoteTagResponse> Create(int noteId, int tagId);
        Task Delete(int noteId, int tagId);
    }
}
