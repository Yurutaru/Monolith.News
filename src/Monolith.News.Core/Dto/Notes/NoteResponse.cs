using Monolith.News.Core.Dto.Tags;

namespace Monolith.News.Core.Dto.Notes
{
    public class NoteResponse
    {
        /// <summary>
        /// The note identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The subject of note.
        /// </summary>
        public string? Subject { get; set; }

        /// <summary>
        /// The body of note.
        /// </summary>
        public string? Body { get; set; }

        /// <summary>
        /// The collection of tags.
        /// </summary>
        public IEnumerable<TagResponse>? Tags { get; set; }
    }
}
