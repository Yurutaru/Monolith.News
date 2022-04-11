using Monolith.News.Core.Dto.Tags;
using Monolith.News.Core.Mappers.Interfaces;
using Monolith.News.Domain.Entities;

namespace Monolith.News.Core.Mappers
{
    // NOTE: rewrite on factory
    public class TagMapper : ITagMapper
    {
        public TagResponse Map(Tag source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var result = new TagResponse()
            {
                Id = source.Id,
                Name = source.Name,
                BackgroundColor = source.BackgroundColor,
                Color = source.Color
            };

            return result;
        }

        public Tag Map(TagCreateRequest source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var result = new Tag()
            {
                Name = source.Name,
                BackgroundColor = source.BackgroundColor,
                Color = source.Color
            };

            return result;
        }

        public Tag Map(TagResponse source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var result = new Tag()
            {
                Id = source.Id,
                Name = source.Name,
                BackgroundColor = source.BackgroundColor,
                Color = source.Color
            };

            return result;
        }

        public IEnumerable<TagResponse> MapCollection(IEnumerable<Tag> source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var result = source.Select(x => Map(x)).ToArray();
            return result;
        }

        public IEnumerable<Tag> MapCollection(IEnumerable<TagCreateRequest> source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var result = source.Select(x => Map(x)).ToArray();
            return result;
        }

        public IEnumerable<Tag> MapCollection(IEnumerable<TagResponse> source)
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
