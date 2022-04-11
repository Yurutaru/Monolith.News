using Monolith.News.Core.Dto.Tags;
using Monolith.News.Domain.Interfaces;

namespace Monolith.News.Core.Services
{
    public interface ITagService : IService
    {
        Task<TagResponse> Create(TagCreateRequest request);
        Task Update(int subjectId, TagUpdateRequest request);
        Task<TagResponse> Get(int subjectId);
        Task<IEnumerable<TagResponse>> GetAll(int skip = 0, int take = 100);
        Task Delete(int subjectId);
    }
}
