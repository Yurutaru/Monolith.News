using Monolith.News.Core.Dto.Notes;
using Monolith.News.Domain.Interfaces;

namespace Monolith.News.Core.Services.Interfaces
{
    public interface INoteService : IService
    {
        Task<NoteResponse> Create(NoteCreateRequest request);
        Task Update(int noteId, NoteUpdateRequest request);
        Task<NoteResponse> Get(int noteId);
        Task<IEnumerable<NoteResponse>> GetAll(int skip = 0, int take = 100);
        Task Delete(int noteId);
    }
}
