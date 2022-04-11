namespace Monolith.News.Domain.Entities
{
    public class Note
    {
        /// <summary>
        /// The note identifier.
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
        public ICollection<Tag> Tags { get; set; } = new List<Tag>();

        /// <summary>
        /// The collection of note tags.
        /// </summary>
        public ICollection<NoteTag> NoteTags { get; set; } = new List<NoteTag>();
    }
}
