namespace Monolith.News.Domain.Entities
{
    public class NoteTag
    {
        // NOTE: Need add an auto-increment identifier or delete them.
        /// <summary>
        /// The note tag identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The tag.
        /// </summary>
        public Tag? Tag { get; set; }

        /// <summary>
        /// The tag identifier.
        /// </summary>
        public int TagId { get; set; }

        /// <summary>
        /// The note.
        /// </summary>
        public Note? Note { get; set; }

        /// <summary>
        /// The note identifier.
        /// </summary>
        public int NoteId { get; set; }

        /// <summary>
        /// The date of created note tag.
        /// </summary>
        public DateTimeOffset? CreatedDate { get; set; }
    }
}
