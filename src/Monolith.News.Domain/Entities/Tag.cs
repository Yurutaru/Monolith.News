namespace Monolith.News.Domain.Entities
{
    public class Tag
    {
        /// <summary>
        /// The tag identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of tag.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// The background of tag.
        /// </summary>
        public string? BackgroundColor { get; set; }

        /// <summary>
        /// The color of tag.
        /// </summary>
        public string? Color { get; set; }

        /// <summary>
        /// The collection of notes.
        /// </summary>
        public ICollection<Note>? Notes { get; set; }

        /// <summary>
        /// The collection of note tags.
        /// </summary>
        public ICollection<NoteTag>? NoteTags { get; set; }
    }
}
