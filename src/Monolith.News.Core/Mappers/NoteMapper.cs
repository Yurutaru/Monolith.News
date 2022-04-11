using Monolith.News.Core.Dto.Notes;
using Monolith.News.Core.Mappers.Interfaces;
using Monolith.News.Domain.Entities;

namespace Monolith.News.Core.Mappers
{
    // NOTE: rewrite on factory
    public class NoteMapper : INoteMapper
    {
        private readonly ITagMapper tagMapper;

        public NoteMapper(ITagMapper tagMapper)
        {
            this.tagMapper = tagMapper;
        }

        public NoteResponse Map(Note source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var result = new NoteResponse()
            {
                Id = source.Id,
                Body = source.Body,
                Subject = source.Subject,
                Tags = tagMapper.MapCollection(source.Tags)
            };

            return result;
        }

        public Note Map(NoteCreateRequest source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var result = new Note()
            {
                Body = source.Body,
                Subject = source.Subject,
            };

            return result;
        }

        public Note Map(NoteUpdateRequest source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var result = new Note()
            {
                Id = source.Id,
                Body = source.Body,
                Subject = source.Subject,
            };

            return result;
        }

        public IEnumerable<NoteResponse> MapCollection(IEnumerable<Note> source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var result = source.Select(x => Map(x)).ToArray();
            return result;
        }

        public IEnumerable<Note> MapCollection(IEnumerable<NoteCreateRequest> source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var result = source.Select(x => Map(x)).ToArray();
            return result;
        }

        public IEnumerable<Note> MapCollection(IEnumerable<NoteUpdateRequest> source)
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
