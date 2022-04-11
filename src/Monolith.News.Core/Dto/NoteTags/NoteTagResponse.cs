using Monolith.News.Core.Dto.Notes;
using Monolith.News.Core.Dto.Tags;

namespace Monolith.News.Core.Dto.NoteTags
{
    public class NoteTagResponse
    {
        public int Id { get; set; }
        public NoteResponse? Note { get; set; }
        public TagResponse? Tag { get; set; }
    }
}
