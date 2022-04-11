using Monolith.News.Core.Dto.NoteTags;
using Monolith.News.Core.Mappers.Interfaces;
using Monolith.News.Domain.Entities;

namespace Monolith.News.Core.Mappers
{
    // NOTE: rewrite on factory
    public class NoteTagMapper : INoteTagMapper
    {
        private readonly ITagMapper tagMapper;
        private readonly INoteMapper noteMapper;

        public NoteTagMapper(ITagMapper tagMapper, INoteMapper noteMapper)
        {
            this.tagMapper = tagMapper;
            this.noteMapper = noteMapper;
        }

        public NoteTagResponse Map(NoteTag source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var result = new NoteTagResponse()
            {
                Note = noteMapper.Map(source.Note ?? new Note()),
                Tag = tagMapper.Map(source.Tag ?? new Tag())
            };

            return result;
        }

        public IEnumerable<NoteTagResponse> MapCollection(IEnumerable<NoteTag> source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var result = source.Select(x => Map(x)).ToArray();
            return result;
        }
    }
}
