namespace Monolith.News.Core.Dto.Notes
{
    public class NoteCreateRequest
    {
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
        public int[]? Tags { get; set; }
    }
}
